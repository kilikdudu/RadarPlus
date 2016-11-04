using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Radar.Controls;
using Radar.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(Velocimetro), typeof(VelocimetroRenderer))]
namespace Radar.iOS
{
	/// <summary>
	/// Class ImageGalleryRenderer.
	/// </summary>
	public class VelocimetroRenderer : ViewRenderer<Velocimetro, VelocimetroiOS>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ImageGalleryRenderer"/> class.
		/// </summary>
		public VelocimetroRenderer()
		{

			this.BackgroundColor = UIColor.White;
		}

		/// <summary>
		/// Called when [element changed].
		/// </summary>
		/// <param name="e">The e.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Velocimetro> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
				return;


			if (e.NewElement != null) {
				
				//_shapeview.desenharTexto += desenharTexto;
				//_shapeview.desenharPonteiro += desenharPonteiro;
				VelocimetroiOS velocimetro = new VelocimetroiOS();
				velocimetro.velocimetro = Element;
				//velocimetro.velocimetro.redesenhar += velocimetro.SetNeedsDisplay;
				velocimetro.velocimetro.desenharPonteiro += velocimetro.desenharPonteiro;
				velocimetro.velocimetro.desenharTexto += velocimetro.desenharTexto;
				velocimetro.velocimetro.desenharTextoVelocidade += velocimetro.desenharTextoVelocidade;
				velocimetro.velocimetro.desenharTextoLabel += velocimetro.desenharTextoLabel;
				//velocimentro.velocimetro.pegarAlturaTela += velocimentro.pegarAlturaTela;
				//velocimentro.velocimetro.pegarLarguraTela += velocimentro.pegarLarguraTela;
				velocimetro.velocimetro.redesenhar += velocimetro.SetNeedsDisplay;
				SetNativeControl(velocimetro);
			}



		}
		/// <summary>
		/// Binds the specified new element.
		/// </summary>
		/// <param name="newElement">The new element.</param>


	}
}