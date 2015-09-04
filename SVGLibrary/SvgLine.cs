using System.ComponentModel;
using System.Drawing;

namespace SvgLibrary
{
	/// <summary>
	/// It represents the line SVG element.
	/// </summary>
	public class SvgLine : SvgBasicShape
	{
		/// <summary>
		/// The x-axis coordinate of the start point of the line.
		/// </summary>
		[Category("(Specific)")]
		[Description("The x-axis coordinate of the start point of the line.")]
		public string X1
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificX1);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificX1, value);
			}
		}

		/// <summary>
		/// The y-axis coordinate of the start point of the line.
		/// </summary>
		[Category("(Specific)")]
		[Description("The y-axis coordinate of the start point of the line.")]
		public string Y1
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificY1);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificY1, value);
			}
		}

		/// <summary>
		/// The x-axis coordinate of the end point of the line.
		/// </summary>
		[Category("(Specific)")]
		[Description("The x-axis coordinate of the end point of the line.")]
		public string X2
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificX2);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificX2, value);
			}
		}

		/// <summary>
		/// The y-axis coordinate of the end point of the line.
		/// </summary>
		[Category("(Specific)")]
		[Description("The y-axis coordinate of the end point of the line.")]
		public string Y2
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificY2);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificY2, value);
			}
		}

		/// <summary>
		/// It constructs an line element with no attribute.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		public SvgLine(SvgDocument doc):base(doc)
		{
			Init();
		}

		/// <summary>
		/// It constructs an line element.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		/// <param name="sX1"></param>
		/// <param name="sY1"></param>
		/// <param name="sX2"></param>
		/// <param name="sY2"></param>
		/// <param name="col"></param>
		public SvgLine(SvgDocument doc, string sX1, string sY1, string sX2, string sY2, Color col):base(doc)
		{
			Init();

			X1 = sX1;
			Y1 = sY1;
			X2 = sX2;
			Y2 = sY2;
			Fill = col;
		}

		private void Init()
		{
			ElementName = "line";
			ElementType = SvgElementType.TypeLine;

			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificX1, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificY1, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificX2, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificY2, "");
		}
	}
}
