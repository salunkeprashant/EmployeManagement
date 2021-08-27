using System.Xml;

namespace EmployeManagement.Contracts
{
    public interface IBaseRepository
    {
        public XmlDocument GetData();
        public void RemoveElement(XmlNode xmlNode);
        public XmlNode AddElement(XmlElement ele);
        void InsertNode(XmlNode item, string nodeName, string value);
    }
}
