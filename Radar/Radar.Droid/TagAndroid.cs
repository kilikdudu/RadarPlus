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

namespace Radar.Droid
{
	/// <summary>
	/// This is our class responsible for drawing our shapes
	/// </summary>
	public class TagAndroid : View
	{

		public Tag tag { get; set; }
		private Canvas _canvas;
		/*
		Path path = new Path();
		private readonly PointF[] _points = new[]
												{
												new PointF(100, 100),
												new PointF(200, 200),
												new PointF(200, 500),
												new PointF(600, 600),
												new PointF(200, 200),
												new PointF(100, 100)
											};
		*/
		public TagAndroid(float density, Context context) : base(context)
		{
		}

		public void desenharTag(Xamarin.Forms.Color cor)
		{
		/*	
			path.MoveTo(_points[0].X, _points[0].Y);
			for (var i = 1; i < _points.Length; i++)
			{
				path.LineTo(_points[i].X, _points[i].Y);
			}
		*/
			var paint = new Paint();
			Android.Graphics.Color adColor = cor.ToAndroid();
				paint.Color = adColor;
			
			// We can use Paint.Style.Stroke if we want to draw a "hollow" polygon,
			// But then we had better set the .StrokeWidth property on the paint.
			paint.SetStyle(Paint.Style.Fill);
			Path path2 = new Path();
			path2.MoveTo(100, 100);
			path2.MoveTo(200, 200);
			path2.MoveTo(200, 500);
			path2.MoveTo(600, 600);
			path2.MoveTo(200, 200);
			path2.MoveTo(100, 100);
			
			
			paint.AntiAlias = true;
			_canvas.DrawCircle(base.Width / 2, base.Height / 2, (base.Width - 10) / 2, paint);
			
		}
		protected override void OnDraw(Canvas canvas)
		{
			_canvas = canvas;
			base.OnDraw(canvas);
			 tag.desenhar();
			
		}
	}
}