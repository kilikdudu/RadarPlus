using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Radar.Droid;
using Android.Graphics;
using Radar.Droid;
using Radar.Controls;
using Radar.Model;

[assembly: ExportRenderer(typeof(Velocimetro), typeof(VelocimetroRenderer))]

namespace Radar.Droid {
    public class VelocimetroRenderer : ViewRenderer<Velocimetro, VelocimetroAndroid> {

        //private Velocimetro _shapeview;
        //private Canvas _canvas;

        public VelocimetroRenderer() {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Velocimetro> e) {
            base.OnElementChanged(e);

            //if (e.OldElement != null || this.Element == null)
            //    return;

            /*
            if (e.NewElement != null) {
                _shapeview = e.NewElement;
                //_shapeview.desenharTexto += desenharTexto;
                //_shapeview.desenharPonteiro += desenharPonteiro;
            }
            */
            //SetNativeControl(this);
            VelocimetroAndroid velocimentro = new VelocimetroAndroid(Resources.DisplayMetrics.Density, Context);
            velocimentro.velocimetro = Element;
            velocimentro.velocimetro.desenharPonteiro += velocimentro.desenharPonteiro;
            velocimentro.velocimetro.desenharTexto += velocimentro.desenharTexto;
            velocimentro.velocimetro.desenharTextoVelocidade += velocimentro.desenharTextoVelocidade;
            velocimentro.velocimetro.desenharTextoLabel += velocimentro.desenharTextoLabel;
            //velocimentro.velocimetro.pegarAlturaTela += velocimentro.pegarAlturaTela;
            //velocimentro.velocimetro.pegarLarguraTela += velocimentro.pegarLarguraTela;
            velocimentro.velocimetro.redesenhar += velocimentro.Invalidate;
            SetNativeControl(velocimentro);
        }
    }
}