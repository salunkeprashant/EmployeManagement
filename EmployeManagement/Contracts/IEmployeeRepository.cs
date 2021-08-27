using System.Xml;

namespace EmployeManagement.Contracts
{
    public interface IEmployeeRepository
    {
        public XmlNodeList GetEmployeeList();

        public void RemoveEmployee(XmlNode xmlNode);

        public XmlNode AddEmployee(XmlElement element);
        void InsertNode(XmlNode item, string nodeName, string value);
    }
}
