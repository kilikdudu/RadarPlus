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
			var currentContext = UIGraphics.GetCurrentContext();
			currentContext.TranslateCTM(0, Bounds.Height);
			currentContext.ScaleCTM(1f, -1f);
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
			var currentContext2 = UIGraphics.GetCurrentContext();
			currentContext2.SetLineWidth(3);
			currentContext2.SetFillColor(UIColor.Red.CGColor);
			//currentContext2.SetStrokeColor(UIColor.Red.CGColor);

			switch (cor)
			{
				case PonteiroCorEnum.Verde:
					currentContext2.SetStrokeColor(UIColor.Yellow.CGColor);
					break;
				case PonteiroCorEnum.Vermelho:
					currentContext2.SetStrokeColor(UIColor.Red.CGColor);
					break;
				case PonteiroCorEnum.CinzaClaro:
					currentContext2.SetStrokeColor(UIColor.LightGray.CGColor);
					break;
				default:
					currentContext2.SetStrokeColor(UIColor.Green.CGColor);
					break;
			}
			currentContext2.MoveTo(rect.Top, rect.Left + 185);
			currentContext2.AddLineToPoint(rect.Bottom, rect.Right + 185);

			currentContext2.DrawPath(CoreGraphics.CGPathDrawingMode.FillStroke);


		}

		public void desenharTexto(string Texto, float x, float y, PonteiroCorEnum cor)
		{
			var currentContext = UIGraphics.GetCurrentContext();
			currentContext.SelectFont("Arial", 16f, CGTextEncoding.MacRoman);
			currentContext.SetTextDrawingMode(CGTextDrawingMode.Fill);
			currentContext.SetFillColor(UIColor.Red.CGColor);

			switch (cor)
			{
				case PonteiroCorEnum.Verde:
					currentContext.SetFillColor(UIColor.Yellow.CGColor);
					break;
				case PonteiroCorEnum.Vermelho:
					currentContext.SetFillColor(UIColor.Red.CGColor);
					break;
				case PonteiroCorEnum.CinzaClaro:
					currentContext.SetFillColor(UIColor.LightGray.CGColor);
					break;
				default:
					currentContext.SetFillColor(UIColor.Green.CGColor);
					break;
			}
			currentContext.ShowTextAtPoint(y - 10, x + 200, Texto);
			currentContext.DrawPath(CoreGraphics.CGPathDrawingMode.FillStroke);
		}

		public void desenharTextoVelocidade(string Texto, float x, float y)
		{
			
			var currentContext = UIGraphics.GetCurrentContext();
			currentContext.SelectFont("Arial", 30f, CGTextEncoding.MacRoman);
			currentContext.SetTextDrawingMode(CGTextDrawingMode.Fill);
			currentContext.SetFillColor(UIColor.Green.CGColor);
			var nsText = new NSString(Texto);
			var boundSize = new SizeF((float)x, float.MaxValue);
			var options = NSStringDrawingOptions.UsesFontLeading |
						  NSStringDrawingOptions.UsesLineFragmentOrigin;

		
			var attributes = new UIStringAttributes
			{
				Font = UIFont.FromName("Arial", (float)30)
			};

			var sizeF = nsText.GetBoundingRect(boundSize, options, attributes, null).Size;

			//return new Xamarin.Forms.Size((double)sizeF.Width, (double)sizeF.Height);

			currentContext.ShowTextAtPoint((this.pegarLarguraTela() - sizeF.Width) / 2 , y + 185, Texto);

			currentContext.DrawPath(CoreGraphics.CGPathDrawingMode.FillStroke);
		}

		public void desenharTextoLabel(string Texto, float x, float y)
		{
			var currentContext = UIGraphics.GetCurrentContext();
			currentContext.SelectFont("Arial", 22f, CGTextEncoding.MacRoman);
			currentContext.SetTextDrawingMode(CGTextDrawingMode.Fill);
			currentContext.SetFillColor(UIColor.Green.CGColor);
			var nsText = new NSString(Texto);
			var boundSize = new SizeF((float)x, float.MaxValue);
			var options = NSStringDrawingOptions.UsesFontLeading |
						  NSStringDrawingOptions.UsesLineFragmentOrigin;


			var attributes = new UIStringAttributes
			{
				Font = UIFont.FromName("Arial", (float)22)
			};

			var sizeF = nsText.GetBoundingRect(boundSize, options, attributes, null).Size;
			currentContext.ShowTextAtPoint((this.pegarLarguraTela() - sizeF.Width) / 2, y + 185, Texto);

			currentContext.DrawPath(CoreGraphics.CGPathDrawingMode.FillStroke);

		}

	}
}