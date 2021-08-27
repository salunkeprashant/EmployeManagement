using EmployeManagement.Contracts;
using System.IO;
using System.Xml;

namespace EmployeManagement.DataAccess
{
    public class BaseRepository : IBaseRepository
    {
        public XmlDocument document;

        public string filePath = Directory.GetCurrentDirectory() + "\\Data\\Employee.xml";

        public BaseRepository()
        {
            if (this.document is null)
            {
                this.GetData();
            }
        }

        public XmlDocument GetData()
        {
            this.document = new XmlDocument();

            this.document.Load(this.filePath);

            return this.document;
        }

        public void RemoveElement(XmlNode xmlNode)
        {
            xmlNode.ParentNode.RemoveChild(xmlNode);
            this.document.Save(this.filePath);
        }

        public XmlNode AddElement(XmlElement ele)
        {
            var newElement = this.document.ImportNode(ele.OwnerDocument.LastChild, true);

            this.document.DocumentElement.AppendChild(newElement);

            this.document.Save(filePath);

            return newElement;
        }

        public void InsertNode(XmlNode item, string nodeName, string value)
        {
            XmlElement newElement = this.document.CreateElement(nodeName);
            newElement.InnerText = value;

            var refNode = item.LastChild;

            item.InsertAfter(newElement, refNode);

            this.document.Save(filePath);
        }
    }
}
