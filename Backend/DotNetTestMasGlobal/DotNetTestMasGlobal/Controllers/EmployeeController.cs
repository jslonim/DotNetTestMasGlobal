using DotNetTestMasGlobal.Business.DTO;
using DotNetTestMasGlobal.Business.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTestMasGlobal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //Al hacer este ejercicio, claramente es notable que esta hecho de una forma simple pero que muchas cosas pueden ser agregadas
        //Cosas que podrian ser agregadas en el futuro:
        //Agregar cache para los resultados ya que son los mismos casi siempre
        //Base de datos
        //Autenticacion
        //Proyecto de Shared para helpers, excepciones custom y demas
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [Route("GetEmployees")]
        [HttpGet]
        public IActionResult  GetEmployees() 
        {
            return Ok(_employeeService.GetEmployees().Result);
        }

        [Route("GetEmployeeById/{id}")]
        [HttpGet]
        public IActionResult GetEmployeeById(int id)
        {
            EmployeeDTO result = _employeeService.GetEmployeeById(id).Result;
            if (result == null)
            {
                return NoContent();
            }
            else {
                return Ok(result);
            }

        }
    }
}
