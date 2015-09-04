using System.ComponentModel;

namespace SvgLibrary
{
	/// <summary>
	/// It represents the polygon SVG element.
	/// The 'polygon' element defines a closed shape consisting of a set of connected straight line segments.
	/// </summary>
	public class SvgPolygon : SvgBasicShape
	{
		/// <summary>
		/// The points that make up the polygon. All coordinate values are in the user coordinate system.
		/// </summary>
		[Category("(Specific)")]
		[Description("The points that make up the polygon. All coordinate values are in the user coordinate system.")]
		public string Points
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificPoints);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificPoints, value);
			}
		}

		/// <summary>
		/// It constructs a polygon element with no attribute.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		public SvgPolygon(SvgDocument doc):base(doc)
		{
			Init();
		}

		/// <summary>
		/// It constructs a polygon element.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		/// <param name="sPoints"></param>
		public SvgPolygon(SvgDocument doc, string sPoints):base(doc)
		{
			Init();

			Points = sPoints;
		}

		private void Init()
		{
			ElementName = "polygon";
			ElementType = SvgElementType.TypePolygon;

			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificPoints, "");
		}
	}
}
