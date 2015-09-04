using System;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.Linq;

namespace SvgLibrary
{
	/// <summary>
	/// This is the base class of any Svg element.
	/// </summary>
	[DefaultProperty("Id")]
	public class SvgElement
	{
		/// <summary>
		/// List all SVG element types. For each element a specific class is defined in the library.
		/// </summary>
		public enum SvgElementType
		{
			TypeUnsupported,
			TypeSvg,
			TypeDesc,
			TypeText,
			TypeGroup,
			TypeRect,
			TypeCircle,
			TypeEllipse,
			TypeLine,
			TypePath,
			TypePolygon,
			TypeImage
		};

        #region Public Properties

        /// <summary>
        /// Standard XML attribute for assigning a unique name to an element.
        /// </summary>
        /// <remarks></remarks>
        [Category("(Core)")]
		[Description("Standard XML attribute for assigning a unique name to an element.")]
		public string Id
		{
			get	
			{
				return GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrCoreId);	
			}

			set	
			{
				SetAttributeValue(SvgAttribute.SvgAttributes.AttrCoreId, value);
			}
		}

        #endregion

        #region Private Properties

        private class CEleComparer : IComparer  
		{
			int IComparer.Compare( Object x, Object y )  
			{
				SvgAttribute ax = (SvgAttribute) x;
				SvgAttribute ay = (SvgAttribute) y;

				if ( ax.AttributeGroup == ay.AttributeGroup )
				{
					if ( ax.AttributeType < ay.AttributeType )
					{
						return -1;
					}
					else
					{
						return 1;
					}
				}
				else if ( ax.AttributeGroup < ay.AttributeGroup )
				{
					return -1;
				}
				else
				{
					return 1;
				}
			}
		}


		// navigation
		protected SvgElement ParentElement;
		protected SvgElement ChildElement;
		protected SvgElement NextElement; 
		protected SvgElement PreviousElement;

		// document
		protected SvgDocument LocalSvgDocument;
		
		// internal stuff
		protected int InternalId;
		protected string ElementName;
		protected string ElementValue;
		protected bool HasValue;
		protected SvgElementType ElementType;

		// attributes
		private ArrayList attributes;

        #endregion

        #region Public Methods

        // constructor is protected!

        /// <summary>
        /// It returns the parent element.
        /// </summary>
        /// <returns></returns>
        public SvgElement GetParent()
		{
			return ParentElement;
		}

		/// <summary>
		/// It sets the parent element.
		/// </summary>
		/// <param name="ele">New parent element</param>
		public void SetParent(SvgElement ele)
		{
			ParentElement = ele;
		}

		/// <summary>
		/// It gest the first child element.
		/// </summary>
		/// <returns>First child element.</returns>
		public SvgElement GetChild()
		{
			return ChildElement;
		}

		/// <summary>
		/// It sets the first child element.
		/// </summary>
		/// <param name="ele">New child.</param>
		public void SetChild(SvgElement ele)
		{
			ChildElement = ele;
		}

		/// <summary>
		/// It gets the next sibling element.
		/// </summary>
		/// <returns>Next element.</returns>
		public SvgElement GetNext()
		{
			return NextElement;
		}

		/// <summary>
		/// It sets the next sibling element.
		/// </summary>
		/// <param name="element">New next element.</param>
		public void SetNext(SvgElement element)
		{
			NextElement = element;
		}

		/// <summary>
		/// It gets the previous sibling element.
		/// </summary>
		/// <returns>Previous element.</returns>
		public SvgElement GetPrevious()
		{
			return PreviousElement;
		}

		/// <summary>
		/// It sets the previous element.
		/// </summary>
		/// <param name="element">New previous element.</param>
		public void SetPrevious(SvgElement element)
		{
			PreviousElement = element;
		}

		/// <summary>
		/// It gets the internal Id of the element.
		/// </summary>
		/// <returns>Internal Id.</returns>
		/// <remarks>The internal Id is a unique number inside the SVG document.
		/// It is assigned when the element is added to the document.</remarks>
		public int GetInternalId()
		{
			return InternalId;
		}

		/// <summary>
		/// It sets the internal Id of the element.
		/// </summary>
		/// <param name="id">New internal Id.</param>
		public void SetInternalId(int id)
		{
			InternalId = id;
		}

		/// <summary>
		/// It returns the SVG element name.
		/// </summary>
		/// <returns>SVG name.</returns>
		public string GetElementName()
		{
			return ElementName;
		}

