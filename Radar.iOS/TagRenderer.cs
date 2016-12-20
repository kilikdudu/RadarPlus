using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Radar;
using Radar.iOS;
using UIKit;
using CoreGraphics;
using System.Drawing;
using Radar.Controls;

[assembly:ExportRenderer (typeof(Tag), typeof(TagRenderer))]
namespace Radar.iOS
{
	public class TagRenderer : VisualElementRenderer<Tag>
	{
		private readonly float QuarterTurnCounterClockwise = (float)(-1f * (Math.PI * 0.5f));

		public TagRenderer ()
		{
		}

		public override void Draw (CGRect rect)
		{
			var currentContext = UIGraphics.GetCurrentContext ();
			var properRect = AdjustForThickness (rect);
			HandleShapeDraw (currentContext, properRect);
		}

		protected RectangleF AdjustForThickness (CGRect rect)
		{
			var x = rect.X + Element.Padding.Left;
			var y = rect.Y + Element.Padding.Top;
			var width = rect.Width - Element.Padding.HorizontalThickness;
			var height = rect.Height - Element.Padding.VerticalThickness;
			return new RectangleF ((float)x, (float)y, (float)width, (float)height);
		}

		protected virtual void HandleShapeDraw (CGContext currentContext, RectangleF rect)
		{
			// Only used for circles
			var centerX = rect.X + (rect.Width  / 3 + 3);
			var centerY = rect.Y + (rect.Height / 3 + 5);
			var radius = rect.Width / 3;
			var startAngle = 0;
			var endAngle = (float)(Math.PI * 2);

			switch (Element.TipoShape) {
			case TipoShape.Box:
				HandleStandardDraw (currentContext, rect, () => {
					if (Element.CornerRadius > 0) {
						var path = UIBezierPath.FromRoundedRect (rect, Element.CornerRadius);
						currentContext.AddPath (path.CGPath);
					} else {
						currentContext.AddRect (rect);
					}
				});
				break;
			case TipoShape.Circle:
				HandleStandardDraw (currentContext, rect, () => currentContext.AddArc (centerX, centerY, radius, startAngle, endAngle, true));
				break;
			case TipoShape.CircleIndicator:
				HandleStandardDraw (currentContext, rect, () => currentContext.AddArc (centerX, centerY, radius, startAngle, endAngle, true));
				HandleStandardDraw (currentContext, rect, () => currentContext.AddArc (centerX, centerY, radius, QuarterTurnCounterClockwise, (float)(Math.PI * 2 * (Element.IndicatorPercentage / 100)) + QuarterTurnCounterClockwise, false), Element.StrokeWidth + 3);
				break;
			}
		}

		/// <summary>
		/// A simple method for handling our drawing of the shape. This method is called differently for each type of shape
		/// </summary>
		/// <param name="currentContext">Current context.</param>
		/// <param name="rect">Rect.</param>
		/// <param name="createPathForShape">Create path for shape.</param>
		/// <param name="lineWidth">Line width.</param>
		protected virtual void HandleStandardDraw (CGContext currentContext, RectangleF rect, Action createPathForShape, float? lineWidth = null)
		{
			currentContext.SetLineWidth (lineWidth ?? Element.StrokeWidth);
			currentContext.SetFillColor (Element.BackGroundColor.ToCGColor ());
			currentContext.SetStrokeColor (Element.BackGroundColor.ToCGColor ());

			createPathForShape ();

			currentContext.DrawPath (CGPathDrawingMode.FillStroke);
		}
	}
}