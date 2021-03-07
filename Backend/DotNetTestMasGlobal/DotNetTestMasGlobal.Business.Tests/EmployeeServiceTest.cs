
using DotNetTestMasGlobal.Business.DTO;
using DotNetTestMasGlobal.Data.Entities;
using DotNetTestMasGlobal.Data.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTestMasGlobal.Business.Tests
{
    public class EmployeeServiceTest
    {
        Mock<IEmployeeRepository> employeeRepository;
        List<Employee> employees;
        EmployeeService service;
        [SetUp]
        public void Setup()
        {
            employeeRepository = new Mock<IEmployeeRepository>();
            service = new EmployeeService(employeeRepository.Object);
            employees = CreateEmployeeList();
        }

        [Test]
        public void Test_GetEmployeeById_WithEmployeeFound_ShouldReturnEmployee()
        {
            employeeRepository.Setup(x => x.GetEmployees()).Returns(Task.FromResult<List<Employee>>(employees));

            EmployeeDTO result = service.GetEmployeeById(2).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(employees[0].Id, result.Id);
            Assert.AreEqual(employees[0].Name, result.Name);
            Assert.AreEqual(employees[0].ContractTypeName, result.ContractTypeName);
            Assert.AreEqual(employees[0].RoleId, result.RoleId);
            Assert.AreEqual(employees[0].RoleName, result.RoleName);
            Assert.AreEqual(employees[0].RoleDescription, result.RoleDescription);
            Assert.AreEqual(employees[0].HourlySalary, result.HourlySalary);
            Assert.AreEqual(employees[0].MonthlySalary, result.MonthlySalary);
            Assert.IsTrue(result.AnualSalary > 0);
        }

        [Test]
        public void Test_GetEmployeeById_WithEmployeeFound_ShouldReturnNull()
        {
            employeeRepository.Setup(x => x.GetEmployees()).Returns(Task.FromResult<List<Employee>>(employees));

            EmployeeDTO result = service.GetEmployeeById(0).Result;

            Assert.IsNull(result);
        }

        public List<Employee> CreateEmployeeList() {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 2,
                    Name = "Alex",
                    ContractTypeName = "MonthlySalaryEmployee",
                    RoleId = 2,
                    RoleName = "Contractor",
                    RoleDescription = null,
                    HourlySalary = 10000.0,
                    MonthlySalary = 50000.0,
                }
            };
        }
    }
}
