using EmployeManagement.Contracts;
using EmployeManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace EmployeManagement.Manager
{
    public class EmployeeManagement : IEmployeeManagement
    {
        public IEmployeeRepository employeeRepository;
        public EmployeeManagement(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void ViewAllEmployee()
        {
            XmlNodeList empList = this.employeeRepository.GetEmployeeList();

            foreach (XmlNode item in empList)
            {
                foreach (XmlNode emp in item.ChildNodes)
                {
                    Console.Write(emp.Name + " - " + emp.InnerText + " ");
                }
                Console.WriteLine("\n");
            }
        }

        public void RemoveEmployee(string property, string value)
        {
            XmlNodeList empList = this.employeeRepository.GetEmployeeList();

            Func<XmlNode, bool> predicate = x => x[property].InnerText.ToLower() == value.ToLower();
            var item = empList.Cast<XmlNode>().Where(predicate).FirstOrDefault();
           
            this.employeeRepository.RemoveEmployee(item);
        }

        public XmlNode AddEmployee(string employee)
        {
            XElement element = XElement.Parse(employee);
            var xmlElement = element.ToXmlElement();

            return this.employeeRepository.AddEmployee(xmlElement);
        }

        public void InsertNode(Func<XmlNode, bool> predicate, string nodeName, string value)
        {
            XmlNodeList empList = this.employeeRepository.GetEmployeeList();

            var item = empList.Cast<XmlNode>().Where(predicate).FirstOrDefault();

            this.employeeRepository.InsertNode(item, nodeName, value);
        }
    }
}
