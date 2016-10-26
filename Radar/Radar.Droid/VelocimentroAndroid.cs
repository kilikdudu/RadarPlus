using System;
using Android.Views;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Util;
using Radar.Controls;
using Radar.Pages;
using Radar.Model;

namespace Radar.Droid {
    /// <summary>
    /// This is our class responsible for drawing our shapes
    /// </summary>
    public class VelocimentoAndroid : View {

        private Canvas _canvas;
        public Velocimetro ShapeView { get; set; }

        public VelocimentoAndroid(float density, Context context) : base(context) {

        }


        protected override void OnDraw(Canvas canvas) {
            _canvas = canvas;
            base.OnDraw(canvas);
            ShapeView.desenhar();
            //HandleShapeDraw(canvas);
        }

        public void desenharTexto(string Texto, float x, float y)
        {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Fill);
            strokePaint.StrokeWidth = 3;
            strokePaint.Color = Android.Graphics.Color.Blue;
            // Calculate the desired size as a proportion of our testTextSize.
            if (this.Width > this.Height)
            {
                float testTextSize = 4f;
                float desiredTextSize = (float)(this.Height - (this.Height * 62.6 / 100)) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            }
            else {
                float testTextSize = 6f;
                float desiredTextSize = (float)(this.Width - (this.Width * 50.6 / 100)) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            }
            _canvas.DrawText(Texto, x, y, strokePaint);
        }

        public void desenharPonteiro(RetanguloInfo rect, PonteiroCorEnum cor)
        {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Stroke);
            strokePaint.StrokeWidth = 6;
            //strokePaint.StrokeCap = Paint.Cap.Round;
            strokePaint.Color = Android.Graphics.Color.Blue;
            switch (cor)
            {
                case PonteiroCorEnum.Verde:
                    strokePaint.Color = Android.Graphics.Color.Green;
                    break;
                case PonteiroCorEnum.Vermelho:
                    strokePaint.Color = Android.Graphics.Color.Red;
                    break;
                default:
                    strokePaint.Color = Android.Graphics.Color.Blue;
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

        /*
        protected virtual void HandleStandardDraw(Canvas canvas, Action<Paint> drawShape, int velocidade, int velocidadeRadar) {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Stroke);
            strokePaint.StrokeWidth = 6;
            //strokePaint.StrokeCap = Paint.Cap.Round;
            strokePaint.Color = Color.Blue;
            if (velocidadeRadar == posicoes.VelocidadeRadar ) {
                             
                strokePaint.Color = Color.Red;
            }
            velocidade = velocidade - 10;
            if (velocidade >= posicoes.VelocidadeAtual) {

                strokePaint.Color = Color.Green;
            }
           
            drawShape(strokePaint);
        }

        protected virtual void HandleStandardDrawText(Canvas canvas, Action<Paint> drawShape, String num, int velocidade, int velocidadeRadar) {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Stroke);
            strokePaint.StrokeWidth = 3;
            strokePaint.Color = Color.Blue;
            if (velocidadeRadar == posicoes.VelocidadeRadar) {

                strokePaint.Color = Color.Red;
            }
            velocidade = velocidade - 30;
            if (velocidade <= posicoes.VelocidadeAtual - 20) {

                strokePaint.Color = Color.Green;
            }

            float testTextSize = 8f;

            // Calculate the desired size as a proportion of our testTextSize.
            if (this.Width > this.Height) {
                float desiredTextSize = (float)(this.Height - (this.Height * 50.6 / 100)) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            } else{
                float desiredTextSize = (float)(this.Width - (this.Width * 50.6 / 100)) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            }
            
            drawShape(strokePaint);
        }
        protected virtual void HandleStandardDrawTextDigital(Canvas canvas, Action<Paint> drawShape) {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Fill);
            strokePaint.StrokeWidth = 3;
            strokePaint.Color = Color.Blue;
            // Calculate the desired size as a proportion of our testTextSize.
            if (this.Width > this.Height) {
                float testTextSize = 2.5f;
                float desiredTextSize = (float)(this.Height - (this.Height * 60.6 / 100)) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            } else {
                float testTextSize = 4f;
                float desiredTextSize = (float)(this.Width - (this.Width * 50.6 / 100)) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            }

            drawShape(strokePaint);
        }
        protected virtual void HandleStandardDrawLabel(Canvas canvas, Action<Paint> drawShape) {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Fill);
            strokePaint.StrokeWidth = 3;
            strokePaint.Color = Color.Blue;
            // Calculate the desired size as a proportion of our testTextSize.
            if (this.Width > this.Height) {
                float testTextSize = 4f;
                float desiredTextSize = (float)(this.Height - (this.Height * 62.6 / 100)) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            } else {
                float testTextSize = 6f;
                float desiredTextSize = (float)(this.Width - (this.Width * 50.6 / 100)) / testTextSize;
                strokePaint.TextSize = desiredTextSize;
            }
            drawShape(strokePaint);
        }
        // Helper functions for dealing with pizel density
        private float Resize(float input) {
            return input * density;
        }

        private float Resize(double input) {
            return Resize((float)input);
        }
        */
    }
}