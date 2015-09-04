namespace SvgLibrary
{
	/// <summary>
	/// This class does not represent any SVG element. It is used when parsing an SVG file an
	/// unknown element is found.
	/// </summary>
	public class SvgUnsupported : SvgElement
	{
		public SvgUnsupported(SvgDocument doc, string sName):base(doc)
		{
			ElementName = sName + ":unsupported";
			ElementType = SvgElementType.TypeUnsupported;
		}
	}
}
