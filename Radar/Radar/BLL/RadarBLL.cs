using Radar.DALFactory;
using Radar.DALSQLite;
using Radar.IDAL;
using Radar.Model;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.BLL
{
    public class RadarBLL
    {
        private IRadarDAL _db;
        private const int DIAMETRO_TERRA = 6371;
        private const int RADAR_ID = 1;
        private IDictionary<string, bool> _radares = new Dictionary<string, bool>();

        public RadarBLL() {
            _db = RadarDALFactory.create();
        }

        public IList<RadarInfo> listar()
        {
            return _db.listar();
        }

        /// <summary>
        /// Lista dos radares dentro de uma região
        /// </summary>
        /// <param name="latitude">Latitude do centro da região</param>
        /// <param name="longitude">Longitude do centro da região</param>
        /// <param name="latitudeDelta">Delta da latitude</param>
        /// <param name="longitudeDelta">Delta da longitude</param>
        /// <returns>Lista de radares da região</returns>
        public IList<RadarInfo> listar(double latitude, double longitude, double latitudeDelta, double longitudeDelta) {
            return _db.listar(latitude, longitude, latitudeDelta, longitudeDelta);
        }

        public RadarInfo pegar(int idRadar)
        {
            return _db.pegar(idRadar);
        }

        public int gravar(RadarInfo radar)
        {
            return _db.gravar(radar);
        }

        public void excluir(int idRadar)
        {
            _db.excluir(idRadar);
        }

        private double angleFromCoordinate(double latitude1, double longitude1, double latitude2, double longitude2) {
            double dLong = longitude2 - longitude1;
            double y = Math.Sin(dLong) * Math.Cos(latitude2);
            double x = Math.Cos(latitude1) * Math.Sin(latitude2) - Math.Sin(latitude1) * Math.Cos(latitude2) * Math.Cos(dLong);

            double brng = Math.Atan2(y, x);
            brng = brng * (180 / Math.PI);
            brng = (brng + 360) % 360;
            brng = 360 - brng;
            return brng;
        }

        private double toRadians(double deg) {
            return deg * (Math.PI / 100);
        }

        private double calcularDistancia(double initialLat, double initialLong, double finalLat, double finalLong)
        {
            double dLat = toRadians(finalLat - initialLat);
            double dLon = toRadians(finalLong - initialLong);
            double lat1 = toRadians(initialLat);
            double lat2 = toRadians(finalLat);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return DIAMETRO_TERRA * c * 1000;
        }

        private void limparAlertado(double Latitude, double Longitude) {
            int radarAtivo = 0;
            int radarTodo = 0;
            foreach (KeyValuePair<string, bool> alerta in _radares) {
                radarTodo++;
                if (alerta.Value)
                    radarAtivo++;
            }
            foreach (KeyValuePair<string, bool> alerta in _radares) {
                string str = alerta.Key.Substring(0, alerta.Key.IndexOf('|'));
                double latitudeRadar = Convert.ToDouble(str);
                str = alerta.Key.Substring(alerta.Key.IndexOf('|') + 1);
                double longitudeRadar = Convert.ToDouble(str);
                double distancia = Math.Floor(calcularDistancia(Latitude, Longitude, latitudeRadar, longitudeRadar));
                if (distancia > Configuracao.DistanciaRadar) {
                    _radares.Add(alerta.Key, false);
                }
            }
        }

        private void alertar(LocalizacaoInfo local, RadarInfo radar) {
            string mensagem = "Tem um radar a frente, diminua para " + radar.Velocidade.ToString() + "km/h!";
            MensagemUtils.notificar(RADAR_ID, "Alerta de Radar", mensagem);
        }

        public void calcularLocalizacaoRadar(LocalizacaoInfo local, RadarInfo radar) {
            //double velocidade = local.Velocidade * 3.6;
            double velocidade = local.Velocidade;
            //double angulo = Math.Floor(local.Sentido);
            if (velocidade > radar.Velocidade) {
                double anguloRelacaoRadar = local.Sentido - radar.Direcao;
                if (((Math.Abs(anguloRelacaoRadar) % 360) <= Configuracao.AnguloRadar) || ((360 - Math.Abs(anguloRelacaoRadar)) % 360) <= Configuracao.AnguloRadar) {
                    string posLatLong = radar.Latitude.ToString() + "|" + radar.Longitude.ToString();
                    if ((_radares.ContainsKey(posLatLong) && _radares[posLatLong] == false) || !_radares.ContainsKey(posLatLong))
                    {

                        double anguloRadar = angleFromCoordinate(local.Latitude, local.Longitude, radar.Latitude, radar.Longitude);
                        //double meuAngulo = local.Sentido;

                        double anguloDiferencial = local.Sentido - anguloRadar;
                        if (anguloDiferencial < 0)
                            anguloDiferencial += 360;
                        if (anguloDiferencial > 360)
                            anguloDiferencial -= 360;

                        if (((Math.Abs(anguloDiferencial) % 360) <= Configuracao.AnguloCone) || ((360 - Math.Abs(anguloDiferencial)) % 360) <= Configuracao.AnguloCone)
                        {
                            _radares.Add(posLatLong, true);
                            alertar(local, radar);
                        }
                        else
                            Debug.WriteLine("Radar não está no cone. Meu angulo (" + Math.Floor(local.Sentido) + ") + eu/radar(" + Math.Floor(anguloRadar) + ").");
                    }
                    else
                        Debug.WriteLine("Radar encontrado mas já foi alertado.");
                }
                else
                    Debug.WriteLine("Radar encontrado mas angulo não bate com o do radar = " + Math.Floor(anguloRelacaoRadar) + ".");
            }
        }

        /// <summary>
        /// Faz todos os calculos referentes a posição do radar referente a posição do usuário
        /// </summary>
        /// <param name="local">Localização enviada pelo GPS.</param>
        public void calcularLocalizacao(LocalizacaoInfo local) {

            double latitudeOld = local.Latitude;
            double longitudeOld = local.Longitude;

            double distanciaCos = Math.Cos((Configuracao.DistanciaRadar / 1000) / DIAMETRO_TERRA);

            double latitudeCos = Math.Cos(local.Latitude * Math.PI / 180);
            double latitudeSin = Math.Sin(local.Latitude * Math.PI / 180);
            double longitudeCos = Math.Cos(local.Longitude * Math.PI / 180);
            double longitudeSin = Math.Sin(local.Longitude * Math.PI / 180);

            limparAlertado(local.Latitude, local.Longitude);

            IList<RadarInfo> radares = _db.listar(latitudeCos, longitudeCos, latitudeSin, longitudeSin, distanciaCos);
            foreach (RadarInfo radar in radares) {
                calcularLocalizacaoRadar(local, radar);
            }
        }
    }
}
