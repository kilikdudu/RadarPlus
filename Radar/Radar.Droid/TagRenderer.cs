using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Radar.Droid;
using Android.Graphics;
using Radar.Controls;
using Radar.Model;

[assembly: ExportRenderer(typeof(Tag), typeof(TagRenderer))]

namespace Radar.Droid {
    public class TagRenderer : ViewRenderer<Tag, TagAndroid> {

        //private Velocimetro _shapeview;
        //private Canvas _canvas;

        public TagRenderer() {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Tag> e) {
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


			 TagAndroid tag = new TagAndroid(Resources.DisplayMetrics.Density, Context);
            tag.tag = Element;
            tag.tag.desenharTag += tag.desenharTag;
            
            SetNativeControl(tag);
        }
    }
}