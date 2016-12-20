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

		public static readonly BindableProperty ColorProperty = 
        BindableProperty.Create<Tag, Color>(s => s.BackGroundColor, default(Color));

		public Color BackGroundColor
		{
			get { return (Color)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}

		public delegate void desenharTagHandler(Color cor);
		public desenharTagHandler desenharTag;


		public void desenhar()
		{
			//this.BackgroundColor = Color.Red;
			desenharTag(BackGroundColor);
			
			

		}

		

	}

}