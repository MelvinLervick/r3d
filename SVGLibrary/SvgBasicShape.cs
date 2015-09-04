using System.ComponentModel;
using System.Drawing;

namespace SvgLibrary
{
	/// <summary>
	/// Summary description for SvgBasicShape.
	/// </summary>
	public class SvgBasicShape : SvgElement
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
		/// It is the explicit color to be used to paint the current object.
		/// </summary>
		[Category("Paint")]
		[Description("It is the explicit color to be used to paint the current object.")]
		public Color Color
		{
			get	
			{
				return GetAttributeColorValue(SvgAttribute.SvgAttributes.AttrPaintColor);
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintColor, value);
			}
		}

		/// <summary>
		/// The uniform opacity setting to be applied across an entire object. Any values outside the range 0.0 (fully transparent) to 1.0 (fully opaque) will be clamped to this range.
		/// </summary>
		[Category("Opacity")]
		[Description("The uniform opacity setting to be applied across an entire object. Any values outside the range 0.0 (fully transparent) to 1.0 (fully opaque) will be clamped to this range.")]
		public string Opacity
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrOpacityOpacity);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrOpacityOpacity, value);
			}
		}

		/// <summary>
		/// Paints the interior of the given graphical element.
		/// </summary>
		[Category("Paint")]
		[Description("Paints the interior of the given graphical element.")]
		public Color Fill
		{
			get	
			{
				return GetAttributeColorValue(SvgAttribute.SvgAttributes.AttrPaintFill);
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintFill, value);
			}
		}

		/// <summary>
		/// It indicates the algorithm which is to be used to determine what parts of the canvas are included inside the shape.
		/// </summary>
		[Category("Paint")]
		[Description("It indicates the algorithm which is to be used to determine what parts of the canvas are included inside the shape.")]
		public SvgAttribute.SvgFillRule FillRule
		{
			get	
			{
				return (SvgAttribute.SvgFillRule) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrPaintFillRule);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintFillRule, (int) value);
			}
		}

		/// <summary>
		/// It specifies the opacity of the painting operation used to paint the interior the current object.
		/// </summary>
		[Category("Opacity")]
		[Description("It specifies the opacity of the painting operation used to paint the interior the current object.")]
		public string FillOpacity
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrOpacityFillOpacity);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrOpacityFillOpacity, value);
			}
		}

		/// <summary>
		/// Paints along the outline of the given graphical element.
		/// </summary>
		[Category("Paint")]
		[Description("Paints along the outline of the given graphical element.")]
		public Color Stroke
		{
			get	
			{
				return GetAttributeColorValue(SvgAttribute.SvgAttributes.AttrPaintStroke);
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintStroke, value);
			}
		}

		/// <summary>
		/// It specifies the opacity of the painting operation used to stroke the current object.
		/// </summary>
		[Category("Opacity")]
		[Description("It specifies the opacity of the painting operation used to stroke the current object.")]
		public string StrokeOpacity
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrOpacityStrokeOpacity);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrOpacityStrokeOpacity, value);
			}
		}

		/// <summary>
		/// The width of the stroke on the current object. If a percentage is used, the value represents a percentage of the current viewport.
		/// </summary>
		[Category("Paint")]
		[Description("The width of the stroke on the current object. If a percentage is used, the value represents a percentage of the current viewport.")]
		public string StrokeWidth
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrPaintStrokeWidth);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintStrokeWidth, value);
			}
		}

		/// <summary>
		/// It controls the pattern of dashes and gaps used to stroke paths. <dasharray> contains a list of comma-separated (with optional white space) <length>s that specify the lengths of alternating dashes and gaps.
		/// </summary>
		[Category("Paint")]
		[Description("It controls the pattern of dashes and gaps used to stroke paths. <dasharray> contains a list of comma-separated (with optional white space) <length>s that specify the lengths of alternating dashes and gaps.")]
		public string StrokeDashArray
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrPaintStrokeDashArray);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintStrokeDashArray, value);
			}
		}

		/// <summary>
		/// It specifies the distance into the dash pattern to start the dash.
		/// </summary>
		[Category("Paint")]
		[Description("It specifies the distance into the dash pattern to start the dash.")]
		public string StrokeDashOffSet
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrPaintStrokeDashOffSet);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintStrokeDashOffSet, value);
			}
		}

		/// <summary>
		/// It specifies the shape to be used at the end of open subpaths when they are stroked.
		/// </summary>
		[Category("Paint")]
		[Description("It specifies the shape to be used at the end of open subpaths when they are stroked.")]
		public SvgAttribute.SvgLineCap StrokeLineCap
		{
			get	
			{
				return (SvgAttribute.SvgLineCap) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrPaintStrokeLineCap);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintStrokeLineCap, (int) value);
			}
		}

		/// <summary>
		/// It specifies the shape to be used at the corners of paths or basic shapes when they are stroked.
		/// </summary>
		[Category("Paint")]
		[Description("It specifies the shape to be used at the corners of paths or basic shapes when they are stroked.")]
		public SvgAttribute.SvgLineJoin StrokeLineJoin
		{
			get	
			{
				return (SvgAttribute.SvgLineJoin) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrPaintStrokeLineJoin);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintStrokeLineJoin, (int) value);
			}
		}

		/// <summary>
		/// When two line segments meet at a sharp angle and miter joins have been specified for 'stroke-linejoin', it is possible for the miter to extend far beyond the thickness of the line stroking the path. The 'stroke-miterlimit' imposes a limit on the ratio of the miter length to the 'stroke-width'. When the limit is exceeded, the join is converted from a miter to a bevel.
		/// </summary>
		[Category("Paint")]
		[Description("When two line segments meet at a sharp angle and miter joins have been specified for 'stroke-linejoin', it is possible for the miter to extend far beyond the thickness of the line stroking the path. The 'stroke-miterlimit' imposes a limit on the ratio of the miter length to the 'stroke-width'. When the limit is exceeded, the join is converted from a miter to a bevel.")]
		public string StrokeMiterLimit
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrPaintStrokeMiterLimit);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintStrokeMiterLimit, value);
			}
		}

		/// <summary>
		/// It specifies the color space for gradient interpolations, color animations and alpha compositing.
		/// </summary>
		[Category("Paint")]
		[Description("It specifies the color space for gradient interpolations, color animations and alpha compositing.")]
		public SvgAttribute.SvgColorInterpolation ColorInterpolation
		{
			get	
			{
				return (SvgAttribute.SvgColorInterpolation) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrPaintColorInterpolation);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintColorInterpolation, (int) value);
			}
		}

		/// <summary>
		/// It specifies the color space for imaging operations performed via filter effects.
		/// </summary>
		[Category("Paint")]
		[Description("It specifies the color space for imaging operations performed via filter effects.")]
		public SvgAttribute.SvgColorInterpolation ColorInterpolationFilters
		{
			get	
			{
				return (SvgAttribute.SvgColorInterpolation) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrPaintColorInterpolationFilters);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintColorInterpolationFilters, (int) value);
			}
		}

		/// <summary>
		/// It provides a hint to the SVG user agent about how to optimize its color interpolation and compositing operations.
		/// </summary>
		[Category("Paint")]
		[Description("It provides a hint to the SVG user agent about how to optimize its color interpolation and compositing operations.")]
		public SvgAttribute.SvgColorRendering ColorRendering
		{
			get	
			{
				return (SvgAttribute.SvgColorRendering) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrPaintColorRendering);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrPaintColorRendering, (int) value);
			}
		}

		/// <summary>
		/// It control the visibility of the graphical element.
		/// </summary>
		/// <remarks>
		/// When applied to a container element, setting 'display' to none causes the container and all of its children 
		/// to be invisible; thus, it acts on groups of elements as a group. 
		/// 'visibility', however, only applies to individual graphics elements. Setting 'visibility' to hidden on a 'g' 
		/// will make its children invisible as long as the children do not specify their own 'visibility' properties as 
		/// visible. Note that 'visibility' is not an inheritable property. 
		/// When the 'display' property is set to none, then the given element does not become part of the rendering tree. 
		/// With 'visibility' set to hidden, however, processing occurs as if the element were part of the rendering tree 
		/// and still taking up space, but not actually rendered onto the canvas.
		/// </remarks>
		[Category("Graphics")]
		[Description("It control the visibility of the graphical element.")]
		public SvgAttribute.SvgGraphicsDisplay Display
		{
			get	
			{
				return (SvgAttribute.SvgGraphicsDisplay) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrGraphicsDisplay);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrGraphicsDisplay, (int) value);
			}
		}

		/// <summary>
		/// It provides a hint how to make speed vs. quality tradeoffs as it performs image processing.
		/// </summary>
		[Category("Graphics")]
		[Description("It provides a hint how to make speed vs. quality tradeoffs as it performs image processing.")]
		public SvgAttribute.SvgImageRendering ImageRendering
		{
			get	
			{
				return (SvgAttribute.SvgImageRendering) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrGraphicsImageRendering);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrGraphicsImageRendering, (int) value);
			}
		}

		/// <summary>
		/// It provides a hint about what tradeoffs to make as it renders vector graphics elements such as 'path' elements and basic shapes such as circles and rectangles.
		/// </summary>
		[Category("Graphics")]
		[Description("It provides a hint about what tradeoffs to make as it renders vector graphics elements such as 'path' elements and basic shapes such as circles and rectangles.")]
		public SvgAttribute.SvgShapeRendering ShapeRendering
		{
			get	
			{
				return (SvgAttribute.SvgShapeRendering) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrGraphicsShapeRendering);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrGraphicsShapeRendering, (int) value);
			}
		}

		/// <summary>
		/// It provides a hint to the SVG user agent about how to optimize its color interpolation and compositing operations.
		/// </summary>
		[Category("Graphics")]
		[Description("It provides a hint to the SVG user agent about how to optimize its color interpolation and compositing operations.")]
		public SvgAttribute.SvgTextRendering TextRendering
		{
			get	
			{
				return (SvgAttribute.SvgTextRendering) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrGraphicsTextRendering);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrGraphicsTextRendering, (int) value);
			}
		}

		/// <summary>
		/// It control the visibility of the graphical element.
		/// </summary>
		/// <remarks>
		/// When applied to a container element, setting 'display' to none causes the container and all of its children 
		/// to be invisible; thus, it acts on groups of elements as a group. 
		/// 'visibility', however, only applies to individual graphics elements. Setting 'visibility' to hidden on a 'g' 
		/// will make its children invisible as long as the children do not specify their own 'visibility' properties as 
		/// visible. Note that 'visibility' is not an inheritable property. 
		/// When the 'display' property is set to none, then the given element does not become part of the rendering tree. 
		/// With 'visibility' set to hidden, however, processing occurs as if the element were part of the rendering tree 
		/// and still taking up space, but not actually rendered onto the canvas.
		/// </remarks>
		[Category("Graphics")]
		[Description("It control the visibility of the graphical element.")]
		public SvgAttribute.SvgVisibility Visibility
		{
			get	
			{
				return (SvgAttribute.SvgVisibility) GetAttributeIntValue(SvgAttribute.SvgAttributes.AttrGraphicsVisiblity);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrGraphicsVisiblity, (int) value);
			}
		}

		protected SvgBasicShape(SvgDocument doc):base(doc)
		{
			AddAttribute(SvgAttribute.SvgAttributes.AttrCoreXmlBase, null);
			AddAttribute(SvgAttribute.SvgAttributes.AttrCoreXmlLang, null);
			AddAttribute(SvgAttribute.SvgAttributes.AttrCoreXmlSpace, null);

			AddAttribute(SvgAttribute.SvgAttributes.AttrStyleClass, null);
			AddAttribute(SvgAttribute.SvgAttributes.AttrStyleStyle, null);

			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintColor, Color.Transparent);
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintFill, Color.Transparent);
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintFillRule, 0);
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintStroke, Color.Transparent);
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintStrokeWidth, null);	
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintStrokeDashArray, null);	
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintStrokeDashOffSet, null);	
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintStrokeLineCap, 0);	
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintStrokeLineJoin, 0);	
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintStrokeMiterLimit, null);	
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintColorInterpolation, 0);	
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintColorInterpolationFilters, 0);	
			AddAttribute(SvgAttribute.SvgAttributes.AttrPaintColorRendering, 0);	
			
			AddAttribute(SvgAttribute.SvgAttributes.AttrGraphicsDisplay, 0);
			AddAttribute(SvgAttribute.SvgAttributes.AttrGraphicsPointerEvents, 0);
			AddAttribute(SvgAttribute.SvgAttributes.AttrGraphicsImageRendering, 0);	
			AddAttribute(SvgAttribute.SvgAttributes.AttrGraphicsShapeRendering, 0);	
			AddAttribute(SvgAttribute.SvgAttributes.AttrGraphicsTextRendering, 0);	
			AddAttribute(SvgAttribute.SvgAttributes.AttrGraphicsVisiblity, 0);

			AddAttribute(SvgAttribute.SvgAttributes.AttrOpacityOpacity, null);
			AddAttribute(SvgAttribute.SvgAttributes.AttrOpacityFillOpacity, null);
			AddAttribute(SvgAttribute.SvgAttributes.AttrOpacityStrokeOpacity, null);
			
		}
	}
}
