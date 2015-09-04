using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace SvgLibrary
{
    public class SvgDocument
	{
        #region Public Properties

	    public string ErrorMessage { get; set; }

        #endregion

        #region Private Properties

        private SvgRoot svgRoot;
		
		// document elements, hashtable key is the InternalId 
		private Hashtable svgDocumentElements;

		private int svgDocumentNextInternalId;

		private string svgDocumentXmlDeclaration;
		private string svgDocumentXmlDocumentType;

        #endregion

        #region Public Methods

        public SvgDocument()
		{
			svgRoot = null;
			svgDocumentNextInternalId = 1;
			svgDocumentElements = new Hashtable();
		}

		/// <summary>
		/// Creates a new/empty SVG document that contains just the root element.
		/// </summary>
		/// <returns>
		/// The root element of the SVG document.
		/// </returns>
		public SvgRoot CreateNewDocument()
		{
			if ( svgRoot != null )
			{
				svgRoot = null;
				svgDocumentNextInternalId = 1;
				svgDocumentElements.Clear();
			}

			svgRoot = new SvgRoot(this);
			svgRoot.SetInternalId(svgDocumentNextInternalId++);
			
			svgDocumentElements.Add(svgRoot.GetInternalId(), svgRoot);

			svgDocumentXmlDeclaration = "<?xml version=\"1.0\"?>";
			svgDocumentXmlDocumentType = "<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\" \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">";

			svgRoot.SetAttributeValue(SvgAttribute.SvgAttributes.AttrSvgXmlNs, "http://www.w3.org/2000/svg");
			svgRoot.SetAttributeValue(SvgAttribute.SvgAttributes.AttrSvgVersion, "1.1");

			return svgRoot;
		}

		/// <summary>
		/// Load SVG document from a file.
		/// </summary>
		/// <param name="filename">The complete path of a valid SVG file.</param>
		/// <returns>
		///     True - the file is loaded successfully and it is a valid SVG document
		///     False - the file cannot be opened or it is not a valid SVG document.
		/// </returns>
		public bool LoadFromFile(string filename)
		{
			if ( svgRoot != null )
			{
				svgRoot = null;
				svgDocumentNextInternalId = 1;
				svgDocumentElements.Clear();
			}

			var result = true;

			try
			{
			    var reader = new XmlTextReader(filename)
			    {
			        WhitespaceHandling = WhitespaceHandling.None,
			        Normalization = false,
			        XmlResolver = null,
			        Namespaces = false
			    };

				SvgElement parentElement = null;	

				try 
				{
					// parse the file and display each of the nodes.
					while ( reader.Read() && result ) 
					{
						switch (reader.NodeType) 
						{
							case XmlNodeType.Attribute:
								break;

							case XmlNodeType.Element:
								var element = AddElement(parentElement, reader.Name);

								if ( element != null )
								{
									parentElement = element;

									if (reader.IsEmptyElement)
									{
										if ( parentElement != null )
										{
											parentElement = parentElement.GetParent();
										}
									}

									var attribute = reader.MoveToFirstAttribute();
									while (attribute)
									{
										element.SetAttributeValue(reader.Name, reader.Value);
												
										attribute = reader.MoveToNextAttribute();
									}
								}

								break;

							case XmlNodeType.Text:
								if ( parentElement != null )
								{
									parentElement.SetElementValue(reader.Value);
								}
								break;

							case XmlNodeType.CDATA:
								break;

							case XmlNodeType.ProcessingInstruction:
								break;

							case XmlNodeType.Comment:
								break;

							case XmlNodeType.XmlDeclaration:
								svgDocumentXmlDeclaration = "<?xml " + reader.Value + "?>";
								break;

							case XmlNodeType.Document:
								break;

							case XmlNodeType.DocumentType:
							{
							    var sDtd1 = reader.GetAttribute("PUBLIC");
								var sDtd2 = reader.GetAttribute("SYSTEM");

								svgDocumentXmlDocumentType = "<!DOCTYPE svg PUBLIC \"" + sDtd1 + "\" \"" + sDtd2 + "\">";
							}
								break;

							case XmlNodeType.EntityReference:
								break;

							case XmlNodeType.EndElement:
								if ( parentElement != null )
								{
									parentElement = parentElement.GetParent();
								}
								break;
						} // switch
					} // while
				} // read try
				catch(XmlException xmle)
				{
				    ErrorMessage =
				        $"{xmle.Message}\r\nLine Number: {xmle.LineNumber.ToString()}\r\nLine Position: {xmle.LinePosition.ToString()}";

					result = false;
				}
				catch(Exception e)
				{
				    ErrorMessage = e.Message;
					result = false;
				}
				finally
				{
					reader.Close();
				}
			}
			catch
			{
				ErrorMessage = "Unhandled Exception";
				result = false;
			}

			return result;
		}

		/// <summary>
		/// It saves the current SVG document to a file.
		/// </summary>
		/// <param name="sFilename">The complete path of the file.</param>
		/// <returns>
		/// true if the file is saved successfully, false otherwise
		/// </returns>
		public bool SaveToFile(string sFilename)
		{
			var result = false;
			StreamWriter sw = null;

            try
			{
				sw = File.CreateText(sFilename);
				result = true;
			}
			catch (UnauthorizedAccessException uae)
			{
                ErrorMessage = uae.Message;
            }
            catch (DirectoryNotFoundException dnfe)
			{
                ErrorMessage = dnfe.Message;
            }
            catch (ArgumentException ae)
			{
                ErrorMessage = ae.Message;
            }
            catch
			{
                ErrorMessage = "Unhandled Exception";
            }

			if ( result )
			{
                try
                {
                    sw.Write(GetXml());
                    sw.Close();
                }
                catch
                {
                    result = false;
                }
            }

            return result;
		}

		/// <summary>
		/// It returns the XML string of the entire SVG document.
		/// </summary>
		/// <returns>
		/// The SVG document. An empty string if the document is empty.
		/// </returns>
		public string GetXml()
		{
			if ( svgRoot == null )
			{
				return "";
			}

		    var xml = svgDocumentXmlDeclaration + "\r\n";
			xml += svgDocumentXmlDocumentType;
			xml += "\r\n";
			
			xml += svgRoot.GetXml();

			return xml;
		}

		/// <summary>
		/// It returns the SvgElement with the given internal (numeric) identifier.
		/// </summary>
		/// <param name="internalId">Internal unique identifier of the element.</param>
		/// <returns>
		/// The SvgElement with the given internal Id. Null if no element can be found.
		/// </returns>
		public SvgElement GetSvgElement(int internalId)
		{
			if (!svgDocumentElements.ContainsKey(internalId))
			{
				return null;
			}

			return (SvgElement) svgDocumentElements[internalId];
		}

		/// <summary>
		/// It returns the root element of the SVG document.
		/// </summary>
		/// <returns>
		/// Root element.
		/// </returns>
		public SvgRoot GetSvgRoot()
		{
			return svgRoot;
		}

		/// <summary>
		/// It returns the SvgElement with the given XML Id.
		/// </summary>
		/// <param name="id">XML identifier of the element.</param>
		/// <returns>
		/// The SvgElement with the given XML Id. Null if no element can be found.
		/// </returns>
		public SvgElement GetSvgElement(string id)
		{
			SvgElement elementToReturn = null;

			var e = svgDocumentElements.GetEnumerator();
			
			var moveNext = e.MoveNext();
			while ( moveNext )
			{
				var value = "";

				var element = (SvgElement) e.Value;
				value = element.GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrCoreId);
				if ( value == id )
				{
					elementToReturn = element;
				}

				moveNext = e.MoveNext();
			}

			return elementToReturn;
		}

        /// <summary>
        /// It adds the new element eleToAdd as the last children of the given parent element.
        /// </summary>
        /// <param name="parent">Parent element. If null the element is added under the root.</param>
        /// <param name="eleToAdd">Element to be added.</param>
        /// <returns>
        /// true if the element is successfully, false otherwise
        /// </returns>
        public bool AddElement(SvgElement parent, SvgElement eleToAdd)
		{
			if ( eleToAdd == null || svgRoot == null )
			{
				ErrorMessage = "Element to be added and Svg Root Element were both Null.";
				return false;
			}

            SvgElement parentToAdd = svgRoot;
			if ( parent != null )
			{
				parentToAdd = parent;
			}

			eleToAdd.SetInternalId(svgDocumentNextInternalId++);
			svgDocumentElements.Add(eleToAdd.GetInternalId(), eleToAdd);

			eleToAdd.SetParent(parentToAdd);
			if (parentToAdd.GetChild() == null )
			{
				// the element is the first child
				parentToAdd.SetChild(eleToAdd);
			}
			else
			{
				// add the element as the last sibling
				var last = GetLastSibling(parentToAdd.GetChild());

				if ( last != null )
				{
					last.SetNext(eleToAdd);
					eleToAdd.SetPrevious(last);
				}
			}

            return true;
		}

		/// <summary>
		/// It creates a new element according to the element name provided
		/// and it adds the new element as the last children of the given parent element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <param name="name">SVG element name.</param>
		/// <returns>The new created element.</returns>
		public SvgElement AddElement(SvgElement parent, string name)
		{
			SvgElement eleToReturn = null;

			if ( name == "svg" )
			{
				svgRoot = new SvgRoot(this);
				svgRoot.SetInternalId(svgDocumentNextInternalId++);
			
				svgDocumentElements.Add(svgRoot.GetInternalId(), svgRoot);
				eleToReturn = svgRoot;
			}
			else if ( name == "desc" )
			{
				eleToReturn = AddDesc(parent);
			}
			else if ( name == "text" )
			{
				eleToReturn = AddText(parent);
			}
			else if ( name == "g" )
			{
				eleToReturn = AddGroup(parent);
			}
			else if ( name == "rect" )
			{
				eleToReturn = AddRect(parent);
			}
			else if ( name == "circle" )
			{
				eleToReturn = AddCircle(parent);
			}
			else if ( name == "ellipse" )
			{
				eleToReturn = AddEllipse(parent);
			}
			else if ( name == "line" )
			{
				eleToReturn = AddLine(parent);
			}
			else if ( name == "path" )
			{
				eleToReturn = AddPath(parent);
			}
			else if ( name == "polygon" )
			{
				eleToReturn = AddPolygon(parent);
			}
			else if ( name == "image" )
			{
				eleToReturn = AddImage(parent);
			}
			else
			{
				if ( parent != null )
				{
					eleToReturn = AddUnsupported(parent, name);
				}
			}

			return eleToReturn;
		}

		/// <summary>
		/// It creates a new element copying all attributes from elementToClone; the new
		/// element is inserted under the parent element provided. 
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <param name="elementToClone">Element to be cloned</param>
		/// <returns></returns>
		public SvgElement CloneElement(SvgElement parent, SvgElement elementToClone)
		{
			// calculate unique id
			var sOldId = elementToClone.GetAttributeStringValue(SvgAttribute.SvgAttributes.AttrCoreId);
			var sNewId = sOldId;
			
			if ( sOldId != "" )
			{
				int i = 1;
				
				// check if it is unique
				while ( GetSvgElement(sNewId) != null )
				{
					sNewId = sOldId + "_" + i.ToString();
					i++;
				} 
			}

			// clone operation
			var newElement = AddElement(parent, elementToClone.GetElementName());
			newElement.CloneAttributeList(elementToClone);

			if ( sNewId != "" )
			{
				newElement.SetAttributeValue(SvgAttribute.SvgAttributes.AttrCoreId, sNewId);
			}

			if ( elementToClone.GetChild() != null )
			{
				newElement.SetChild(CloneElement(newElement, elementToClone.GetChild()));

				if ( elementToClone.GetChild().GetNext() != null )
				{
					newElement.GetChild().SetNext(CloneElement(newElement, elementToClone.GetChild().GetNext()));
				}
			}

			return newElement;
		}

		/// <summary>
		/// It creates a new SVG Unsupported element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <param name="name">Name</param>
		/// <returns>
		/// New element created.
		/// </returns>
		/// <remarks>
		/// The unsupported element is used when during the parsing of a file an unknown
		/// element tag is found.
		/// </remarks>
		public SvgUnsupported AddUnsupported(SvgElement parent, string name)
		{
			var uns = new SvgUnsupported(this, name);
			
			AddElement(parent, uns);
			
			return uns;
		}

		/// <summary>
		/// It creates a new SVG Desc element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <returns>New element created.</returns>
		public SvgDesc AddDesc(SvgElement parent)
		{
			var desc = new SvgDesc(this);
			
			AddElement(parent, desc);
			
			return desc;
		}

		/// <summary>
		/// It creates a new SVG Group element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <returns>New element created.</returns>
		public SvgGroup AddGroup(SvgElement parent)
		{
			var grp = new SvgGroup(this);
			
			AddElement(parent, grp);
			
			return grp;
		}
		
		/// <summary>
		/// It creates a new SVG Text element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <returns>New element created.</returns>
		public SvgText AddText(SvgElement parent)
		{
			var txt = new SvgText(this);
			
			AddElement(parent, txt);
			
			return txt;
		}

		/// <summary>
		/// It creates a new SVG Rect element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <returns>New element created.</returns>
		public SvgRect AddRect(SvgElement parent)
		{
			var rect = new SvgRect(this);
			
			AddElement(parent, rect);
			
			return rect;
		}

		/// <summary>
		/// It creates a new SVG Circle element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <returns>New element created.</returns>
		public SvgCircle AddCircle(SvgElement parent)
		{
			var circle = new SvgCircle(this);
			
			AddElement(parent, circle);
			
			return circle;
		}

		/// <summary>
		/// It creates a new SVG Ellipse element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <returns>New element created.</returns>
		public SvgEllipse AddEllipse(SvgElement parent)
		{
			var ellipse = new SvgEllipse(this);
			
			AddElement(parent, ellipse);
			
			return ellipse;
		}

		/// <summary>
		/// It creates a new SVG Line element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <returns>New element created.</returns>
		public SvgLine AddLine(SvgElement parent)
		{
			var line = new SvgLine(this);
			
			AddElement(parent, line);
			
			return line;
		}

		/// <summary>
		/// It creates a new SVG Path element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <returns>New element created.</returns>
		public SvgPath AddPath(SvgElement parent)
		{
			var path = new SvgPath(this);
			
			AddElement(parent, path);
			
			return path;
		}

		/// <summary>
		/// It creates a new SVG Polygon element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <returns>New element created.</returns>
		public SvgPolygon AddPolygon(SvgElement parent)
		{
			var poly = new SvgPolygon(this);
			
			AddElement(parent, poly);
			
			return poly;
		}

		/// <summary>
		/// It creates a new SVG Image element.
		/// </summary>
		/// <param name="parent">Parent element. If null the element is added under the root.</param>
		/// <returns>New element created.</returns>
		public SvgImage AddImage(SvgElement parent)
		{
			var img = new SvgImage(this);
			
			AddElement(parent, img);
			
			return img;
		}

		/// <summary>
		/// It deletes an element from the document.
		/// </summary>
		/// <param name="element">Element to be deleted.</param>
		/// <returns>
		/// true if the element has been successfully deleted; false otherwise.
		/// </returns>
		public bool DeleteElement(SvgElement element)
		{
			return DeleteElement(element, true);
		}

		/// <summary>
		/// It deletes an element from the document.
		/// </summary>
		/// <param name="internalId">Internal Id of the element to be deleted.</param>
		/// <returns>
		/// true if the element has been successfully deleted; false otherwise.
		/// </returns>
		public bool DeleteElement(int internalId)
		{
			return DeleteElement(GetSvgElement(internalId), true);
		}

		/// <summary>
		/// It deletes an element from the document.
		/// </summary>
		/// <param name="id">XML Id of the element to be deleted.</param>
		/// <returns>
		/// true if the element has been successfully deleted; false otherwise.
		/// </returns>
		public bool DeleteElement(string id)
		{
			return DeleteElement(GetSvgElement(id), true);
		}

		/// <summary>
		/// It moves the element before its current previous sibling.
		/// </summary>
		/// <param name="element">Element to be moved.</param>
		/// <returns>
		/// true if the operation succeeded.
		/// </returns>
		public bool ElementPositionUp(SvgElement element)
		{
			var parent = element.GetParent();
			if ( parent == null )
			{
				ErrorMessage = "Root node cannot be moved";
				return false;
			}

			if ( IsFirstChild(element) )
			{
                ErrorMessage = "Element is already at the first position";
				return false;
			}

			var next = element.GetNext();
			var previous = element.GetPrevious();
			SvgElement previous2 = null;

			element.SetNext(null);
			element.SetPrevious(null);

			// fix Next
			if ( next != null )
			{
				next.SetPrevious(previous);
			}

			// fix Previous
			if ( previous != null )
			{
				previous.SetNext(next);
				previous2 = previous.GetPrevious();
				previous.SetPrevious(element);

				// check if the Previous is the first child
				if ( IsFirstChild(previous) )
				{
					// if yes the moved element has to became the new first child
					if ( previous.GetParent() != null )
					{
						previous.GetParent().SetChild(element);
					}
				}
			}

			// fix Previous/Previous
			if ( previous2 != null )
			{
				previous2.SetNext(element);
			}

			// fix Element
			element.SetNext(previous);
			element.SetPrevious(previous2);

			return true;
		}

		/// <summary>
		/// It moves the element one level up in the tree hierarchy.
		/// </summary>
		/// <param name="element">Element to be moved.</param>
		/// <returns>
		/// true if the operation succeeded.
		/// </returns>
		public bool ElementLevelUp(SvgElement element)
		{
			var parent = element.GetParent();
			if ( parent == null )
			{
				ErrorMessage = "Root node cannot be moved";
				return false;
			}

			if ( parent.GetParent() == null )
			{
                ErrorMessage = "An element cannot be moved up to the root";
				return false;
			}
				
			var next = element.GetNext();
				
			// the first child of the parent became the next
			parent.SetChild(next);

			if ( next != null )
			{
				next.SetPrevious(null);
			}

			// get the last sibling of the parent
			var last = GetLastSibling(parent);
			if ( last != null )
			{
				last.SetNext(element);
			}

			element.SetParent(parent.GetParent());
			element.SetPrevious(last);
			element.SetNext(null);

			return true;
		}

		/// <summary>
		/// It moves the element after its current next sibling.
		/// </summary>
		/// <param name="element">Element to be moved.</param>
		/// <returns>
		/// true if the operation succeeded.
		/// </returns>
		public bool ElementPositionDown(SvgElement element)
		{
			var parent = element.GetParent();
			if ( parent == null )
			{
                ErrorMessage = "Root node cannot be moved";
				return false;
			}

			if ( IsLastSibling(element) )
			{
                ErrorMessage = "Element is already at the last sibling position";
				return false;
			}
			
			var next = element.GetNext();
			SvgElement next2 = null;
			var previous = element.GetPrevious();
			
			// fix Next
			if ( next != null )
			{
				next.SetPrevious(element.GetPrevious());
				next2 = next.GetNext();
				next.SetNext(element);
			}

			// fix Previous
			if ( previous != null )
			{
				previous.SetNext(next);
			}

			// fix Element
			if ( IsFirstChild(element) )
			{
				parent.SetChild(next);
			}

			element.SetPrevious(next);
			element.SetNext(next2);

			if ( next2 != null )
			{
				next2.SetPrevious(element);
			}
				
			return true;
		}

        #endregion

        #region Private Methods
        private bool DeleteElement(SvgElement element, bool deleteFromParent)
		{
			if ( element == null )
			{
				return false;
			}

			var parent = element.GetParent();
			if ( parent == null )
			{
                // root node cannot be delete!
                ErrorMessage = "root node cannot be delete!";
				return false;
			}

			// set the Next reference of the previous
			if ( element.GetPrevious() != null )
			{
				element.GetPrevious().SetNext(element.GetNext());
			}

			// set the Previous reference of the next
			if ( element.GetNext() != null )
			{
				element.GetNext().SetPrevious(element.GetPrevious());
			}

			// check if the element is the first child
			// the deleteFromParent flag is used to avoid deleting
			// all parent-child relationship. This is used in the Cut
			// operation where the subtree can be pasted 
			if ( deleteFromParent )
			{
				if ( IsFirstChild(element) )
				{
					// set the Child reference of the parent to the next
					element.GetParent().SetChild(element.GetNext());
				}
			}

			// delete its children
			var child = element.GetChild();

			while ( child != null )
			{
				DeleteElement(child, false);
				child = child.GetNext();
			}

			// delete the element from the colloection
			svgDocumentElements.Remove(element.GetInternalId());

			return true;
		}

		private bool IsFirstChild(SvgElement element)
		{
			if ( element.GetParent() == null )
			{
				return false;
			}

			if ( element.GetParent().GetChild() == null )
			{
				return false;
			}

			return (element.GetInternalId() == element.GetParent().GetChild().GetInternalId());
		}

		private bool IsLastSibling(SvgElement element)
		{
			SvgElement last = GetLastSibling(element);

			if ( last == null )
			{
				return false;
			}

			return (element.GetInternalId() == last.GetInternalId());
		}

		private SvgElement GetLastSibling(SvgElement element)
		{
			if ( element == null )
			{
				return null;
			}

			var last = element;
			while (last.GetNext() != null)
			{
				last = last.GetNext();
			}
			
			return last;
		}

        #endregion
    }
}
