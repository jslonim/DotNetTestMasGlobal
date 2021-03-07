using DotNetTestMasGlobal.Business.DTO;
using DotNetTestMasGlobal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTestMasGlobal.Business.Entities
{
    public class HourlySalaryEmployee : EmployeeDTO
    {
        public HourlySalaryEmployee(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = employee.ContractTypeName;
            RoleId = employee.RoleId;
            RoleName = employee.RoleName;
            RoleDescription = employee.RoleDescription;
            HourlySalary = employee.HourlySalary;
            MonthlySalary = employee.MonthlySalary;
            AnualSalary = 120 * HourlySalary * 12;
        }
    }
}
