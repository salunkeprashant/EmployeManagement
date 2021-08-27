using System;
using System.Xml;

namespace EmployeManagement.Contracts
{
    public interface IEmployeeManagement
    {
        public void ViewAllEmployee();

        public void RemoveEmployee(string property, string value);

        public XmlNode AddEmployee(string xmlObj);

        public void InsertNode(Func<XmlNode, bool> predicate, string nodeName, string value);
    }
}
