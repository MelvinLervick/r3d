using System;
using System.Drawing;
using System.Collections;

namespace SvgLibrary
{
	/// <summary>
	/// Generic SVG attribute.
	/// </summary>
	public class SvgAttribute
	{
        #region Enums

        /// <summary>
        /// List of the supported SVG attributes.
        /// </summary>
        public enum SvgAttributes
		{
			AttrSvgXmlNs,
			AttrSvgVersion,
			AttrCoreId,
			AttrCoreXmlBase,
			AttrCoreXmlLang,
			AttrCoreXmlSpace,
			AttrSpecificX,
			AttrSpecificY,
			AttrSpecificCx,
			AttrSpecificCy,
			AttrSpecificWidth,
			AttrSpecificHeight,
			AttrSpecificR,
			AttrSpecificRx,
			AttrSpecificRy,
			AttrSpecificDx,
			AttrSpecificDy,
			AttrSpecificX1,
			AttrSpecificY1,
			AttrSpecificX2,
			AttrSpecificY2,
			AttrSpecificRotate,
			AttrSpecificTextLength,
			AttrSpecificLengthAdjust,
			AttrSpecificPathData,
			AttrSpecificPathLength,
			AttrSpecificPoints,
			AttrStyleClass,
			AttrStyleStyle,
			AttrPaintColor,
			AttrPaintFill,
			AttrPaintFillRule,
			AttrPaintStroke,
			AttrPaintStrokeWidth,
			AttrPaintStrokeDashArray,
			AttrPaintStrokeDashOffSet,
			AttrPaintStrokeLineCap,
			AttrPaintStrokeLineJoin,
			AttrPaintStrokeMiterLimit,
			AttrPaintColorInterpolation,
			AttrPaintColorInterpolationFilters,
			AttrPaintColorRendering,
			AttrOpacityOpacity,
			AttrOpacityFillOpacity,
			AttrOpacityStrokeOpacity,
			AttrGraphicsDisplay,
			AttrGraphicsImageRendering,
			AttrGraphicsPointerEvents,
			AttrGraphicsShapeRendering,
			AttrGraphicsTextRendering,
			AttrGraphicsVisiblity,
			AttrFontFamily, 
			AttrFontSize, 
			AttrFontSizeAdjust,
			AttrFontStretch,
			AttrFontStyle, 
			AttrFontVariant,
			AttrFontWeight,
			AttrXLinkType,
			AttrXLinkRole,
			AttrXLinkTitle,
			AttrXLinkShow,
			AttrXLinkActuate,
			AttrXLinkHRef,
			AttrXLinkTarget
		}

		/// <summary>
		/// List of SVG attribute groups.
		/// </summary>
		public enum SvgAttributeGroup
		{
			GroupUnknown,
			GroupSvg,
			GroupCore,
			GroupElementSpecific,
			GroupStyle,
			GroupPaint,
			GroupGraphics,
			GroupOpacity,
			GroupFont,
			GroupXLink
		}

		/// <summary>
		/// List of SVG attribute data types
		/// </summary>
		public enum SvgAttributeDataType
		{
			DataTypeString,
			DataTypeEnum,
			DataTypeColor,
			DataTypeHRef
		}

		/// <summary>
		/// List of fill rule attribute choices.
		/// </summary>
		public enum SvgFillRule
		{
			AttributeNotSet,
			NonZero,
			EvenOdd,
			Inherit
		}

		/// <summary>
		/// List of line cap attribute choices.
		/// </summary>
		public enum SvgLineCap
		{
			AttributeNotSet,
			Butt,
			Round,
			Square,
			Inherit
		}

		/// <summary>
		/// List of line join attribute choices.
		/// </summary>
		public enum SvgLineJoin
		{
			AttributeNotSet,
			Miter,
			Round,
			Bevel,
			Inherit
		}

		/// <summary>
		/// List of color interpolation attribute choices.
		/// </summary>
		public enum SvgColorInterpolation
		{
			AttributeNotSet,
			Auto,
			Rgb,
			LinearRgb,
			Inherit
		}

		/// <summary>
		/// List of color rendering attribute choices.
		/// </summary>
		public enum SvgColorRendering
		{
			AttributeNotSet,
			Auto,
			OptimizeSpeed,
			OptimizeQuality,
			Inherit
		}

		/// <summary>
		/// List of length adjust attribute choices.
		/// </summary>
		public enum SvgLengthAdjust
		{
			AttributeNotSet,
			Spacing,
			SpacingAndGlyphs
		}

