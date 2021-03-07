using DotNetTestMasGlobal.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTestMasGlobal.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetEmployees();

        Task<EmployeeDTO> GetEmployeeById(int id);
    }
}
