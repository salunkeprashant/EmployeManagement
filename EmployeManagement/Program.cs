using EmployeManagement.Contracts;
using EmployeManagement.DataAccess;
using EmployeManagement.Manager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Xml;

namespace EmployeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Register dependencies and service provider
            var serviceProvider = BuildServiceProvider();
            var employeeManagement = serviceProvider.GetService<IEmployeeManagement>();

            Console.WriteLine("1. Show Employees");
            Console.WriteLine("2. Remove Employee");
            Console.WriteLine("3. Add Employee");
            Console.WriteLine("4. Add New Node");

            Console.WriteLine("\n");

            Console.Write("Please choose you input =");
            var input = Console.ReadLine();

            int choice = Convert.ToInt32(input);



            switch (choice)
            {
                // Show data 
                case 1:
                    employeeManagement.ViewAllEmployee();
                    break;

                // Remove Data
                case 2:
                    employeeManagement.RemoveEmployee("name", "Mohan");
                    break;

                // Add New
                case 3:
                    string data = @"<employee>
                                        <name>Prashant</name>
                                        <age>28</age>
                                        <designation>Developer</designation>
	                        </employee>";
                    employeeManagement.AddEmployee(data);
                    break;

                // Add New Node
                case 4:
                    Func<XmlNode, bool> predicate = x => x["name"].InnerText.ToLower() == "Mohan".ToLower();
                    employeeManagement.InsertNode(predicate, "Address", "Pune");
                    break;
            }

            Console.ReadLine();
        }

        static ServiceProvider BuildServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IBaseRepository, BaseRepository>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IEmployeeManagement, EmployeeManagement>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}