		/// <summary>
		/// List of font stretch attribute choices.
		/// </summary>
		public enum SvgFontStretch
		{
			AttributeNotSet,
			Normal,
			Wider,
			Narrower,
			UltraCondensed,
			ExtraCondensed,
			Condensed,
			SemiCondensed,
			SemiExpanded,
			Expanded,
			ExtraExpanded,
			UltraExpanded,
			Inherit
		}

		/// <summary>
		/// List of display attribute choices.
		/// </summary>
		public enum SvgGraphicsDisplay
		{
			AttributeNotSet,
			Auto,
			Block,
			ListItem,
			RunIn,
			Compact,
			Marker,
			Table,
			InlineTable,
			TableRowGroup,
			TableHeaderGroup,
			TableFooterGroup,
			TableRow,
			TableColumnGroup,
			TableColumn,
			TableCell,
			TableCaption,
			None,
			Inherit
		}

		/// <summary>
		/// List of image rendering attribute choices.
		/// </summary>
		public enum SvgImageRendering
		{
			AttributeNotSet,
			OptimizeSpeed,
			OptimizeQuality,
			Inherit
		}

		/// <summary>
		/// List of pointer events attribute choices
		/// </summary>
		public enum SvgPointerEvents
		{
			AttributeNotSet,
			VisiblePainted,
			VisibleFill,
			VisibleStroke,
			Visible,
			Painted,
			Fill,
			Stroke,
			All,
			None,
			Inherit
		}

		/// <summary>
		/// List of shape rendering attribute choices.
		/// </summary>
		public enum SvgShapeRendering
		{
			AttributeNotSet,
			Auto,
			OptimizeSpeed,
			CrispEdges,
			GeometricPrecision,
			Inherit
		}

		/// <summary>
		/// List of text rendering attribute choices.
		/// </summary>
		public enum SvgTextRendering
		{
			AttributeNotSet,
			Auto,
			OptimizeSpeed,
			OptimizeLegibility,
			GeometricPrecision,
			Inherit
		}

		/// <summary>
		/// List of visibility attribute choices.
		/// </summary>
		public enum SvgVisibility
		{
			AttributeNotSet,
			Visible,
			Hidden,
			Collapse,
			Inherit
		}

        #endregion

        #region Public Properties

        /// <summary>
        /// It returns the attribute type.
        /// </summary>
        public SvgAttributes AttributeType
		{
			get	{return attributeType;}
		}
 
		/// <summary>
		/// It returns the attribute group.
		/// </summary>
		public SvgAttributeGroup AttributeGroup
		{
			get	
			{
				var info = (AttrInfo) mapAttributeInfo[attributeType];
				return info.SvgAttributeGroup;
			}
		}

		/// <summary>
		/// Gets/sets the attribute value. The type of the object depends on the attribute type.
		/// </summary>
		public object Value
		{
			get	{return objectValue;}

			set	{objectValue = value;}
		}

		/// <summary>
		/// It returns the attribute name.
		/// </summary>
		public string Name
		{
			get	
			{
				var info = (AttrInfo) mapAttributeInfo[attributeType];
				return info.Name;
			}
		}

		/// <summary>
		/// It returns the attribute data type.
		/// </summary>
		public SvgAttributeDataType AttributeDataType
		{
			get	
			{
				var info = (AttrInfo) mapAttributeInfo[attributeType];
				return info.SvgAttributeDataType;
			}
		}

		/// <summary>
		/// For datatypeEnum attributes it returns the array of acceptable values (string array).
		/// </summary>
		public ArrayList AttributeEnumValues
		{
			get
			{
				var info = (AttrInfo) mapAttributeInfo[attributeType];
				return info.EnumValues;
			}
		}

        #endregion

        #region Private Properties

        private class AttrInfo
		{
			public SvgAttributes SvgAttributeType;
			public SvgAttributeGroup SvgAttributeGroup;
			public SvgAttributeDataType SvgAttributeDataType;
			public string Name;
			public string GroupName;
			public string Help;
			public ArrayList EnumValues;

			public AttrInfo()
			{
				SvgAttributeDataType = SvgAttributeDataType.DataTypeString;

				EnumValues = new ArrayList();
			}
		}

		private SvgAttributes attributeType;
		private object objectValue;

		private static Hashtable mapAttributeInfo;
		private static bool init;

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="type">Attribute type.</param>
        public SvgAttribute(SvgAttributes type)
		{
			attributeType = type;
			objectValue = null;

			Init();
		}

