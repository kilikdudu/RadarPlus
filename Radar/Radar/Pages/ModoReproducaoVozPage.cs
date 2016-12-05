using ClubManagement.Utils;
using Radar.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ClubManagement.Extensions;
using Radar.Model;
using Radar.Utils;

namespace Radar.Pages
{
    public class ModoReproducaoVozPage: ContentPage
    {
        Switch _HabilitarVozSwitch;
        Switch _LigarDesligarSwitch;
        Switch _AlertaSonoroSwitch;

        public ModoReproducaoVozPage() {

            inicializarComponente();

            Title = "Reprodução Voz";
            Content = new ScrollView {
                Orientation = ScrollOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout {
                    Style = EstiloUtils.PreferenciaStack,
                    Children = {
                        inicializarHabilitarVoz(),
                        inicializarLigarDesligar(),
                        inicializarAlertaSonoro(),
                        inicializarReproduzirTeste()
                    }
                }
            };
        }

        public void inicializarComponente() {
            _HabilitarVozSwitch = new Switch {
                Style = EstiloUtils.PreferenciaSwitch,
                IsToggled = PreferenciaUtils.HabilitarVoz
            }; 
            _HabilitarVozSwitch.Toggled += (sender, e) => {
                PreferenciaUtils.HabilitarVoz = e.Value;
            };

            _LigarDesligarSwitch = new Switch
            {
                Style = EstiloUtils.PreferenciaSwitch,
                IsToggled = PreferenciaUtils.LigarDesligar
            };
            _LigarDesligarSwitch.Toggled += (sender, e) => {
                PreferenciaUtils.LigarDesligar = e.Value;
            };

            _AlertaSonoroSwitch = new Switch
            {
                Style = EstiloUtils.PreferenciaSwitch,
                IsToggled = PreferenciaUtils.AlertaSonoro
            };
            _AlertaSonoroSwitch.Toggled += (sender, e) => {
                PreferenciaUtils.AlertaSonoro = e.Value;
            };
        }

        private View inicializarSwitch(string titulo, string descricao, Switch campo)
        {
            return new Frame
            {
                Style = EstiloUtils.PreferenciaFrame,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Children = {
                        new StackLayout {
                            Orientation = StackOrientation.Horizontal,
                            Children = {
                                new Label {
                                    Text = titulo,
                                    Style = EstiloUtils.PreferenciaTitulo
                                },
                                campo
                            }
                        },
                        new Label {
                            Text = descricao,
                            Style = EstiloUtils.PreferenciaDescricao
                        }
                    }
                }
            };
        }

        private View inicializarHabilitarVoz() {
            return inicializarSwitch("Habilitar Voz", "Avisa com voz a chegada em algum radar", _HabilitarVozSwitch);
        }

        private View inicializarLigarDesligar()
        {
            return inicializarSwitch("Ao Ligar e Desligar", "Reproduz voz ao iniciar ou delisgar o aplicativo", _LigarDesligarSwitch);
        }

        private View inicializarAlertaSonoro() {
            return inicializarSwitch("Alerta Sonoro", "Além da reprodução de voz, emitir também o alerta sonoro", _AlertaSonoroSwitch);
        }

        private View inicializarReproduzirTeste()
        {
            var frame = new Frame
            {
                Style = EstiloUtils.PreferenciaFrame,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                        new Label {
                            Style = EstiloUtils.PreferenciaTitulo,
                            Text = "Reproduzir Teste"
                        }
                    }
                }
            };
            frame.GestureRecognizers.Add( new TapGestureRecognizer() {
                Command = new Command(() => {
                    var tipoRadares = new List<RadarTipoEnum>() {
                        RadarTipoEnum.Lombada,
                        RadarTipoEnum.Pedagio,
                        RadarTipoEnum.PoliciaRodoviaria,
                        RadarTipoEnum.RadarFixo,
                        RadarTipoEnum.RadarMovel, 
                        RadarTipoEnum.SemaforoComRadar
                    };
                    var velocidades = new List<int>() { 40, 50, 60, 70, 80 };
                    var distancias = new List<int>() { 100, 200, 300, 400, 500, 600, 700 };

                    var tipoRadar = tipoRadares.Randomize().FirstOrDefault();
                    var velocidade = velocidades.Randomize().FirstOrDefault();
                    var distancia = distancias.Randomize().FirstOrDefault();

                    var aviso = new AvisoSonoroBLL();
                    aviso.play(tipoRadar, velocidade, distancia);
                })
            });
            return frame;
        }
    }
}
