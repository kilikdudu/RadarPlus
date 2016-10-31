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

			VelocimetroiOS velocimentro = new VelocimetroiOS();
			velocimentro.ShapeView = Element;
			velocimentro.ShapeView.desenharPonteiro += velocimentro.desenharPonteiro;
			velocimentro.ShapeView.desenharTexto += velocimentro.desenharTexto;
			velocimentro.ShapeView.desenharTextoVelocidade += velocimentro.desenharTextoVelocidade;
			velocimentro.ShapeView.desenharTextoLabel += velocimentro.desenharTextoLabel;
			velocimentro.ShapeView.pegarAlturaTela += velocimentro.pegarAlturaTela;
			velocimentro.ShapeView.pegarLarguraTela += velocimentro.pegarLarguraTela;
			velocimentro.ShapeView.redesenhar += velocimentro.SetNeedsDisplay;
			SetNativeControl(velocimentro);

		}
		/// <summary>
		/// Binds the specified new element.
		/// </summary>
		/// <param name="newElement">The new element.</param>


	}
}