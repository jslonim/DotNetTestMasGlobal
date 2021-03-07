using DotNetTestMasGlobal.Business.DTO;
using DotNetTestMasGlobal.Business.Enums;
using DotNetTestMasGlobal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTestMasGlobal.Business.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeDTO Create(Employee employee) {

            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.Id = employee.Id;
            employeeDTO.Name = employee.Name;
            employeeDTO.ContractTypeName = employee.ContractTypeName;
            employeeDTO.RoleId = employee.RoleId;
            employeeDTO.RoleName = employee.RoleName;
            employeeDTO.RoleDescription = employee.RoleDescription;
            employeeDTO.HourlySalary = employee.HourlySalary;
            employeeDTO.MonthlySalary = employee.MonthlySalary;
         
            if (employee.ContractTypeName == EmployeeEnums.ContractTypeName.HourlySalaryEmployee.ToString())
            {
                employeeDTO.AnualSalary = 120 * employeeDTO.HourlySalary * 12;
            }
            else if (employee.ContractTypeName == EmployeeEnums.ContractTypeName.MonthlySalaryEmployee.ToString())
            {
                employeeDTO.AnualSalary = employeeDTO.MonthlySalary * 12;
            }

            return employeeDTO;
        }
    }
}
