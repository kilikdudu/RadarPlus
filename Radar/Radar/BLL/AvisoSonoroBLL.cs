using ClubManagement.Utils;
using Radar.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.BLL
{
    public class AvisoSonoroBLL
    {
        private const string DIR_AUDIO = "audios";

        private IDictionary<RadarTipoEnum, string> AUDIO_RADAR = new Dictionary<RadarTipoEnum, string>() {
            {  RadarTipoEnum.Lombada, "lombada.mp3" },
            {  RadarTipoEnum.Pedagio, "pedagio.mp3" },
            {  RadarTipoEnum.PoliciaRodoviaria, "policia-rodoviaria.mp3" },
            {  RadarTipoEnum.RadarFixo, "radar-fixo.mp3" },
            {  RadarTipoEnum.RadarMovel, "radar-movel.mp3" },
            {  RadarTipoEnum.SemaforoComRadar, "radar-semaforo.mp3" }
        };

        private IDictionary<int, string> AUDIO_DISTANCIA = new Dictionary<int, string>() {
            { 100, "100-metros.mp3" },
            { 200, "200-metros.mp3" },
            { 300, "300-metros.mp3" },
            { 400, "400-metros.mp3" },
            { 500, "500-metros.mp3" },
            { 600, "600-metros.mp3" },
            { 700, "700-metros.mp3" },
            { 800, "800-metros.mp3" },
            { 900, "900-metros.mp3" },
            { 1000, "1000-metros.mp3" }
        };

        private IDictionary<int, string> AUDIO_VELOCIDADE = new Dictionary<int, string>() {
            { 10, "limite-10-km.mp3" },
            { 20, "limite-20-km.mp3" },
            { 30, "limite-30-km.mp3" },
            { 40, "limite-40-km.mp3" },
            { 50, "limite-50-km.mp3" },
            { 60, "limite-60-km.mp3" },
            { 70, "limite-70-km.mp3" },
            { 80, "limite-80-km.mp3" },
            { 90, "limite-90-km.mp3" },
            { 100, "limite-100-km.mp3" },
            { 110, "limite-110-km.mp3" },
            { 120, "limite-120-km.mp3" }
        };

        public void play(RadarTipoEnum tipoRadar, int distancia)
        {
            play(tipoRadar, 0, distancia);
        }

        public void play(RadarTipoEnum tipoRadar, int velocidade, int distancia) {
            IList<string> audios = new List<string>();
            audios.Add(Path.Combine(DIR_AUDIO, AUDIO_RADAR[tipoRadar]));
            if (velocidade > 0)
                audios.Add(Path.Combine(DIR_AUDIO, AUDIO_VELOCIDADE[velocidade]));
            if (distancia > 0)
                audios.Add(Path.Combine(DIR_AUDIO, AUDIO_DISTANCIA[distancia]));
            AudioUtils.Volume = PreferenciaUtils.AlturaVolume;
            AudioUtils.Canal = PreferenciaUtils.CanalAudio;
            AudioUtils.play(audios.ToArray());
        }
    }
}
