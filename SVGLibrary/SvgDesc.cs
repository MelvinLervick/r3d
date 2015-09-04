using System.ComponentModel;

namespace SvgLibrary
{
	/// <summary>
	/// It represents the desc SVG element.
	/// Each container element or graphics element in an SVG drawing can supply 
	/// a 'desc' and/or a 'title' description string where the description is text-only.
	/// </summary>
	public class SvgDesc : SvgElement
	{
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
		/// It constructs a desc element with no attribute.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		public SvgDesc(SvgDocument doc):base(doc)
		{
			Init();
		}

		/// <summary>
		/// It constructs a desc element.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		/// <param name="sValue"></param>
		public SvgDesc(SvgDocument doc, string sValue):base(doc)
		{
			Init();

			Value = sValue;
		}

		private void Init()
		{
			ElementName = "desc";
			HasValue = true;
			ElementType = SvgElementType.TypeDesc;
		}
	}
}
