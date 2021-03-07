using DotNetTestMasGlobal.Data.Entities;
using DotNetTestMasGlobal.Data.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTestMasGlobal.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string _endpointURL;
        public EmployeeRepository(string endpointURL)
        {
            _endpointURL = endpointURL;
        }

        public async Task<List<Employee>> GetEmployees() {
            HttpClient client = new HttpClient();

            List<Employee> employeeList = new List<Employee>();
            HttpResponseMessage response = await client.GetAsync(_endpointURL);
            if (response.IsSuccessStatusCode)
            {
                employeeList = JsonConvert.DeserializeObject<List<Employee>>(response.Content.ReadAsStringAsync().Result);
            }
            else { 
                throw new Exception("Failed to make a connection to the employee endpoint");
            }
            return employeeList;
        }

    }
}
