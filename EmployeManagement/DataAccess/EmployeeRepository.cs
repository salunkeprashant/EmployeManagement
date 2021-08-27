using EmployeManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace EmployeManagement.DataAccess
{
    class EmployeeRepository : IEmployeeRepository
    {
        public IBaseRepository baseRepository;
        public XmlDocument data;

        public EmployeeRepository(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public XmlNodeList GetEmployeeList()
        {
            if (this.data is null)
            {
                this.data = baseRepository.GetData();
            }

            return data.GetElementsByTagName("employee");
        }

        public void RemoveEmployee(XmlNode xmlNode)
        {
            this.baseRepository.RemoveElement(xmlNode);
        }

        public XmlNode AddEmployee(XmlElement xmlElement)
        {
            return this.baseRepository.AddElement(xmlElement);
        }

        public void InsertNode(XmlNode item, string nodeName, string value)
        {
            this.baseRepository.InsertNode(item, nodeName, value);
        }
    }
}
