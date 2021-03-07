using DotNetTestMasGlobal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTestMasGlobal.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
    }
}
