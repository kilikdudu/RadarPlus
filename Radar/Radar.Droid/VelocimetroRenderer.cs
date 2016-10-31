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
    public class VelocimetroRenderer : ViewRenderer<Velocimetro, VelocimentoAndroid> {

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
            VelocimentoAndroid velocimentro = new VelocimentoAndroid(Resources.DisplayMetrics.Density, Context);
            velocimentro.ShapeView = Element;
            velocimentro.ShapeView.desenharPonteiro += velocimentro.desenharPonteiro;
            velocimentro.ShapeView.desenharTexto += velocimentro.desenharTexto;
            velocimentro.ShapeView.desenharTextoVelocidade += velocimentro.desenharTextoVelocidade;
            velocimentro.ShapeView.desenharTextoLabel += velocimentro.desenharTextoLabel;
            velocimentro.ShapeView.pegarAlturaTela += velocimentro.pegarAlturaTela;
            velocimentro.ShapeView.pegarLarguraTela += velocimentro.pegarLarguraTela;
            velocimentro.ShapeView.redesenhar += velocimentro.Invalidate;
            SetNativeControl(velocimentro);
        }
    }
}