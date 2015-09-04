using System.ComponentModel;

namespace SvgLibrary
{
	/// <summary>
	/// It represents the ellipse SVG element.
	/// </summary>
	public class SvgEllipse : SvgBasicShape
	{
		/// <summary>
		/// The x-axis coordinate of the center of the ellipse.
		/// </summary>
		[Category("(Specific)")]
		[Description("The x-axis coordinate of the center of the ellipse.")]
		public string CX
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificCx);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificCx, value);
			}
		}

		/// <summary>
		/// The y-axis coordinate of the center of the ellipse.
		/// </summary>
		[Category("(Specific)")]
		[Description("The y-axis coordinate of the center of the ellipse.")]
		public string CY
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificCy);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificCy, value);
			}
		}

		/// <summary>
		/// The x-axis radius of the ellipse.
		/// </summary>
		[Category("(Specific)")]
		[Description("The x-axis radius of the ellipse.")]
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
		/// The y-axis radius of the ellipse.
		/// </summary>
		[Category("(Specific)")]
		[Description("The y-axis radius of the ellipse.")]
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
		/// It constructs an ellipse element with no attribute.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		public SvgEllipse(SvgDocument doc):base(doc)
		{
			Init();
		}

		/// <summary>
		/// It constructs an ellipse element.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		/// <param name="sCX"></param>
		/// <param name="sCY"></param>
		/// <param name="sRX"></param>
		/// <param name="sRY"></param>
		public SvgEllipse(SvgDocument doc, string sCX, string sCY, string sRX, string sRY):base(doc)
		{
			Init();

			CX = sCX;
			CY = sCY;
			RX = sRX;
			RY = sRY;
		}

		private void Init()
		{
			ElementName = "ellipse";
			ElementType = SvgElementType.TypeEllipse;

			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificCx, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificCy, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificRx, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificRy, "");
		}
	}
}