		/// <summary>
		/// It returns the XML string of the SVG attribute.
		/// </summary>
		/// <returns>
		/// An XML string in the format [attributename]="attributevalue"
		/// </returns>
		public string GetXml()
		{
			// check if the value has not been initialized
			if (objectValue == null )
			{
				return "";
			}

			// check if it is empty
			if (objectValue.ToString() == "")
			{
				return "";
			}

			var value = "";

			switch (AttributeDataType)
			{
				case SvgAttributeDataType.DataTypeString:
				case SvgAttributeDataType.DataTypeHRef:
					value = objectValue.ToString(); 
					break;

				case SvgAttributeDataType.DataTypeEnum:
					// for enum attribute the 0 item means that the attribute is empty
					var nValue = (int) objectValue;

					if ( nValue > 0 && nValue <= AttributeEnumValues.Count )
					{
						value = (string) AttributeEnumValues[nValue-1];
					}
					break;

				case SvgAttributeDataType.DataTypeColor:

					if ( (Color) objectValue != Color.Transparent )
					{
						value = Color2String((Color) objectValue);
					}
					break;
			}

			if ( value == "" )
			{
				return "";
			}

			return " " + Name + "=\"" + value + "\""; ;
		}

        #endregion

        #region Private Methods

        internal string Color2String(Color color)
		{
			if ( color.IsNamedColor )
			{
				return color.Name;
			}
			else
			{
				var bytes = BitConverter.GetBytes(color.ToArgb());

				var color2String = "#";
				color2String += BitConverter.ToString(bytes, 2, 1);
				color2String += BitConverter.ToString(bytes, 1, 1);
				color2String += BitConverter.ToString(bytes, 0, 1);

				return color2String;
			}
		}

		internal Color String2Color(string color)
		{
			Color string2Color;

			if ( color.Length == 7 && color[0] == '#' )
			{
				var s1 = color.Substring(1, 2); 
				var s2 = color.Substring(3, 2);
				var s3 = color.Substring(5, 2);

				byte r = 0;
				byte g = 0;
				byte b = 0;

				try
				{
					r = Convert.ToByte(s1, 16);
					g = Convert.ToByte(s2, 16);
					b = Convert.ToByte(s3, 16);
				}
				catch
				{
				}

				string2Color = Color.FromArgb(r, g, b);
			}
			else
			{
				string2Color = Color.FromName(color);
			}

			return string2Color;
		}

		private void Init()
		{
			if ( init )
			{
				return;
			}
			init = true;

			mapAttributeInfo = new Hashtable();
			
			InitSvg(); // attributes that apply to the svg element only
			InitCore();
			InitElementSpecific();
			InitStyle();
			InitPaint();
			InitGraphics();
			InitOpacity();
			InitFont();
			InitXLink();
		}

		private static void InitSvg()
		{
		    // ---
		    var info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSvgXmlNs,
		        SvgAttributeGroup = SvgAttributeGroup.GroupSvg,
		        Name = "xmlns"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSvgVersion,
		        SvgAttributeGroup = SvgAttributeGroup.GroupSvg,
		        Name = "version"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---
		}

		private static void InitCore()
		{
		    // ---
		    var info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrCoreId,
		        SvgAttributeGroup = SvgAttributeGroup.GroupCore,
		        Name = "id"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrCoreXmlBase,
		        SvgAttributeGroup = SvgAttributeGroup.GroupCore,
		        Name = "xml:base"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrCoreXmlLang,
		        SvgAttributeGroup = SvgAttributeGroup.GroupCore,
		        Name = "xml:lang"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrCoreXmlSpace,
		        SvgAttributeGroup = SvgAttributeGroup.GroupCore,
		        Name = "xml:space",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("default");
			info.EnumValues.Add("preserve");
			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---
		}

		private static void InitElementSpecific()
		{
		    // ---
		    var info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificWidth,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "width"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificHeight,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "height"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificX,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "x"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificY,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "y"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificCx,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "cx"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificCy,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "cy"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificR,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "r"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificRx,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "rx"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificRy,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "ry",
		        GroupName = "specific",
		        Help =
		            "For rounded rectangles, the y-axis radius of the ellipse used to round off the corners of the rectangle."
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificDx,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "dx"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificDy,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "dy"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificRotate,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "rotate"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificTextLength,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "textLength"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificLengthAdjust,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "lengthAdjust",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("spacing");
			info.EnumValues.Add("spacingAndGlyphs");
			
			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificX1,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "x1"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificY1,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "y1"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificX2,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "x2"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificY2,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "y2"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificPathData,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "d"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificPathLength,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "pathLength"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrSpecificPoints,
		        SvgAttributeGroup = SvgAttributeGroup.GroupElementSpecific,
		        Name = "points"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---
		}

