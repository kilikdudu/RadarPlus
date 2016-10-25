using System;
using Android.Views;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Util;
using Radar;

namespace Radar.droid {
    /// <summary>
    /// This is our class responsible for drawing our shapes
    /// </summary>
    public class Shape : View {
        int radar = 60;
        int velocidadeAtual = 40;
        private readonly float QuarterTurnCounterClockwise = -90;

        public ShapeView ShapeView { get; set; }

        // Pixel density
        private readonly float density;

        // We need to make sure we account for the padding changes
        public new int Width
        {
            get { return base.Width - (int)(Resize(this.ShapeView.Padding.HorizontalThickness)); }
        }

        public new int Height
        {
            get { return base.Height - (int)(Resize(this.ShapeView.Padding.VerticalThickness)); }
        }

        public Shape(float density, Context context) : base(context) {
            this.density = density;
        }

        public Shape(float density, Context context, IAttributeSet attributes) : base(context, attributes) {
            this.density = density;
        }

        public Shape(float density, Context context, IAttributeSet attributes, int defStyle) : base(context, attributes, defStyle) {
            this.density = density;
        }

        protected override void OnDraw(Canvas canvas) {
            base.OnDraw(canvas);
            HandleShapeDraw(canvas);
        }
        

        protected virtual void HandleShapeDraw(Canvas canvas) {
            switch (ShapeView.ShapeType) {
                case ShapeType.Box:
                    Console.WriteLine("X: " + GetX() + this.Width);
                    float top, bottom , left , right;
                    int num = 0;
                    if (this.Width > this.Height) {
                        HandleStandardDrawLabel(canvas, p => {
                            canvas.DrawText(
                                 "km/h", this.Width / 4.7F + 0, this.Height / 1.5F, p);
                        });
                        HandleStandardDrawTextDigital(canvas, p => {
                            canvas.DrawText(
                                 velocidadeAtual.ToString(), this.Width / 4.6F + 0, this.Height / 1.7F,
                                 p);
                        });
                    } else {
                        HandleStandardDrawLabel(canvas, p => {
                            canvas.DrawText(
                                 "km/h", this.Width / 2.5F + 0, this.Height / 3, p);
                        });
                        HandleStandardDrawTextDigital(canvas, p => {
                            canvas.DrawText(
                                 velocidadeAtual.ToString(), this.Width / 2.35F + 0, this.Height / 3.7F,
                                 p);
                        });
                    }
                    for (var loop = 30; loop <= 90; loop++) {
                        float width = 0;
                        float height = 0;
                        float tamX = 0;
                        float tamY = 0;
                      
                        if (loop % 5 == 0) {                                            
                                
                            if (this.Width > this.Height) {
                                width = (float)this.Width / 4F;
                                height = (float)this.Height / 1.8F;
                                tamX = width - 15 + (float)((this.Width - (this.Width * 82 / 100)) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                                tamY = height + (float)((this.Height - (this.Height * 52 / 100)) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                            } else {
                                width = (float)this.Width / 2F;
                                height = (float)this.Height / 3.5F;
                                tamX = width - Resize(15) + (float)Math.Floor(((this.Width - (this.Width * 65 / 100)) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240)));
                                tamY = height - Resize(1) + (float)Math.Floor(((this.Height - (this.Height * 75 / 100)) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240)));
                                
                            }
                            //valor referencia var tamX =  250;
                            //valor referencia var tamY =  280;
                          
                            HandleStandardDrawText(canvas, p => {
                                canvas.DrawText(
                                     num.ToString(),tamX,tamY,
                                     //width - 15 + (float)(tamX / 1.50F * Math.Cos(loop * 6 * Math.PI / 240)),
                                     //height + (float)(tamY / 1.50F * Math.Sin(loop * 6 * Math.PI / 240)),
                                     p);
                                num = num + 10;
                            }, num.ToString(), loop, loop==60?60:0);
                        }
                    }
                    for (var loop = 10; loop <= 70; loop++) {
                        float width = 0;
                        float height = 0;
                        float tamX = 0;
                        //valor referencia var tamX =  350;
                        //valor referencia var tamY =  350;
                        
                        if (loop % 5 == 0) {                       
                            HandleStandardDraw(canvas, p => {
                                //var rect = new RectF(left, top, right, bottom);
                                if(this.Width > this.Height) {
                                    width = this.Width / 4;
                                    height = this.Height / 1.8F;
                                    tamX = this.Width - (float)(this.Width * 70 / 100);
                                    left = width + (float)(tamX / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                                    right = width + (float)(tamX / 1.90F * Math.Sin(loop * 6 * Math.PI / 240));
                                    top = height + (float)(tamX / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                                    bottom = height + (float)(tamX / 1.90 * Math.Cos(loop * 6 * Math.PI / 240));

                                } else {
                                    width = this.Width / 2;
                                    height = (this.Height / 4) + 20;
                                    tamX = this.Width - (float)(this.Width * 41.6 / 100);
                                    left = width + (float)(Math.Floor(tamX) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                                    right = width + (float)(Math.Floor(tamX) / 1.90F * Math.Sin(loop * 6 * Math.PI / 240));
                                    top = height + (float)(Math.Floor(tamX) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                                    bottom = height + (float)(Math.Floor(tamX) / 1.90 * Math.Cos(loop * 6 * Math.PI / 240));

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
                                if(this.Width > this.Height) {
                                    width = this.Width / 4;
                                    height = this.Height / 1.8F;
                                    tamX = this.Width - (float)(this.Width * 70 / 100);
                                    left = width + (float)(tamX / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                                    right = width + (float)(tamX / 1.70F * Math.Sin(loop * 6 * Math.PI / 240));
                                    top = height + (float)(tamX / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                                    bottom = height + (float)(tamX / 1.70 * Math.Cos(loop * 6 * Math.PI / 240));

                                } else {
                                    width = this.Width / 2;
                                    height = (this.Height / 4) + 20;
                                    tamX = this.Width - (float)(this.Width * 41.6 / 100);
                                    left = width + (float)(Math.Floor(tamX) / 1.50F * Math.Sin(loop * 6 * Math.PI / 240));
                                    right = width + (float)(Math.Floor(tamX) / 1.70F * Math.Sin(loop * 6 * Math.PI / 240));
                                    top = height + (float)(Math.Floor(tamX) / 1.50F * Math.Cos(loop * 6 * Math.PI / 240));
                                    bottom = height + (float)(Math.Floor(tamX) / 1.70 * Math.Cos(loop * 6 * Math.PI / 240));

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

        /// <summary>
        /// A simple method that handles drawing our shape with the various colours we need
        /// </summary>
        /// <param name="canvas">Canvas.</param>
        /// <param name="drawShape">Draw shape.</param>
        /// <param name="lineWidth">Line width.</param>
        /// <param name="drawFill">If set to <c>true</c> draw fill.</param>
        
        protected virtual void HandleStandardDraw(Canvas canvas, Action<Paint> drawShape, int velocidade, int velocidadeRadar) {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Stroke);
            strokePaint.StrokeWidth = 6;
            //strokePaint.StrokeCap = Paint.Cap.Round;
            strokePaint.Color = Color.Blue;
            if (velocidadeRadar == radar) {
                             
                strokePaint.Color = Color.Red;
            }
            velocidade = velocidade - 10;
            if (velocidade >= velocidadeAtual) {

                strokePaint.Color = Color.Green;
            }
           
            drawShape(strokePaint);
        }

        protected virtual void HandleStandardDrawText(Canvas canvas, Action<Paint> drawShape, String num, int velocidade, int velocidadeRadar) {
            var strokePaint = new Paint(PaintFlags.AntiAlias);
            strokePaint.SetStyle(Paint.Style.Stroke);
            strokePaint.StrokeWidth = 3;
            strokePaint.Color = Color.Blue;
            if (velocidadeRadar == radar) {

                strokePaint.Color = Color.Red;
            }
            velocidade = velocidade - 30;
            if (velocidade <= velocidadeAtual - 20) {

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