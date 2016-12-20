using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Radar.Controls;
using Radar.iOS;
using System.Drawing;
using CoreGraphics;
using UIKit;
using Radar.Model;
using Foundation;
using System.Collections.Generic;
using Radar.Utils;

namespace Radar.iOS
{
	public class TagiOS : UIView
	{
		public Tag tag { get; set; }
		public CGContext _canvas;
		public CGRect _rect;
		public TagiOS()
		{
			
		}

		public void desenharTag(Xamarin.Forms.Color cor)
		{

			CGColor adColor = cor.ToCGColor();
			_canvas = UIGraphics.GetCurrentContext();
			var x = (float)UIScreen.MainScreen.Bounds.Width / 2;
			var y = (float)UIScreen.MainScreen.Bounds.Height / 2;
			var radius = (float)UIScreen.MainScreen.Bounds.Width - 10 / 2;
			//_canvas.AddArc( x , y, radius , (float)0, (float)(Math.PI * 2) , true);
			//_canvas.AddArc (150, 60, 30, 0, (float)Math.PI / 2, false);
			var vc = new CGPath();
			vc.AddArc(x, y, 120, (float)0, (float)(Math.PI * 2), true);
			_canvas.SetLineWidth(10);
			_canvas.SetFillColor(adColor);
			_canvas.SetStrokeColor(adColor);
			//_canvas.AddArc(150, 60, 30, 0, (float)Math.PI / 2, false);
			_canvas.AddPath(vc);
			_canvas.DrawPath(CoreGraphics.CGPathDrawingMode.FillStroke);

		}		  
	
		public override void Draw(CGRect rect)
		{
			base.Draw (rect);
						
			tag.desenhar();


		}


	}
}