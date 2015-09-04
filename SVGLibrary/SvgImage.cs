using System.ComponentModel;

namespace SvgLibrary
{
	/// <summary>
	/// It represents the image SVG element.
	/// </summary>
	public class SvgImage : SvgElement
	{
		/// <summary>
		/// The x-axis coordinate of the side of the element which has the smaller x-axis coordinate value in the current user coordinate system. If the attribute is not specified, the effect is as if a value of 0 were specified.
		/// </summary>
		[Category("(Specific)")]
		[Description("The x-axis coordinate of the side of the element which has the smaller x-axis coordinate value in the current user coordinate system. If the attribute is not specified, the effect is as if a value of 0 were specified.")]
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
		/// The y-axis coordinate of the side of the element which has the smaller y-axis coordinate value in the current user coordinate system. If the attribute is not specified, the effect is as if a value of 0 were specified.
		/// </summary>
		[Category("(Specific)")]
		[Description("The y-axis coordinate of the side of the element which has the smaller y-axis coordinate value in the current user coordinate system. If the attribute is not specified, the effect is as if a value of 0 were specified.")]
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
		/// The width of the element. A value of zero disables rendering of the element.
		/// </summary>
		[Category("(Specific)")]
		[Description("The width of the element. A value of zero disables rendering of the element.")]
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
		/// The height of the element. A value of zero disables rendering of the element.
		/// </summary>
		[Category("(Specific)")]
		[Description("The height of the element. A value of zero disables rendering of the element.")]
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
		/// This attribute assigns a (CSS) class name or set of class names to an element.
		/// </summary>
		[Category("Style")]
		[Description("This attribute assigns a (CSS) class name or set of class names to an element.")]
		public string Class
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrStyleClass);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrStyleClass, value);
			}
		}

		/// <summary>
		/// This attribute specifies style information for the current element. The style attribute specifies style information for a single element.
		/// </summary>
		[Category("Style")]
		[Description("This attribute specifies style information for the current element. The style attribute specifies style information for a single element.")]
		public string Style
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrStyleStyle);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrStyleStyle, value);
			}
		}

		/// <summary>
		/// Url of the image file.
		/// </summary>
		[Category("(Specific)")]
		[Description("Url of the image file.")]
		public string HRef
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrXLinkHRef);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrXLinkHRef, value);
			}
		}

		/// <summary>
		/// It constructs an image element with no attribute.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		public SvgImage(SvgDocument doc):base(doc)
		{
			Init();
		}

		/// <summary>
		/// It constructs an image element.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		/// <param name="sX"></param>
		/// <param name="sY"></param>
		/// <param name="sWidth"></param>
		/// <param name="sHeight"></param>
		/// <param name="sHRef"></param>
		/// <param name="doc"></param>
		public SvgImage(SvgDocument doc, 
						string sX, 
						string sY, 
						string sWidth, 
						string sHeight,
						string sHRef):base(doc)
		{
			Init();

			X = sX;
			Y = sY;
			Width = sWidth;
			Height = sHeight;
			HRef = sHRef;
		}

		private void Init()
		{
			ElementName = "image";
			ElementType = SvgElementType.TypeImage;

			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificX, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificY, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificWidth, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificHeight, "");
			
			AddAttribute(SvgAttribute.SvgAttributes.AttrXLinkHRef, "");

			AddAttribute(SvgAttribute.SvgAttributes.AttrStyleClass, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrStyleStyle, "");
		}
	}
}
