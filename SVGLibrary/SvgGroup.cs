namespace SvgLibrary
{
	/// <summary>
	/// It represents the group SVG element.
	/// </summary>
	public class SvgGroup : SvgElement
	{
		/// <summary>
		/// It constructs a group element with no attribute.
		/// </summary>
		/// <param name="doc">SVG document.</param>
		public SvgGroup(SvgDocument doc):base(doc)
		{
			ElementName = "g";
			ElementType = SvgElementType.TypeGroup;
		}
	}
}