		/// <summary>
		/// It returns the current element value.
		/// </summary>
		/// <returns>Element value.</returns>
		/// <remarks>Not all SVG elements are supposed to have a value. For instance a rect element or 
		/// a circle do not usually have a value while a desc or a text they normally have it.</remarks>
		public string GetElementValue()
		{
			return ElementValue;
		}

		/// <summary>
		/// Sets the element value.
		/// </summary>
		/// <param name="sValue">New element value.</param>
		public void SetElementValue(string sValue)
		{
			ElementValue = sValue;
		}

		/// <summary>
		/// Flag indicating if a value is expected for the SVG element.
		/// </summary>
		/// <returns>true if the SVG element has normally a value.</returns>
		public bool SvgElementHasValue()
		{
			return HasValue;
		}

		/// <summary>
		/// It returns the SVG element type.
		/// </summary>
		/// <returns></returns>
		public SvgElementType GetElementType()
		{
			return ElementType;
		}

		/// <summary>
		/// It returns the XML string of the SVG tree starting from the element.
		/// </summary>
		/// <returns>XML string.</returns>
		/// <remarks>The method is recursive so it creates the SVG string for the current element and for its
		/// sub-tree. If the element is the root of the SVG document the method return the entire SVG XML string.</remarks>
		public string GetXml()
		{
		    var xml = OpenXmlTag();

			if ( ChildElement != null )
			{
				xml += ChildElement.GetXml();
			}

			xml += CloseXmlTag();

			var ele = NextElement;
			if (ele != null)
			{
				xml += ele.GetXml();
			}
		
			return xml;
		}

		/// <summary>
		/// It returns the XML string of the SVG element.
		/// </summary>
		/// <returns>XML string.</returns>
		public string GetTagXml()
		{
		    var xml = OpenXmlTag();
			xml += CloseXmlTag();

			return xml;
		}

		/// <summary>
		/// It gets all element attributes.
		/// </summary>
		/// <param name="attributeType">Attribute type array.</param>
		/// <param name="attributeName">Attribute name array.</param>
		/// <param name="attributeValue">Attribute value array.</param>
		public void FillAttributeList(ArrayList attributeType, ArrayList attributeName, ArrayList attributeValue)
		{
			IComparer myComparer = new CEleComparer();
			attributes.Sort(myComparer);


			foreach (var attr in attributes.Cast<SvgAttribute>())
			{
			    attributeType.Add(attr.AttributeType);
			    attributeName.Add(attr.Name);
			    attributeValue.Add(attr.Value);
			}
		}

		/// <summary>
		/// It copies all the attributes of the element elementToClone to the
		/// current element.
		/// </summary>
		/// <param name="elementToClone">Element that has to be cloned.</param>
		public void CloneAttributeList(SvgElement elementToClone)
		{
			var attributeType = new ArrayList();
			var attributeName = new ArrayList();
			var attributeValue = new ArrayList();

			elementToClone.FillAttributeList(attributeType, attributeName, attributeValue);

			attributes.Clear();


			// copy the attributes
			for (var i = 0; i < attributeType.Count; i++ )
			{
				AddAttribute((SvgAttribute.SvgAttributes) attributeType[i], attributeValue[i]);
			}

			// copy the value
			if ( HasValue )
			{
				ElementValue = elementToClone.ElementValue;
			}
		}

		/// <summary>
		/// It returns a string containing current element info for logging purposes.
		/// </summary>
		/// <returns></returns>
		public string ElementInfo()
		{
			var sMsg = "InternalId:" + InternalId.ToString();

			if ( ParentElement != null )
			{
				sMsg += " - Parent:" + ParentElement.GetInternalId().ToString();
			}

			if ( PreviousElement != null )
			{
				sMsg += " - Previous:" + PreviousElement.GetInternalId().ToString();
			}

			if ( NextElement != null )
			{
				sMsg += " - Next:" + NextElement.GetInternalId().ToString();
			}

			if ( ChildElement != null )
			{
				sMsg += " - Child:" + ChildElement.GetInternalId().ToString();
			}

			return sMsg;
		}

        #endregion

        #region Private Methods

        protected SvgElement(SvgDocument doc)
		{
			LocalSvgDocument = doc;

			attributes = new ArrayList();

			AddAttribute(SvgAttribute.SvgAttributes.AttrCoreId, null);

			ParentElement = null;
			ChildElement = null;
			NextElement = null;
			PreviousElement = null;

			ElementName = "unsupported";
			ElementValue = "";
			HasValue = false;
			ElementType = SvgElementType.TypeUnsupported;
		}

		~SvgElement()
		{
			ParentElement = null;
			ChildElement = null;
			NextElement = null;
			PreviousElement = null;
		}

