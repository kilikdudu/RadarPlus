using System;
using Android.Views;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Util;
using Radar.Controls;
using Radar.Pages;
using Radar.Model;
using System.Diagnostics;
using Radar.Estilo;

namespace Radar.Droid {
    /// <summary>
    /// This is our class responsible for drawing our shapes
    /// </summary>
    public class VelocimetroAndroid : View {

        private Canvas _canvas;
        public Velocimetro velocimetro { get; set; }

        public VelocimetroAndroid(float density, Context context) : base(context) {
        }


        protected override void OnDraw(Canvas canvas) {
            _canvas = canvas;
            base.OnDraw(canvas);
            velocimetro.desenhar();
            //HandleShapeDraw(canvas);
        }

        private Color pegarCor(PonteiroCorEnum cor) {
            Color retorno;
            switch (cor)
            {
                case PonteiroCorEnum.Verde:
                    retorno = EstiloUtils.Velocimentro.TextoCor.Verde.ToAndroid();
                    break;
                case PonteiroCorEnum.Vermelho:
                    retorno = EstiloUtils.Velocimentro.TextoCor.Vermelho.ToAndroid();
                    break;
                case PonteiroCorEnum.CinzaClaro:
                    retorno = EstiloUtils.Velocimentro.TextoCor.CinzaClaro.ToAndroid();
                    break;
                default:
                    retorno = EstiloUtils.Velocimentro.TextoCor.Padrao.ToAndroid();
                    break;
            }
            return retorno;
        }

        public void desenharTexto(string Texto, float x, float y, PonteiroCorEnum cor) {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Fill);
            strokePaint.StrokeWidth = 3;
            strokePaint.Color = pegarCor(cor);
            if (TelaAndroid.Largura > TelaAndroid.Altura) {
                float testTextSize = 7f;
                float desiredTextSize = (float)(TelaAndroid.Altura * 30 / 100) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            } else {
                float testTextSize = 5f;
                float desiredTextSize = (float)(TelaAndroid.Largura * 30 / 100) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            }
            _canvas.DrawText(Texto, x, y, strokePaint);
        }

        public void desenharTextoVelocidade(string Texto, float x, float y, PonteiroCorEnum cor) {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Fill);
            strokePaint.StrokeWidth = 3;
			float tamanhoTexto = 0;
            strokePaint.Color = pegarCor(cor);
            if (TelaAndroid.Largura > TelaAndroid.Altura) {
                float testTextSize = 5.3f;
                float desiredTextSize = (float)(TelaAndroid.Altura * 45 / 100) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
				tamanhoTexto = strokePaint.MeasureText(Texto);
            } else {
                float testTextSize = 4f;
                float desiredTextSize = (float)(TelaAndroid.Largura * 45 / 100) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
				tamanhoTexto = strokePaint.MeasureText(Texto);
            }
			if (this.Width > this.Height)
			{
				_canvas.DrawText(Texto, (TelaAndroid.Altura - tamanhoTexto) / 2, y, strokePaint);
			}
			else {
				_canvas.DrawText(Texto, (TelaAndroid.Largura - tamanhoTexto) / 2, y, strokePaint);
			}
        }

        public void desenharTextoLabel(string Texto, float x, float y, PonteiroCorEnum cor) {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Fill);
            strokePaint.StrokeWidth = 3F;
            strokePaint.Color = pegarCor(cor);
            if (TelaAndroid.Largura > TelaAndroid.Altura) {
                float testTextSize = 5.5f;
                float desiredTextSize = (float)(TelaAndroid.Altura * 39 / 100) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            } else {
                float testTextSize = 5f;
                float desiredTextSize = (float)(TelaAndroid.Largura * 39 / 100) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            }
            _canvas.DrawText(Texto, x, y, strokePaint);
        }

        public new int Width
        {
			get { return base.Width - (int)(this.velocimetro.Padding.HorizontalThickness); }
        }


        public new int Height
        {
			get { return base.Height - (int)(this.velocimetro.Padding.VerticalThickness); }
        }

        /*
        public float pegarAlturaTela() {
            float altura;
            if (this.Width > this.Height) {
                altura = Resources.DisplayMetrics.HeightPixels;
            } else {
                altura = Resources.DisplayMetrics.HeightPixels;
            }
           
            return altura;
        }
        public float pegarLarguraTela() {
            float largura;
            if (this.Width > this.Height) {
                largura = Resources.DisplayMetrics.WidthPixels;
            } else {
                largura = Resources.DisplayMetrics.WidthPixels;
            }
           
            return largura;
        }
        */

        public void desenharPonteiro(RetanguloInfo rect, PonteiroCorEnum cor) {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Stroke);
            strokePaint.StrokeWidth = 6;
            //strokePaint.StrokeCap = Paint.Cap.Round;
            //strokePaint.Color = Color.Blue;
            switch (cor) {
                case PonteiroCorEnum.Verde:
                    strokePaint.Color = EstiloUtils.Velocimentro.PonteiroCor.Verde.ToAndroid();
                    break;
                case PonteiroCorEnum.Vermelho:
                    strokePaint.Color = EstiloUtils.Velocimentro.PonteiroCor.Vermelho.ToAndroid();
                    break;
				case PonteiroCorEnum.CinzaClaro:
					strokePaint.Color = EstiloUtils.Velocimentro.PonteiroCor.CinzaClaro.ToAndroid();
					break;
                default:
                    strokePaint.Color = EstiloUtils.Velocimentro.PonteiroCor.Padrao.ToAndroid();
                    break;
            }

            _canvas.DrawLine(
                rect.Left,
                rect.Top,
                rect.Right,
                rect.Bottom,
                strokePaint
            );
        }

      
    }
}