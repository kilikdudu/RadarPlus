using Radar.Model;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Radar.Controls
{
    public class Velocimetro : BoxView
    {
        public const int _loopInicio = 30;
        public const int _loopFim = 90;

        private float velocidadeAtual;
        public float VelocidadeAtual
        {
            get { return 40; }
            set { velocidadeAtual = 40; }
        }
        private float velocidadeRadar;
        public float VelocidadeRadar
        {
            get { return 60; }
            set { velocidadeAtual = 60; }
        }

        public float TelaLargura
        {
            get { return (float)App.Current.MainPage.Width; }
        }

        public float TelaAltura
        {
            get { return (float)App.Current.MainPage.Width; }
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

        public delegate void desenharTextoHandler(string Texto, float x, float y);
        public desenharTextoHandler desenharTexto;

        public delegate void desenharPonteiroHandler(RetanguloInfo rect, PonteiroCorEnum cor);
        public desenharPonteiroHandler desenharPonteiro;

        public void desenhar()
        {
            float top = 0, bottom = 0, left = 0, right = 0;
            int num = 0;
            if (TelaLargura > TelaAltura)
            {
                //Debug.WriteLine("Width2: " + TelaLargura);
                desenharTexto("km/h", TelaLargura / 3F, TelaAltura / 1.1F);
                /*
                HandleStandardDrawTextDigital(canvas, p =>
                {
                    canvas.DrawText(
                         posicoes.VelocidadeAtual.ToString(), TelaLargura / 3.5F, TelaAltura / 1.1F,
                         p);
                });
                */
            }
            else {
                /*
                HandleStandardDrawTextDigital(canvas, p =>
                {
                    canvas.DrawText(
                         posicoes.VelocidadeAtual.ToString(), TelaLargura / 2.3F, TelaAltura / 2.1F,
                         p);
                });
                HandleStandardDrawLabel(canvas, p =>
                {
                    canvas.DrawText(
                         "km/h", TelaLargura / 2.4F, TelaAltura / 1.8F, p);
                });
                */
            }
            for (var loop = _loopInicio; loop <= _loopFim; loop++)
            {
                float tamX = 0;
                float tamY = 0;

                if (loop % 5 == 0)
                {

                    if (TelaLargura > TelaAltura)
                    {
                        tamX = TelaLargura / 2F - (TelaLargura * 4.2F / 100) + (float)Math.Floor(((TelaLargura - (TelaLargura * 64 / 100)) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240)));
                        tamY = TelaAltura / 2F - (TelaAltura * 0.5F / 100) + (float)Math.Floor(((TelaAltura - (TelaAltura * 64 / 100)) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240)));
                    }
                    else {
                        tamX = TelaLargura / 2F - (TelaLargura * 4.2F / 100) + (float)Math.Floor(((TelaLargura - (TelaLargura * 64 / 100)) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240)));
                        tamY = TelaAltura / 2F - (TelaAltura * 0.5F / 100) + (float)Math.Floor(((TelaAltura - (TelaAltura * 64 / 100)) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240)));

                    }
                    //valor referencia var tamX =  250;
                    //valor referencia var tamY =  280;

                    desenharTexto(num.ToString(), tamX, tamY);
                    num = num + 10;
                    /*
                    HandleStandardDrawText(canvas, p =>
                    {
                        canvas.DrawText(
                             num.ToString(), tamX, tamY,
                              p);
                        num = num + 10;
                    }, num.ToString(), loop, loop == 60 ? 60 : 0);
                    */
                }
            }
            for (var loop = _loopInicio - 20; loop <= _loopFim - 20; loop++)
            {
                //valor referencia var tamX =  350;
                //valor referencia var tamY =  350;

                RetanguloInfo rect = new RetanguloInfo();
                PonteiroCorEnum cor = PonteiroCorEnum.Cinza;
                if (loop % 5 == 0)
                {
                    if (this.Width > this.Height)
                    {
                        Debug.WriteLine("Width: " + TelaLargura);
                        rect.Left = (TelaLargura / 2F) + (float)((TelaLargura * 60 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Right = TelaLargura / 2F + (float)((TelaLargura * 60 / 100) / 1.90F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Top = (TelaAltura / 2F) + (float)((TelaLargura * 60 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                        rect.Bottom = TelaAltura / 2F + (float)((TelaLargura * 60 / 100) / 1.90 * Math.Cos(loop * 6 * Math.PI / 240));

                    }
                    else {
                        rect.Left = (TelaLargura / 2F) + (float)((TelaLargura * 60 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Right = TelaLargura / 2F + (float)((TelaLargura * 60 / 100) / 1.90F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Top = (TelaAltura / 2F) + (float)((TelaLargura * 60 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                        rect.Bottom = TelaAltura / 2F + (float)((TelaLargura * 60 / 100) / 1.90 * Math.Cos(loop * 6 * Math.PI / 240));
                    }
                    if (velocidadeRadar == VelocidadeRadar)
                    {
                        //strokePaint.Color = Android.Graphics.Color.Red;
                        cor = PonteiroCorEnum.Vermelho;
                    }
                    if ((VelocidadeAtual - 10) >= VelocidadeAtual)
                    {
                        cor = PonteiroCorEnum.Verde;
                    }
                    desenharPonteiro(rect, cor);
                }
                else {
                    if (TelaLargura > TelaAltura)
                    {
                        rect.Left = (TelaLargura / 2F) + (float)((TelaLargura * 10 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Right = TelaLargura / 2F + (float)((TelaLargura * 10 / 100) / 1.70F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Top = (TelaAltura / 2F) + (float)((TelaLargura * 10 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                        rect.Bottom = TelaAltura / 2F + (float)((TelaLargura * 10 / 100) / 1.70 * Math.Cos(loop * 6 * Math.PI / 240));
                    }
                    else {
                        rect.Left = (TelaLargura / 2F) + (float)((TelaLargura * 60 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Right = TelaLargura / 2F + (float)((TelaLargura * 60 / 100) / 1.70F * Math.Sin(loop * 6 * Math.PI / 240));
                        rect.Top = (TelaAltura / 2F) + (float)((TelaLargura * 60 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                        rect.Bottom = TelaAltura / 2F + (float)((TelaLargura * 60 / 100) / 1.70 * Math.Cos(loop * 6 * Math.PI / 240));
                    }
                    desenharPonteiro(rect, cor);
                }

            }
        }

        public Velocimetro()
        {
        }


    }

    public enum ShapeType
    {
        Box,
        Circle,
        CircleIndicator
    }
}