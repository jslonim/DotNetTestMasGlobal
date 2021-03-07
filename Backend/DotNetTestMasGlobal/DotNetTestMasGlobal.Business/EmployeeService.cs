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
                //Ignoramos posibles trabajadores que vengan sin type espefico, pero podriamos loguear una irregularidad y tenerla en cuenta.
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
            //Este es el metodo mas general y simple que pude hacer en este tiempo, aun podriamos pasarlo a una Base de datos y buscar por Id mas rapido
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
