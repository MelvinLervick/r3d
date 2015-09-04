using System.ComponentModel;
using System.Drawing;

namespace SvgLibrary
{
	/// <summary>
	/// It represents the rect SVG element.
	/// </summary>
	public class SvgRect : SvgBasicShape
	{
		/// <summary>
		/// X-axis coordinate of the side of the element which has the smaller x-axis coordinate value in the current user coordinate system. If the attribute is not specified, the effect is as if a value of 0 were specified.
		/// </summary>
		[Category("(Specific)")]
		[Description("X-axis coordinate of the side of the element which has the smaller x-axis coordinate value in the current user coordinate system. If the attribute is not specified, the effect is as if a value of 0 were specified.")]
		public string X
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificX);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificX, value);
			}
		}

		/// <summary>
		/// Y-axis coordinate of the side of the element which has the smaller y-axis coordinate value in the current user coordinate system. If the attribute is not specified, the effect is as if a value of 0 were specified.
		/// </summary>
		[Category("(Specific)")]
		[Description("Y-axis coordinate of the side of the element which has the smaller y-axis coordinate value in the current user coordinate system. If the attribute is not specified, the effect is as if a value of 0 were specified.")]
		public string Y
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificY);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificY, value);
			}
		}

		/// <summary>
		/// Width of the element. A value of zero disables rendering of the element.
		/// </summary>
		[Category("(Specific)")]
		[Description("Width of the element. A value of zero disables rendering of the element.")]
		public string Width
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificWidth);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificWidth, value);
			}
		}

		/// <summary>
		/// Height of the element. A value of zero disables rendering of the element.
		/// </summary>
		[Category("(Specific)")]
		[Description("Height of the element. A value of zero disables rendering of the element.")]
		public string Height
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificHeight);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificHeight, value);
			}
		}

		/// <summary>
		/// For rounded rectangles, the x-axis radius of the ellipse used to round off the corners of the rectangle.
		/// </summary>
		[Category("(Specific)")]
		[Description("For rounded rectangles, the x-axis radius of the ellipse used to round off the corners of the rectangle.")]
		public string RX
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificRx);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificRx, value);
			}
		}

		/// <summary>
		/// For rounded rectangles, the y-axis radius of the ellipse used to round off the corners of the rectangle.
		/// </summary>
		[Category("(Specific)")]
		[Description("For rounded rectangles, the y-axis radius of the ellipse used to round off the corners of the rectangle.")]
		public string RY
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificRy);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificRy, value);
			}
		}

		/// <summary>
		/// It constructs a rect element with no attribute.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		public SvgRect(SvgDocument doc):base(doc)
		{
			Init();
		}

		/// <summary>
		/// It constructs a rect element.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		/// <param name="sX"></param>
		/// <param name="sY"></param>
		/// <param name="sWidth"></param>
		/// <param name="sHeight"></param>
		/// <param name="sStrokeWidth"></param>
		/// <param name="colFill"></param>
		/// <param name="colStroke"></param>
		public SvgRect(SvgDocument doc, 
			           string sX, 
			           string sY, 
			           string sWidth, 
			           string sHeight, 
			           string sStrokeWidth,
			           Color colFill, 
			           Color colStroke):base(doc)
		{
			Init();

			X = sX;
			Y = sY;
			Width = sWidth;
			StrokeWidth = sStrokeWidth;
			Height = sHeight;
			Fill = colFill;
			Stroke = colStroke;
		}

		private void Init()
		{
			ElementName = "rect";
			ElementType = SvgElementType.TypeRect;

			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificX, null);
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificY, null);
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificWidth, null);
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificHeight, null);
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificRx, null);
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificRy, null);
		}
	}
}
