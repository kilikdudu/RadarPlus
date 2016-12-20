using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Radar.Controls;
using Radar.iOS;

[assembly: ExportRenderer(typeof(Tag), typeof(TagRenderer))]
namespace Radar.iOS
{
	/// <summary>
	/// Class ImageGalleryRenderer.
	/// </summary>
	public class TagRenderer : ViewRenderer<Tag, TagiOS>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ImageGalleryRenderer"/> class.
		/// </summary>
		public TagRenderer()
		{


		}

		/// <summary>
		/// Called when [element changed].
		/// </summary>
		/// <param name="e">The e.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Tag> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
				return;


			if (e.NewElement != null) {
				
				//_shapeview.desenharTexto += desenharTexto;
				//_shapeview.desenharPonteiro += desenharPonteiro;
				 TagiOS tag = new TagiOS();
		         tag.tag = Element;
		         tag.tag.desenharTag += tag.desenharTag;
		            
		         SetNativeControl(tag);
			}



		}
		/// <summary>
		/// Binds the specified new element.
		/// </summary>
		/// <param name="newElement">The new element.</param>


	}
}