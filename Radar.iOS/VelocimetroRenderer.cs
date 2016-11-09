using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Radar.Controls;
using Radar.iOS;

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
				VelocimetroiOS velocimentro = new VelocimetroiOS();
				velocimentro.velocimetro = Element;
				velocimentro.velocimetro.desenharPonteiro += velocimentro.desenharPonteiro;
				velocimentro.velocimetro.desenharTexto += velocimentro.desenharTexto;
                /*
				velocimentro.velocimetro.desenharTextoVelocidade += velocimentro.desenharTextoVelocidade;
				velocimentro.velocimetro.desenharTextoLabel += velocimentro.desenharTextoLabel;
				velocimentro.velocimetro.pegarAlturaTela += velocimentro.pegarAlturaTela;
				velocimentro.velocimetro.pegarLarguraTela += velocimentro.pegarLarguraTela;
                */
				velocimentro.velocimetro.redesenhar += velocimentro.SetNeedsDisplay;
				SetNativeControl(velocimentro);
			}



		}
		/// <summary>
		/// Binds the specified new element.
		/// </summary>
		/// <param name="newElement">The new element.</param>


	}
}