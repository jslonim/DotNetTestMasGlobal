using DotNetTestMasGlobal.Business.DTO;
using DotNetTestMasGlobal.Business.Enums;
using DotNetTestMasGlobal.Business.Factories;
using DotNetTestMasGlobal.Business.Interfaces;
using DotNetTestMasGlobal.Data.Entities;
using DotNetTestMasGlobal.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTestMasGlobal.Business
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<EmployeeDTO>> GetEmployees() {
            List<EmployeeDTO> employeeDTOList = new List<EmployeeDTO>();
            List<Employee> employeeList = await _repository.GetEmployees();
            foreach (var employee in employeeList)
            {
                //In this case we ignore posible workers without contract type, we could add an else with exception for that case.
                if (employee.ContractTypeName == EmployeeEnums.ContractTypeName.HourlySalaryEmployee.ToString())
                {
                    employeeDTOList.Add(EmployeeFactory.CreateEmployee(EmployeeEnums.ContractTypeName.HourlySalaryEmployee, employee));
                }
                else if (employee.ContractTypeName == EmployeeEnums.ContractTypeName.MonthlySalaryEmployee.ToString())
                {
                    employeeDTOList.Add(EmployeeFactory.CreateEmployee(EmployeeEnums.ContractTypeName.MonthlySalaryEmployee, employee));
                }
            }
            return employeeDTOList;
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            List<Employee> employeeList = await _repository.GetEmployees();
            foreach (var employee in employeeList)
            {
                if (employee.Id == id)
                {
                    if (employee.ContractTypeName == EmployeeEnums.ContractTypeName.HourlySalaryEmployee.ToString())
                    {
                        return EmployeeFactory.CreateEmployee(EmployeeEnums.ContractTypeName.HourlySalaryEmployee, employee);
                    }
                    else if (employee.ContractTypeName == EmployeeEnums.ContractTypeName.MonthlySalaryEmployee.ToString())
                    {
                        return EmployeeFactory.CreateEmployee(EmployeeEnums.ContractTypeName.MonthlySalaryEmployee, employee);
                    }
                }
            }
            return null;
        }
    }
}
