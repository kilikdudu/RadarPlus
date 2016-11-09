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

namespace Radar.iOS
{
	public class VelocimetroiOS : UIView
	{
		public Velocimetro velocimetro { get; set; }
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
			UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;
			Console.WriteLine("Orientacao: " + orientation);
			var currentContext = UIGraphics.GetCurrentContext();
			currentContext.TranslateCTM(0, Bounds.Height);
			currentContext.ScaleCTM(1f, -1f);
			currentContext.SetStrokeColor(UIColor.White.CGColor);
			//velocimetro.redesenhar();
			velocimetro.desenhar();


		}

		private CGColor pegarCor(PonteiroCorEnum cor)
		{
			CGColor retorno;
			switch (cor)
			{
				case PonteiroCorEnum.Verde:
					retorno = UIColor.Green.CGColor;
					break;
				case PonteiroCorEnum.Vermelho:
					retorno = UIColor.Red.CGColor;
					break;
				case PonteiroCorEnum.CinzaClaro:
					retorno = UIColor.LightGray.CGColor;
					break;
				default:
					retorno = UIColor.Gray.CGColor;
					break;
			}
			return retorno;
		}

		public float pegarAlturaTela()
		{
			float altura;

				altura = (float)UIScreen.MainScreen.Bounds.Height;
				Console.WriteLine("AlturaP: " + altura);


			return altura;
		}
		public float pegarLarguraTela()
		{
			float largura;

				largura = (float)UIScreen.MainScreen.Bounds.Width;

			Console.WriteLine("largura: " + largura);
			return largura;
		}

		public void desenharPonteiro(RetanguloInfo rect, PonteiroCorEnum cor)
		{
			var currentContext2 = UIGraphics.GetCurrentContext();
			currentContext2.SetLineWidth(3);
			currentContext2.SetFillColor(UIColor.Red.CGColor);
			//currentContext2.SetStrokeColor(UIColor.Red.CGColor);

			currentContext2.SetStrokeColor(pegarCor(cor));

			currentContext2.MoveTo(rect.Top, rect.Left);
			currentContext2.AddLineToPoint(rect.Bottom, rect.Right);

			currentContext2.DrawPath(CoreGraphics.CGPathDrawingMode.FillStroke);


		}

		public void desenharTexto(string Texto, float x, float y, PonteiroCorEnum cor)
		{
			var currentContext = UIGraphics.GetCurrentContext();
			currentContext.SelectFont("Arial", 16f, CGTextEncoding.MacRoman);
			currentContext.SetTextDrawingMode(CGTextDrawingMode.Fill);
			currentContext.SetFillColor(UIColor.Red.CGColor);
			currentContext.SetFillColor(pegarCor(cor));

			currentContext.ShowTextAtPoint(y - 10, x + 15, Texto);
			currentContext.DrawPath(CoreGraphics.CGPathDrawingMode.FillStroke);
		}

		public void desenharTextoVelocidade(string Texto, float x, float y, PonteiroCorEnum cor)
		{
			
			var currentContext = UIGraphics.GetCurrentContext();
			currentContext.SelectFont("Arial", 30f, CGTextEncoding.MacRoman);
			currentContext.SetTextDrawingMode(CGTextDrawingMode.Fill);
			currentContext.SetFillColor(pegarCor(cor));
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

			currentContext.ShowTextAtPoint((this.pegarLarguraTela() - sizeF.Width) / 2 , y, Texto);

			currentContext.DrawPath(CoreGraphics.CGPathDrawingMode.FillStroke);
		}

		public void desenharTextoLabel(string Texto, float x, float y, PonteiroCorEnum cor)
		{
			var currentContext = UIGraphics.GetCurrentContext();
			currentContext.SelectFont("Arial", 22f, CGTextEncoding.MacRoman);
			currentContext.SetTextDrawingMode(CGTextDrawingMode.Fill);
			currentContext.SetFillColor(pegarCor(cor));
			var nsText = new NSString(Texto);
			var boundSize = new SizeF((float)x, float.MaxValue);
			var options = NSStringDrawingOptions.UsesFontLeading |
						  NSStringDrawingOptions.UsesLineFragmentOrigin;


			var attributes = new UIStringAttributes
			{
				Font = UIFont.FromName("Arial", (float)22)
			};

			var sizeF = nsText.GetBoundingRect(boundSize, options, attributes, null).Size;
			currentContext.ShowTextAtPoint((this.pegarLarguraTela() - sizeF.Width) / 2, y - 55, Texto);

			currentContext.DrawPath(CoreGraphics.CGPathDrawingMode.FillStroke);

		}

	}
}