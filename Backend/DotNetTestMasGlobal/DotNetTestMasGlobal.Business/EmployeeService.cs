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
               employeeDTOList.Add(EmployeeFactory.Create(employee));
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
                    return EmployeeFactory.Create(employee);
                }
            }
            return null;
        }
    }
}
