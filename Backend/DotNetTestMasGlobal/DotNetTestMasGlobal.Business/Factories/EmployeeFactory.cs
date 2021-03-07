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
            //Del enunciado entendi que se requeria un tipo de DTO distinto para cada tipo de worker, aca estan usados con el patron factory
            //aunque sean iguales y no necesiten distincion del DTO original, usandolos para mapear de manera correspondiente la data y el AnualSalary
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
