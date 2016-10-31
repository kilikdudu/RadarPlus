using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Radar.Pages
{
    public class ErroPage : ContentPage
    {
        private const string EMAIL_SUPORTE = "rodrigo@cmapps.com.br";

        private static bool _emErro = false;

        public static void exibir(Exception erro) {
            if (erro != null && !_emErro)
            {
                ErroPage erroPage = new ErroPage();
                erroPage.Erro = erro;
                _emErro = true;
                Application.Current.MainPage = new NavigationPage(erroPage);
            }
        }

        private Exception _erro;
        public Exception Erro {
            get {
                return _erro;
            }
            set {
                _erro = value;
                atualizar();
            }
        }

        private Label _mensagemLabel;
        private Button _reportarButton;

        public ErroPage()
        {
            _mensagemLabel = new Label()
            {
                FontSize = 14
            };
            _reportarButton = new Button {
                Text = "Reportar"
            };
            _reportarButton.Clicked += (sender, e) => {
                if (_erro != null)
                    MensagemUtils.enviarEmail(EMAIL_SUPORTE, "[" + DateTime.Now.ToString("dd/MM/yyyy hh:mm") + "] Ocorreu um erro no Radar", _erro.ToString());
            };

            Title = "Ocorreu um erro inesperado";
            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = 20,
                Children = {
                    _mensagemLabel,
                    _reportarButton
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _emErro = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _emErro = false;
        }

        private void atualizar() {
            if (_erro != null)
                _mensagemLabel.Text = _erro.ToString();
        }
    }
}
