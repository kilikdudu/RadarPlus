using System;
using Android.Views;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Util;
using Radar;
using Radar.Controls;

namespace Radar.droid {
    /// <summary>
    /// This is our class responsible for drawing our shapes
    /// </summary>
    public class Shape : View {
 
        public ShapeView ShapeView { get; set; }

        Velocidades posicoes = new Velocidades();
        // Pixel density
        private readonly float density;

        public Shape(float density, Context context) : base(context) {
           
        }
        public new int Width
        {
            get { return base.Width - (int)(Resize(this.ShapeView.Padding.HorizontalThickness)); }
        }

        public new int Height
        {
            get { return base.Height - (int)(Resize(this.ShapeView.Padding.VerticalThickness)); }
        }
        protected override void OnDraw(Canvas canvas) {
            base.OnDraw(canvas);
            HandleShapeDraw(canvas);
        }
        

        protected virtual void HandleShapeDraw(Canvas canvas) {
            switch (ShapeView.ShapeType) {
                case ShapeType.Box:
                    float top = 0, bottom = 0, left = 0 , right = 0;
                    int num = 0;
                    if (posicoes.Width > posicoes.Height) {
                        Console.WriteLine("Width2: " + posicoes.Width);
                        HandleStandardDrawLabel(canvas, p => {
                            canvas.DrawText(
                                 "km/h", posicoes.Width / 3F, posicoes.Height / 1.1F, p);
                        });
                        HandleStandardDrawTextDigital(canvas, p => {
                            canvas.DrawText(
                                 posicoes.VelocidadeAtual.ToString(), posicoes.Width / 3.5F, posicoes.Height / 1.1F,
                                 p);
                        });
                    } else {
                         HandleStandardDrawTextDigital(canvas, p => {
                            canvas.DrawText(
                                 posicoes.VelocidadeAtual.ToString(), posicoes.Width / 2.3F, posicoes.Height / 2.1F,
                                 p);
                        });
                        HandleStandardDrawLabel(canvas, p => {
                            canvas.DrawText(
                                 "km/h", posicoes.Width / 2.4F, posicoes.Height / 1.8F, p);
                        });
                    }
                    for (var loop = posicoes.loopInicio; loop <= posicoes.loopFim; loop++) {
                        float tamX = 0;
                        float tamY = 0;
                      
                        if (loop % 5 == 0) {                                            
                                
                            if (posicoes.Width > posicoes.Height) {
                                tamX = posicoes.Width / 2F - (posicoes.Width * 4.2F / 100) + (float)Math.Floor(((posicoes.Width - (posicoes.Width * 64 / 100)) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240)));
                                tamY = posicoes.Height / 2F - (posicoes.Height * 0.5F / 100) + (float)Math.Floor(((posicoes.Height - (posicoes.Height * 64 / 100)) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240)));
                            } else {
                                tamX = posicoes.Width / 2F -  (posicoes.Width * 4.2F / 100) + (float)Math.Floor(((posicoes.Width - (posicoes.Width * 64 / 100)) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240)));
                                tamY = posicoes.Height / 2F - (posicoes.Height * 0.5F / 100) + (float)Math.Floor(((posicoes.Height - (posicoes.Height * 64 / 100)) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240)));
                                
                            }
                            //valor referencia var tamX =  250;
                            //valor referencia var tamY =  280;
                          
                            HandleStandardDrawText(canvas, p => {
                                canvas.DrawText(
                                     num.ToString(),tamX,tamY,
                                      p);
                                num = num + 10;
                            }, num.ToString(), loop, loop==60?60:0);
                        }
                    }
                    for (var loop = posicoes.loopInicio - 20; loop <= posicoes.loopFim - 20; loop++) {
                        //valor referencia var tamX =  350;
                        //valor referencia var tamY =  350;
                        
                        if (loop % 5 == 0) {                       
                            HandleStandardDraw(canvas, p => {
                                //var rect = new RectF(left, top, right, bottom);
                                if(this.Width > this.Height) {
                                    Console.WriteLine("Width: " + posicoes.Width);
                                    left = (posicoes.Width / 2F) + (float)((posicoes.Width * 60 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                                    right = posicoes.Width / 2F + (float)((posicoes.Width * 60 / 100) / 1.90F * Math.Sin(loop * 6 * Math.PI / 240));
                                    top = (posicoes.Height / 2F) + (float)((posicoes.Width * 60 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                                    bottom = posicoes.Height / 2F + (float)((posicoes.Width * 60 / 100) / 1.90 * Math.Cos(loop * 6 * Math.PI / 240));

                                } else {
                                    left   = (posicoes.Width / 2F) + (float)((posicoes.Width * 60 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                                    right  = posicoes.Width / 2F + (float)((posicoes.Width * 60 / 100) / 1.90F * Math.Sin(loop * 6 * Math.PI / 240));
                                    top    = (posicoes.Height / 2F) + (float)((posicoes.Width * 60 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                                    bottom = posicoes.Height / 2F + (float)((posicoes.Width * 60 / 100) / 1.90 * Math.Cos(loop * 6 * Math.PI / 240));
                                }
                                canvas.DrawLine(
                                    left,
                                    top,
                                    right,
                                    bottom,
                                    p);
                            },loop, loop==40?60:0);
                        }else {
                            HandleStandardDraw(canvas, p => {
                                if(posicoes.Width > posicoes.Height) {
                                    left = (posicoes.Width / 2F) + (float)((posicoes.Width * 10 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                                    right = posicoes.Width / 2F + (float)((posicoes.Width * 10 / 100) / 1.70F * Math.Sin(loop * 6 * Math.PI / 240));
                                    top = (posicoes.Height / 2F) + (float)((posicoes.Width * 10 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                                    bottom = posicoes.Height / 2F + (float)((posicoes.Width * 10 / 100) / 1.70 * Math.Cos(loop * 6 * Math.PI / 240));
                                } else {
                                    left = (posicoes.Width / 2F) + (float)((posicoes.Width * 60 / 100) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                                    right = posicoes.Width / 2F + (float)((posicoes.Width * 60 / 100) / 1.70F * Math.Sin(loop * 6 * Math.PI / 240));
                                    top = (posicoes.Height / 2F) + (float)((posicoes.Width * 60 / 100) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                                    bottom = posicoes.Height / 2F + (float)((posicoes.Width * 60 / 100) / 1.70 * Math.Cos(loop * 6 * Math.PI / 240));
                                }
                                canvas.DrawLine(
                                    left,
                                    top,
                                    right,
                                    bottom,
                                    p);
                            },loop, -1);
                        }
                        
                       
                    }
                  
                    break;
            }
        }
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
    }
}