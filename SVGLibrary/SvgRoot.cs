using System.ComponentModel;

namespace SvgLibrary
{
	/// <summary>
	/// It represents the svg SVG element that is the root of the document.
	/// </summary>
	public class SvgRoot : SvgElement
	{
		/// <summary>
		/// Standard XML namespace.
		/// </summary>
		[Category("Svg")]
		[Description("Standard XML namespace.")]
		public string XmlNs
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSvgXmlNs);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSvgXmlNs, value);
			}
		}

		/// <summary>
		/// Standard XML version.
		/// </summary>
		[Category("Svg")]
		[Description("Standard XML version.")]
		public string Version
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSvgVersion);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSvgVersion, value);
			}
		}

		/// <summary>
		/// The width of the svg area.
		/// </summary>
		[Category("(Specific)")]
		[Description("The width of the svg area.")]
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
		/// The height of the svg area.
		/// </summary>
		[Category("(Specific)")]
		[Description("The height of the svg area.")]
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

		internal SvgRoot(SvgDocument doc):base(doc)
		{
			ElementName = "svg";
			ElementType = SvgElementType.TypeSvg;

			AddAttribute(SvgAttribute.SvgAttributes.AttrSvgXmlNs, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSvgVersion, "");

			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificWidth, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificHeight, "");
		}
	}
}
