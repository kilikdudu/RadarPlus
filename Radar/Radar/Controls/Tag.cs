using Radar.BLL;
using Radar.Model;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Utils;

namespace Radar.Controls
{
	public class Tag : BoxView
	{
		public Tag()
		{
			//WidthRequest = 480;
			//HeightRequest = 640;
		}

		public static readonly BindableProperty ShapeTypeProperty = BindableProperty.Create<Tag, TipoShape> (s => s.TipoShape, TipoShape.Box);

		public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create<Tag, Color> (s => s.StrokeColor, Color.Default);

		public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create<Tag, float> (s => s.StrokeWidth, 1f);

		public static readonly BindableProperty IndicatorPercentageProperty = BindableProperty.Create<Tag, float> (s => s.IndicatorPercentage, 0f);

		public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create<Tag, float> (s => s.CornerRadius, 0f);

		public static readonly BindableProperty PaddingProperty = BindableProperty.Create<Tag, Thickness> (s => s.Padding, default(Thickness));

		public static readonly BindableProperty ColorProperty = BindableProperty.Create<Tag, Color>(s => s.BackGroundColor, default(Color));

		public Color BackGroundColor
		{
			get { return (Color)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}
		public TipoShape TipoShape {
			get{ return (TipoShape)GetValue (ShapeTypeProperty); }
			set{ SetValue (ShapeTypeProperty, value); }
		}

		public Color StrokeColor {
			get{ return (Color)GetValue (StrokeColorProperty); }
			set{ SetValue (StrokeColorProperty, value); }
		}

		public float StrokeWidth {
			get{ return (float)GetValue (StrokeWidthProperty); }
			set{ SetValue (StrokeWidthProperty, value); }
		}

		public float IndicatorPercentage {
			get{ return (float)GetValue (IndicatorPercentageProperty); }
			set {
				if (TipoShape != TipoShape.CircleIndicator)
					throw new ArgumentException ("Can only specify this property with CircleIndicator");
				SetValue (IndicatorPercentageProperty, value);
			}
		}

		public float CornerRadius {
			get{ return (float)GetValue (CornerRadiusProperty); }
			set {
				if (TipoShape != TipoShape.Box)
					throw new ArgumentException ("Can only specify this property with Box");
				SetValue (CornerRadiusProperty, value);
			}
		}

		public Thickness Padding {
			get{ return (Thickness)GetValue (PaddingProperty); }
			set{ SetValue (PaddingProperty, value); }
		}

		
		public delegate void desenharTagHandler(Color cor);
		public desenharTagHandler desenharTag;


		public void desenhar()
		{
			//this.BackgroundColor = Color.Red;
			desenharTag(BackGroundColor);
			
			

		}

		

	}
	public enum TipoShape
	{
		Box,
		Circle,
		CircleIndicator
	}

}