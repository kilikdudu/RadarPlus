using Radar.Model;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Radar.Controls {
    public class Velocimetro : BoxView {
        private const int _loopInicio = 30;
        private const int _loopFim = 90;

        private float _velocidadeAtual = 0;
        private float _velocidadeRadar = 0;

        public Velocimetro()
        {
        }

        public float VelocidadeAtual
        {
            get {
                return _velocidadeAtual;
            }
            set {
                _velocidadeAtual = value;
                //this.desenhar();
            }
        }
        
        public float VelocidadeRadar
        {
            get {
                return _velocidadeRadar;
            }
            set {
                _velocidadeAtual = value;
                //this.desenhar();
            }
        }

        public float TelaLargura
        {
            get { return pegarAlturaTela(); }
        }

        public float TelaAltura
        {
            get { return pegarLarguraTela(); }
        }

        //VelocidadeInfo posicoes = new VelocidadeInfo();
        // Pixel density
        private readonly float density;

        public static readonly BindableProperty ShapeTypeProperty = BindableProperty.Create<Velocimetro, ShapeType>(s => s.ShapeType, ShapeType.Box);

        public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create<Velocimetro, Color>(s => s.StrokeColor, Color.Default);

        public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create<Velocimetro, float>(s => s.StrokeWidth, 1f);

        public static readonly BindableProperty IndicatorPercentageProperty = BindableProperty.Create<Velocimetro, float>(s => s.IndicatorPercentage, 0f);

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create<Velocimetro, float>(s => s.CornerRadius, 0f);

        public static readonly BindableProperty PaddingProperty = BindableProperty.Create<Velocimetro, Thickness>(s => s.Padding, default(Thickness));

        public ShapeType ShapeType
        {
            get { return (ShapeType)GetValue(ShapeTypeProperty); }
            set { SetValue(ShapeTypeProperty, value); }
        }

        public Color StrokeColor
        {
            get { return (Color)GetValue(StrokeColorProperty); }
            set { SetValue(StrokeColorProperty, value); }
        }

        public float StrokeWidth
        {
            get { return (float)GetValue(StrokeWidthProperty); }
            set { SetValue(StrokeWidthProperty, value); }
        }

        public float IndicatorPercentage
        {
            get { return (float)GetValue(IndicatorPercentageProperty); }
            set
            {
                if (ShapeType != ShapeType.CircleIndicator)
                    throw new ArgumentException("Can only specify this property with CircleIndicator");
                SetValue(IndicatorPercentageProperty, value);
            }
        }

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set
            {
                if (ShapeType != ShapeType.Box)
                    throw new ArgumentException("Can only specify this property with Box");
                SetValue(CornerRadiusProperty, value);
            }
        }

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public delegate void desenharTextoHandler(string Texto, float x, float y, PonteiroCorEnum cor);
        public desenharTextoHandler desenharTexto;

        public delegate void desenharTextoLabelHandler(string Texto, float x, float y);
        public desenharTextoLabelHandler desenharTextoLabel;

        public delegate void desenharTextoVelocidadeHandler(string Texto, float x, float y);
        public desenharTextoVelocidadeHandler desenharTextoVelocidade;

        public delegate void desenharPonteiroHandler(RetanguloInfo rect, PonteiroCorEnum cor);
        public desenharPonteiroHandler desenharPonteiro;

        public delegate float pegarAlturaTelaHandler();
        public pegarAlturaTelaHandler pegarAlturaTela;

        public delegate float pegarLarguraTelaHandler();
        public pegarLarguraTelaHandler pegarLarguraTela;

        public delegate void redesenharHandler();
        public redesenharHandler redesenhar;

        public void desenhar() {

            int num = 0;
            if (TelaLargura > TelaAltura) {
                desenharTextoLabel("km/h", TelaLargura / 4.3F, TelaAltura / 1.7F);
                desenharTextoVelocidade(_velocidadeAtual.ToString(), TelaLargura / 4F, TelaAltura / 2F);
            } else {
                desenharTextoLabel("km/h", TelaLargura / 2.5F, TelaAltura / 3F);
                desenharTextoVelocidade(_velocidadeAtual.ToString(), TelaLargura / 2.3F, TelaAltura / 3.5F);
            }

            for (var loop = _loopInicio; loop <= _loopFim; loop++) {
                float tamX = 0;
                float tamY = 0;

                if (loop % 5 == 0) {
                    PonteiroCorEnum cor = PonteiroCorEnum.Cinza;
                    if (TelaLargura > TelaAltura) {
                        tamX = (TelaLargura / 3.8F) + (float)Math.Floor(((TelaLargura * 25 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240)));
                        tamY = (TelaAltura / 2F) + (float)Math.Floor(((TelaLargura * 25 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240)));

                    } else {
                        tamX = (TelaLargura / 2.2F) + (float)Math.Floor(((TelaAltura * 23 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240)));
                        tamY = (TelaAltura / 3.4F) + (float)Math.Floor(((TelaAltura * 23 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240)));

                    }
                    if ((loop) <= VelocidadeAtual + 10) {
                        cor = PonteiroCorEnum.Verde;
                    }
                    if (loop == VelocidadeRadar ) {
                        //strokePaint.Color = Android.Graphics.Color.Red;
                        cor = PonteiroCorEnum.Vermelho;
                    }
                    desenharTexto(num.ToString(), tamX, tamY, cor);
                    num = num + 10;
                }
            }
            for (var loop = _loopInicio - 20; loop <= _loopFim - 20; loop++) {
                //valor referencia var tamX =  350;
                //valor referencia var tamY =  350;

                RetanguloInfo rect = new RetanguloInfo();
                PonteiroCorEnum cor = PonteiroCorEnum.Cinza;
                if (loop % 5 == 0) {
                    if (TelaLargura > TelaAltura) {
                        Debug.WriteLine("Width: " + TelaLargura);
                        rect.Left = (TelaLargura / 3.5F) + (float)((TelaLargura * 40 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Right = TelaLargura / 3.5F + (float)((TelaLargura * 40 / 100) / 1.90F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Top = (TelaAltura / 2F) + (float)((TelaLargura * 40 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                        rect.Bottom = TelaAltura / 2F + (float)((TelaLargura * 40 / 100) / 1.90 * Math.Cos(loop * 6 * Math.PI / 240));

                    } else {
                        rect.Left = (TelaLargura / 2F) + (float)((TelaLargura * 60 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Right = TelaLargura / 2F + (float)((TelaLargura * 60 / 100) / 1.90F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Top = (TelaAltura / 3.5F) + (float)((TelaLargura * 60 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                        rect.Bottom = TelaAltura / 3.5F + (float)((TelaLargura * 60 / 100) / 1.90 * Math.Cos(loop * 6 * Math.PI / 240));

                    }
                   
                    if (loop <= VelocidadeAtual + 10) {
                        cor = PonteiroCorEnum.Verde;
                    }
                    if (loop == VelocidadeRadar - 20) {
                        //strokePaint.Color = Android.Graphics.Color.Red;
                        cor = PonteiroCorEnum.Vermelho;
                    }
                    desenharPonteiro(rect, cor);
                } else {
                    if (TelaLargura > TelaAltura) {
                        rect.Left = (TelaLargura / 3.5F) + (float)((TelaLargura * 40 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Right = TelaLargura / 3.5F + (float)((TelaLargura * 40 / 100) / 1.70F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Top = (TelaAltura / 2F) + (float)((TelaLargura * 40 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                        rect.Bottom = TelaAltura / 2F + (float)((TelaLargura * 40 / 100) / 1.70 * Math.Cos(loop * 6 * Math.PI / 240));
                    } else {
                        rect.Left = (TelaLargura / 2F) + (float)((TelaLargura * 60 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Right = TelaLargura / 2F + (float)((TelaLargura * 60 / 100) / 1.70F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Top = (TelaAltura / 3.5F) + (float)((TelaLargura * 60 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                        rect.Bottom = TelaAltura / 3.5F + (float)((TelaLargura * 60 / 100) / 1.70 * Math.Cos(loop * 6 * Math.PI / 240));
                    }
                    if (loop <= VelocidadeAtual - 20) {
                        cor = PonteiroCorEnum.Verde;
                    }
                    if (loop <= VelocidadeRadar - 10) {
                        cor = PonteiroCorEnum.Cinza;
                    }
                    desenharPonteiro(rect, cor);
                }

            }
        }
        private float Resize(float input) {
            return input * density;
        }

        private float Resize(double input) {
            return Resize((float)input);
        }

		public void escreve()
		{
			Debug.WriteLine("TESTE");
		}

    }

    public enum ShapeType {
        Box,
        Circle,
        CircleIndicator
    }
}