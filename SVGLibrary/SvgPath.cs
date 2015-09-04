using System.ComponentModel;

namespace SvgLibrary
{
	/// <summary>
	/// It represents the path SVG element.
	/// Paths represent the outline of a shape which can be filled, stroked, used as a clipping path, or any combination of the three.
	/// </summary>
	public class SvgPath : SvgBasicShape
	{
		/// <summary>
		/// The definition of the outline of a shape.
		/// </summary>
		[Category("(Specific)")]
		[Description("The definition of the outline of a shape.")]
		public string PathData
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificPathData);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificPathData, value);
			}
		}

		/// <summary>
		/// The author's computation of the total length of the path, in user units.
		/// </summary>
		[Category("(Specific)")]
		[Description("The author's computation of the total length of the path, in user units.")]
		public string PathLength
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrSpecificPathLength);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrSpecificPathLength, value);
			}
		}

		/// <summary>
		/// It constructs a path element with no attribute.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		public SvgPath(SvgDocument doc):base(doc)
		{
			Init();
		}
		
		/// <summary>
		/// It constructs a path element.
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="sPathData">SVG document.</param>
		public SvgPath(SvgDocument doc, string sPathData):base(doc)
		{
			Init();

			PathData = sPathData;
		}

		private void Init()
		{
			ElementName = "path";
			ElementType = SvgElementType.TypePath;

			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificPathData, "");
			AddAttribute(SvgAttribute.SvgAttributes.AttrSpecificPathLength, "");
		}
	}
}
