using EmployeManagement.Contracts;
using EmployeManagement.Helpers;
using Moq;
using System;
using System.Xml;
using System.Xml.Linq;
using Xunit;

namespace EmployeManagement.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Test_GetAllEmployees()
        {
            // Arrange
            Mock<IEmployeeRepository> mockEmpRepo = new Mock<IEmployeeRepository>();
            mockEmpRepo.Setup(x => x.GetEmployeeList()).Returns(this.GetMockData());

            // Act
            var data = mockEmpRepo.Object.GetEmployeeList();

            // Assert
            Assert.Equal(this.GetMockData(), data);
        }

        [Fact]
        public void Test_AddNewEmployees()
        {
            // Arrange
            Mock<IEmployeeRepository> mockEmpRepo = new Mock<IEmployeeRepository>();

            var element = XElement.Parse(@"<employee>
                                        <name>Prashant</name>
                                        <age>28</age>
                                        <designation>Developer</designation>
	                        </employee>").ToXmlElement();

            mockEmpRepo.Setup(x => x.AddEmployee(element)).Returns(this.NewEmployeData());

            // Act
            var result = mockEmpRepo.Object.AddEmployee(element);

            // Assert
            Assert.Equal(this.NewEmployeData(), result);
        }

        private XmlNode NewEmployeData()
        {
            return XElement.Parse(@"<employee>
                                        <name>Prashant</name>
                                        <age>28</age>
                                        <designation>Developer</designation>
	                        </employee>").ToXmlElement();
        }

        private XmlNodeList GetMockData()
        {
            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(@"<employees>
	                                        <employee>
	                                        	<name>Mohan</name>
	                                        	<age>25</age>
	                                        	<designation>Developer</designation>
	                                        </employee>
	                                        
	                                        <employee>
	                                        	<name>Anitha</name>
	                                        	<age>40</age>
	                                        	<designation>Senior Developer</designation>
	                                        </employee>
                                    </employees>");

            return xmlDocument.GetElementsByTagName("employee");
        }
    }
}
