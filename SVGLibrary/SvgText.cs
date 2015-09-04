using System.ComponentModel;

namespace SvgLibrary
{
	/// <summary>
	/// It represents the text SVG element.
	/// </summary>
	public class SvgText : SvgElement
	{
		/// <summary>
		/// Specifies a base URI other than the base URI of the document or external entity.
		/// </summary>
		[Category("(Core)")]
		[Description("Specifies a base URI other than the base URI of the document or external entity.")]
		public string XmlBase
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrCoreXmlBase);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrCoreXmlBase, value);
			}
		}

		/// <summary>
		/// Standard XML attribute to specify the language (e.g., English) used in the contents and attribute values of particular elements.
		/// </summary>
		[Category("(Core)")]
		[Description("Standard XML attribute to specify the language (e.g., English) used in the contents and attribute values of particular elements.")]
		public string XmlLang
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrCoreXmlLang);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrCoreXmlLang, value);
			}
		}

		/// <summary>
		/// Standard XML attribute to specify whether white space is preserved in character data. The only possible values are default and preserve.
		/// </summary>
		[Category("(Core)")]
		[Description("Standard XML attribute to specify whether white space is preserved in character data. The only possible values are default and preserve.")]
		public string XmlSpace
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrCoreXmlSpace);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrCoreXmlSpace, value);
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
		/// The value of the element.
		/// </summary>
		[Category("(Specific)")]
		[Description("The value of the element.")]
		public string Value
		{
			get	
			{
				return ElementValue;	
			}

			set	
			{
				ElementValue =  value;
			}
		}

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
		/// Shifts in the current text position along the x-axis for the characters within this element or any of its descendants.
		/// </summary>
		[Category("(Specific)")]
		[Description("Shifts in the current text position along the x-axis for the characters within this element or any of its descendants.")]
		public string DX
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificDx);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificDx, value);
			}
		}

		/// <summary>
		/// Shifts in the current text position along the y-axis for the characters within this element or any of its descendants.
		/// </summary>
		[Category("(Specific)")]
		[Description("Shifts in the current text position along the y-axis for the characters within this element or any of its descendants.")]
		public string DY
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificDy);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificDy, value);
			}
		}

		/// <summary>
		/// The supplemental rotation about the current text position that will be applied to all of the glyphs corresponding to each character within this element.
		/// </summary>
		[Category("(Specific)")]
		[Description("The supplemental rotation about the current text position that will be applied to all of the glyphs corresponding to each character within this element.")]
		public string Rotate
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificRotate);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificRotate, value);
			}
		}

		/// <summary>
		/// The author's computation of the total sum of all of the advance values that correspond to character data within this element, including the advance value on the glyph (horizontal or vertical), the effect of properties 'kerning', 'letter-spacing' and 'word-spacing' and adjustments due to attributes dx and dy on 'tspan' elements. This value is used to calibrate the user agent's own calculations with that of the author.
		/// </summary>
		[Category("(Specific)")]
		[Description("The author's computation of the total sum of all of the advance values that correspond to character data within this element, including the advance value on the glyph (horizontal or vertical), the effect of properties 'kerning', 'letter-spacing' and 'word-spacing' and adjustments due to attributes dx and dy on 'tspan' elements. This value is used to calibrate the user agent's own calculations with that of the author.")]
		public string TextLength
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificTextLength);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificTextLength, value);
			}
		}

		/// <summary>
		/// Indicates the type of adjustments which the user agent shall make to make the rendered length of the text match the value specified on the textLength attribute.
		/// </summary>
		[Category("(Specific)")]
		[Description("Indicates the type of adjustments which the user agent shall make to make the rendered length of the text match the value specified on the textLength attribute.")]
		public SvgAttribute.SvgLengthAdjust LengthAdjust
		{
			get	
			{
				return (SvgAttribute.SvgLengthAdjust) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrSpecificLengthAdjust);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificLengthAdjust, (int) value);
			}
		}

		/// <summary>
		/// Indicates which font family is to be used to render the text, specified as a prioritized list of font family names and/or generic family names.
		/// </summary>
		[Category("Font")]
		[Description("Indicates which font family is to be used to render the text, specified as a prioritized list of font family names and/or generic family names.")]
		public string FontFamily
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrFontFamily);
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrFontFamily, value);
			}
		}

		/// <summary>
		/// This property refers to the size of the font from baseline to baseline when multiple lines of text are set solid in a multiline layout environment.
		/// </summary>
		[Category("Font")]
		[Description("This property refers to the size of the font from baseline to baseline when multiple lines of text are set solid in a multiline layout environment.")]
		public string FontSize
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrFontSize);
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrFontSize, value);
			}
		}

		/// <summary>
		/// This property allows authors to specify an aspect value for an element that will preserve the x-height of the first choice font in a substitute font.
		/// </summary>
		[Category("Font")]
		[Description("This property allows authors to specify an aspect value for an element that will preserve the x-height of the first choice font in a substitute font.")]
		public string SizeAdjust
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrFontSizeAdjust);
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrFontSizeAdjust, value);
			}
		}

		/// <summary>
		/// This property indicates the desired amount of condensing or expansion in the glyphs used to render the text.
		/// </summary>
		[Category("Font")]
		[Description("This property indicates the desired amount of condensing or expansion in the glyphs used to render the text.")]
		public SvgAttribute.SvgFontStretch Stretch
		{
			get	
			{
				return (SvgAttribute.SvgFontStretch) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrFontStretch);
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrFontStretch, (int) value);
			}
		}

		/// <summary>
		/// It constructs a text element with no attribute.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		public SvgText(SvgDocument doc):base(doc)
		{
			ElementName = "text";
			HasValue = true;
			ElementType = SvgElementType.TypeText;

			AddAttribute(SvgAttribute.SvgAttributes.AttrCoreXmlBase, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrCoreXmlLang, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrCoreXmlSpace, "");

			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificX, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificY, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificDx, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificDy, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificRotate, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificTextLength, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificLengthAdjust, 0);

			AddAttribute(SvgAttribute.SvgAttributes.AttrStyleClass, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrStyleStyle, "");

			AddAttribute(SvgAttribute.SvgAttributes.AttrFontFamily, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrFontSize, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrFontSizeAdjust, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrFontStretch, 0);
			AddAttribute(SvgAttribute.SvgAttributes.AttrFontStyle, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrFontVariant, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrFontWeight, "");
		}
	}
}