		private void InitStyle()
		{
		    // ---
		    var info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrStyleClass,
		        SvgAttributeGroup = SvgAttributeGroup.GroupStyle,
		        Name = "class"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrStyleStyle,
		        SvgAttributeGroup = SvgAttributeGroup.GroupStyle,
		        Name = "style"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---
		}

		private static void InitPaint()
		{
		    // ---
		    var info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintColor,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "color",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeColor
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintFill,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "fill",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeColor
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintFillRule,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "fill-rule",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("nonzero");
			info.EnumValues.Add("evenodd");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintStroke,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "stroke",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeColor
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintStrokeWidth,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "stroke-width"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintStrokeDashArray,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "stroke-dasharray"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintStrokeDashOffSet,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "stroke-dashoffset"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintStrokeLineCap,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "stroke-linecap",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("butt");
			info.EnumValues.Add("round");
			info.EnumValues.Add("square");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintStrokeLineJoin,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "stroke-linejoin",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("miter");
			info.EnumValues.Add("round");
			info.EnumValues.Add("bevel");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintStrokeMiterLimit,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "stroke-miterlimit"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---
			
			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintColorInterpolation,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "color-interpolation",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("auto");
			info.EnumValues.Add("sRGB");
			info.EnumValues.Add("linearRGB");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintColorInterpolationFilters,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "color-interpolation-filters",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("auto");
			info.EnumValues.Add("sRGB");
			info.EnumValues.Add("linearRGB");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrPaintColorRendering,
		        SvgAttributeGroup = SvgAttributeGroup.GroupPaint,
		        Name = "color-rendering",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("auto");
			info.EnumValues.Add("optimizeSpeed");
			info.EnumValues.Add("optimizeQuality");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---
		}

		private void InitGraphics()
		{
		    // ---
		    var info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrGraphicsDisplay,
		        SvgAttributeGroup = SvgAttributeGroup.GroupGraphics,
		        Name = "display",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("auto");
			info.EnumValues.Add("block");
			info.EnumValues.Add("list-item");
			info.EnumValues.Add("run-in");
			info.EnumValues.Add("compact");
			info.EnumValues.Add("marker");
			info.EnumValues.Add("table");
			info.EnumValues.Add("inline-table");
			info.EnumValues.Add("table-row-group");
			info.EnumValues.Add("table-header-group");
			info.EnumValues.Add("table-footer-group");
			info.EnumValues.Add("table-row");
			info.EnumValues.Add("table-column-group");
			info.EnumValues.Add("table-column");
			info.EnumValues.Add("table-cell");
			info.EnumValues.Add("table-caption");
			info.EnumValues.Add("none");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrGraphicsImageRendering,
		        SvgAttributeGroup = SvgAttributeGroup.GroupGraphics,
		        Name = "image-rendering",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("auto");
			info.EnumValues.Add("optimizeSpeed");
			info.EnumValues.Add("optimizeQuality");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrGraphicsPointerEvents,
		        SvgAttributeGroup = SvgAttributeGroup.GroupGraphics,
		        Name = "pointer-events",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("visiblePainted");
			info.EnumValues.Add("visibleFill");
			info.EnumValues.Add("visibleStroke");
			info.EnumValues.Add("visible");
			info.EnumValues.Add("painted");
			info.EnumValues.Add("fill");
			info.EnumValues.Add("stroke");
			info.EnumValues.Add("all");
			info.EnumValues.Add("none");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrGraphicsShapeRendering,
		        SvgAttributeGroup = SvgAttributeGroup.GroupGraphics,
		        Name = "shape-rendering",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("auto");
			info.EnumValues.Add("optimizeSpeed");
			info.EnumValues.Add("crispEdges");
			info.EnumValues.Add("geometricPrecision");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrGraphicsTextRendering,
		        SvgAttributeGroup = SvgAttributeGroup.GroupGraphics,
		        Name = "text-rendering",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("auto");
			info.EnumValues.Add("optimizeSpeed");
			info.EnumValues.Add("optimizeLegibility");
			info.EnumValues.Add("geometricPrecision");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrGraphicsVisiblity,
		        SvgAttributeGroup = SvgAttributeGroup.GroupGraphics,
		        Name = "visibility",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };

		    info.EnumValues.Add("visible");
			info.EnumValues.Add("hidden");
			info.EnumValues.Add("collapse");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---
		}

