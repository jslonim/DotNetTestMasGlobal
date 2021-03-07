using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTestMasGlobal.Business.DTO
{
    public abstract class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public float HourlySalary { get; set; }
        public float MonthlySalary { get; set; }
        public float AnualSalary { get; set; }
    }
}
