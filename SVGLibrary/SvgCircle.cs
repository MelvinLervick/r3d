using System.ComponentModel;

namespace SvgLibrary
{
	/// <summary>
	/// It represents the circle SVG element.
	/// </summary>
	public class SvgCircle : SvgBasicShape
	{
		/// <summary>
		/// The x-axis coordinate of the center of the circle.
		/// </summary>
		[Category("(Specific)")]
		[Description("The x-axis coordinate of the center of the circle.")]
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
		/// The y-axis coordinate of the center of the circle.
		/// </summary>
		[Category("(Specific)")]
		[Description("The y-axis coordinate of the center of the circle.")]
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
		/// The radius of the circle.
		/// </summary>
		[Category("(Specific)")]
		[Description("The radius of the circle.")]
		public string R
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificR);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificR, value);
			}
		}

		/// <summary>
		/// It constructs a circle element with no attribute.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		public SvgCircle(SvgDocument doc):base(doc)
		{
			Init();
		}

		/// <summary>
		/// It constructs a circle element.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		/// <param name="sCX"></param>
		/// <param name="sCY"></param>
		/// <param name="sRadius"></param>
		public SvgCircle(SvgDocument doc, string sCX, string sCY, string sRadius):base(doc)
		{
			Init();

			CX = sCX;
			CY = sCY;
			R = sRadius;
		}

		private void Init()
		{
			ElementName = "circle";
			ElementType = SvgElementType.TypeCircle;

			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificCx, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificCy, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificR, "");
		}
	}
}