		private static void InitOpacity()
		{
		    // ---
		    var info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrOpacityOpacity,
		        SvgAttributeGroup = SvgAttributeGroup.GroupOpacity,
		        Name = "opacity"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrOpacityFillOpacity,
		        SvgAttributeGroup = SvgAttributeGroup.GroupOpacity,
		        Name = "fill-opacity"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrOpacityStrokeOpacity,
		        SvgAttributeGroup = SvgAttributeGroup.GroupOpacity,
		        Name = "stroke-opacity"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---
		}

		private static void InitFont()
		{
		    // ---
		    var info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrFontFamily,
		        SvgAttributeGroup = SvgAttributeGroup.GroupFont,
		        Name = "font-family"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrFontSize,
		        SvgAttributeGroup = SvgAttributeGroup.GroupFont,
		        Name = "font-size"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrFontSizeAdjust,
		        SvgAttributeGroup = SvgAttributeGroup.GroupFont,
		        Name = "font-size-adjust"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrFontStretch,
		        SvgAttributeGroup = SvgAttributeGroup.GroupFont,
		        Name = "font-stretch",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };


		    info.EnumValues.Add("normal");
			info.EnumValues.Add("wider");
			info.EnumValues.Add("narrower");
			info.EnumValues.Add("ultra-condensed");
			info.EnumValues.Add("extra-condensed");
			info.EnumValues.Add("condensed");
			info.EnumValues.Add("semi-condensed");
			info.EnumValues.Add("semi-expanded");
			info.EnumValues.Add("expanded");
			info.EnumValues.Add("extra-expanded");
			info.EnumValues.Add("ultra-expanded");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrFontStyle,
		        SvgAttributeGroup = SvgAttributeGroup.GroupFont,
		        Name = "font-style",
		        GroupName = "font",
		        Help = "This property specifies whether the text is to be rendered using a normal, italic or oblique face.",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };


		    info.EnumValues.Add("normal");
			info.EnumValues.Add("italic");
			info.EnumValues.Add("oblique");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrFontVariant,
		        SvgAttributeGroup = SvgAttributeGroup.GroupFont,
		        Name = "font-variant",
		        GroupName = "font",
		        Help =
		            "This property indicates whether the text is to be rendered using the normal glyphs for lowercase characters or using small-caps glyphs for lowercase characters.",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };


		    info.EnumValues.Add("normal");
			info.EnumValues.Add("small-caps");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrFontWeight,
		        SvgAttributeGroup = SvgAttributeGroup.GroupFont,
		        Name = "font-weight",
		        GroupName = "font",
		        Help =
		            "This property refers to the boldness or lightness of the glyphs used to render the text, relative to other fonts in the same font family.",
		        SvgAttributeDataType = SvgAttributeDataType.DataTypeEnum
		    };


		    info.EnumValues.Add("normal");
			info.EnumValues.Add("bold");
			info.EnumValues.Add("bolder");
			info.EnumValues.Add("lighter");
			info.EnumValues.Add("100");
			info.EnumValues.Add("200");
			info.EnumValues.Add("300");
			info.EnumValues.Add("400");
			info.EnumValues.Add("500");
			info.EnumValues.Add("600");
			info.EnumValues.Add("700");
			info.EnumValues.Add("800");
			info.EnumValues.Add("900");
			info.EnumValues.Add("inherit");

			mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---
		}

		private static void InitXLink()
		{
		    // ---
		    var info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrXLinkActuate,
		        SvgAttributeGroup = SvgAttributeGroup.GroupXLink,
		        Name = "xlink:actuate"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrXLinkHRef,
		        SvgAttributeGroup = SvgAttributeGroup.GroupXLink,
		        Name = "xlink:href"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrXLinkRole,
		        SvgAttributeGroup = SvgAttributeGroup.GroupXLink,
		        Name = "xlink:role"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrXLinkShow,
		        SvgAttributeGroup = SvgAttributeGroup.GroupXLink,
		        Name = "xlink:show"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrXLinkTarget,
		        SvgAttributeGroup = SvgAttributeGroup.GroupXLink,
		        Name = "target"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrXLinkTitle,
		        SvgAttributeGroup = SvgAttributeGroup.GroupXLink,
		        Name = "xlink:title"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---

			// ---
		    info = new AttrInfo
		    {
		        SvgAttributeType = SvgAttributes.AttrXLinkType,
		        SvgAttributeGroup = SvgAttributeGroup.GroupXLink,
		        Name = "xlink:type"
		    };

		    mapAttributeInfo.Add(info.SvgAttributeType, info);
			// ---
		}

        #endregion
    }
}
