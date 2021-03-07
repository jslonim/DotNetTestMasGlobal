using DotNetTestMasGlobal.Business.DTO;
using DotNetTestMasGlobal.Business.Entities;
using DotNetTestMasGlobal.Business.Enums;
using DotNetTestMasGlobal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTestMasGlobal.Business.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeDTO CreateEmployee(EmployeeEnums.ContractTypeName contractTypeName, Employee employee) {
            if (contractTypeName == EmployeeEnums.ContractTypeName.HourlySalaryEmployee)
            {
                return new HourlySalaryEmployee(employee);
            }
            else {
                return new MonthlySalaryEmployee(employee);
            }
        }
    }
}