		protected string OpenXmlTag()
		{
		    var xml = "<" + ElementName;

			for (var i = 0; i < attributes.Count; i++ )
			{
				var attr = (SvgAttribute) attributes[i];
				xml += attr.GetXml();
			}

			if ( ElementValue == "")
			{
				if (ChildElement == null)
				{
					xml += " />\r\n";
				}
				else
				{
					xml += ">\r\n";
				}
			}
			else
			{
				xml += ">";
				xml += ElementValue;
			}
			
			return xml;
		}

		protected string CloseXmlTag()
		{
			if ( (ElementValue == "") && (ChildElement == null) )
			{
				return "";
			}
			else
			{
				return "</" + ElementName + ">\r\n";
			}
		}

		protected void AddAttribute(SvgAttribute.SvgAttributes type, object objValue)
		{
		    var attrToAdd = new SvgAttribute(type) {Value = objValue};

		    attributes.Add(attrToAdd);
		}

		internal SvgAttribute GetAttribute(string sName)
		{
		    return attributes.Cast<SvgAttribute>().FirstOrDefault(attr => attr.Name == sName);
		}

	    internal SvgAttribute GetAttribute(SvgAttribute.SvgAttributes type)
	    {
	        return attributes.Cast<SvgAttribute>().FirstOrDefault(attr => attr.AttributeType == type);
	    }

	    internal bool SetAttributeValue(string sName, string sValue)
		{
			var result = false;

			for (var i = 0; i < attributes.Count; i++ )
			{
				var attr = (SvgAttribute) attributes[i];
				if ( attr.Name == sName )
				{
					switch (attr.AttributeDataType)
					{
						case SvgAttribute.SvgAttributeDataType.DataTypeString:
						case SvgAttribute.SvgAttributeDataType.DataTypeHRef:
							attr.Value = sValue;
							break;

						case SvgAttribute.SvgAttributeDataType.DataTypeEnum:
							int nValue = 0;
							try
							{
								nValue = Convert.ToInt32(sValue);
							}
							catch
							{
							}

							attr.Value = nValue;
							break;

						case SvgAttribute.SvgAttributeDataType.DataTypeColor:

							if (sValue == "")
							{
								attr.Value = Color.Transparent;
							}
							else
							{
								Color c = attr.String2Color(sValue);
								attr.Value = c;
							}
							break;
					}

					result = true;

					break;
				}
			}
			
			return result;
		}

		internal bool SetAttributeValue(SvgAttribute.SvgAttributes type, object objValue)
		{
			bool bReturn = false;

			for (int i = 0; i < attributes.Count; i++ )
			{
				SvgAttribute attr = (SvgAttribute) attributes[i];
				if ( attr.AttributeType == type )
				{
					bReturn = true;
					attr.Value = objValue;

					break;
				}
			}
			
			return bReturn;
		}

		internal bool GetAttributeValue(SvgAttribute.SvgAttributes type, out object objValue)
		{
			bool bReturn = false;
			objValue = null;

			for (int i = 0; i < attributes.Count; i++ )
			{
				SvgAttribute attr = (SvgAttribute) attributes[i];
				if ( attr.AttributeType == type )
				{
					bReturn = true;
					objValue = attr.Value;

					break;
				}
			}
			
			return bReturn;
		}

		internal object GetAttributeValue(SvgAttribute.SvgAttributes type)
		{
			object objValue;

			if ( GetAttributeValue(type, out objValue) )
			{
				return objValue;
			}
			else
			{
				return null;
			}
		}

		internal string GetAttributeStringValue(SvgAttribute.SvgAttributes type)
		{
			object objValue = GetAttributeValue(type);

			if ( objValue != null )
			{
				return objValue.ToString();
			}
			else
			{
				return "";
			}
		}

		internal int GetAttributeIntValue(SvgAttribute.SvgAttributes type)
		{
			object objValue = GetAttributeValue(type);

			if ( objValue != null )
			{
				int nValue = 0;
				try
				{
					nValue = Convert.ToInt32(objValue.ToString());
				}
				catch
				{
				}

				return nValue;
			}
			else
			{
				return 0;
			}
		}

		internal Color GetAttributeColorValue(SvgAttribute.SvgAttributes type)
		{
			object objValue = GetAttributeValue(type);

			if ( objValue != null )
			{
				Color cValue = Color.Black;
				try
				{
					cValue = (Color) (objValue);
				}
				catch
				{
				}

				return cValue;
			}
			else
			{
				return Color.Black;
			}
		}

        #endregion

    }
}
