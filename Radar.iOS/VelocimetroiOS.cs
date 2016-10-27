using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Radar.Controls;
using Radar.iOS;
using System.Drawing;
using CoreGraphics;
using UIKit;
using Radar.Model;


namespace Radar.iOS
{
	public class VelocimetroiOS : UIView
	{
		public Velocimetro ShapeView { get; set; }
		public VelocimetroiOS()
		{
			//if (UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.Portrait)
			//{
			//	Console.WriteLine("Width+ :" + UIScreen.MainScreen.Bounds.Width);
			//}
			//else {
			//	Console.WriteLine("Height+ :" + UIScreen.MainScreen.Bounds.Height);
			//}
		}

		public override void Draw(CGRect rect)
		{
			ShapeView.desenhar();
		}

		/*
		public int Width
		{
			get { return (int)rectMaster.Width;  }
		}

		public int Height
		{
			get { return (int)rectMaster.Height; }
		}
		*/
		public float pegarAlturaTela()
		{
			
			var orientation = UIApplication.SharedApplication.StatusBarOrientation;
			if (orientation == UIInterfaceOrientation.LandscapeLeft
			|| orientation == UIInterfaceOrientation.LandscapeRight)
			{
				Console.WriteLine("Width+ :" + UIScreen.MainScreen.Bounds.Width);
			}
			else 
			{
				Console.WriteLine("Width+ :" + UIScreen.MainScreen.Bounds.Width);
			}
				float altura;
			if (UIScreen.MainScreen.Bounds.Width > UIScreen.MainScreen.Bounds.Height)
			{
				altura = (float)UIScreen.MainScreen.Bounds.Height;
			}
			else {
				altura = (float)UIScreen.MainScreen.Bounds.Height;
			}
			Console.WriteLine("altura: " + altura);
			return altura;
		}
		public float pegarLarguraTela()
		{
			float largura;
		if (UIScreen.MainScreen.Bounds.Width > UIScreen.MainScreen.Bounds.Height)
				{
				largura = (float)UIScreen.MainScreen.Bounds.Width;
			}
			else {
				largura = (float)UIScreen.MainScreen.Bounds.Width;
			}
			Console.WriteLine("largura: " + largura);
			return largura;
		}
		public void desenharPonteiro(RetanguloInfo rect, PonteiroCorEnum cor)
		{
			var currentContext = UIGraphics.GetCurrentContext();
			currentContext.SetLineWidth(3);
			currentContext.SetFillColor(UIColor.Red.CGColor);
			currentContext.SetStrokeColor(UIColor.Red.CGColor);

			currentContext.MoveTo(rect.Left, rect.Top);
			currentContext.AddLineToPoint(rect.Right, rect.Bottom);
			currentContext.TranslateCTM(0, Bounds.Height);
			currentContext.ScaleCTM(1, -1);
			currentContext.DrawPath(CoreGraphics.CGPathDrawingMode.FillStroke);


		}

		public void desenharTexto(string Texto, float x, float y, PonteiroCorEnum cor)
		{
			
		}

		public void desenharTextoVelocidade(string Texto, float x, float y)
		{
			
		}
		public void desenharTextoLabel(string Texto, float x, float y)
		{
			var currentContext = UIGraphics.GetCurrentContext();
			currentContext.SelectFont("Arial", 16f, CGTextEncoding.MacRoman);
			currentContext.SetTextDrawingMode(CGTextDrawingMode.Fill);
			currentContext.SetFillColor(UIColor.Red.CGColor);
			currentContext.TranslateCTM(0, Bounds.Height);
			currentContext.ScaleCTM(1, -1);
			currentContext.ShowTextAtPoint(x - 10, y, Texto);

			currentContext.DrawPath(CoreGraphics.CGPathDrawingMode.FillStroke);

		}

	}
}