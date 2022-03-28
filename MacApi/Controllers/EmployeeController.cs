using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MacApi.Models;
using MacApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MacApi.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeData _employeeData;
        public EmployeeController (IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        // GET: api/values
        [HttpGet, Route("getAll")]
        public IActionResult Get()
        {
            if(_employeeData.GetEmployees().Count() > 0)
            {
                return Ok(_employeeData.GetEmployees());
            }
            else
            {
                return BadRequest("Vacio");
            }

            
        }

        // GET api/values/5
        [HttpGet, Route("GetOne/{codigo}")]
        public IActionResult Get(int codigo)
        {

            if(codigo > 0)
            {
               return Ok(_employeeData.GetEmployee(codigo));
            }
            else
            {
                return BadRequest("Este empleado no existe");
            }
            
        }

        // POST api/values
        [HttpPost, Route("addOne")]
        public IActionResult Post(Employee employee)
        {
            if (employee != null)
            {
                return Ok(_employeeData.AddEmployee(employee));
            }
            else
            {
                return BadRequest("Vacio");
            }
        }

        // PUT api/values/5
        [HttpPut, Route("UpdateOne")]
        public IActionResult Put(Employee employee)
        {
            if (employee != null)
            {

                return Ok(_employeeData.ModifyEmployee(employee));
            }
            else
            {
                return BadRequest("Vacio");
            }
        }

        
        [HttpDelete, Route("DeleteOne/{codigo}")]
        public IActionResult Delete(int codigo)
        {
            if (_employeeData.GetEmployee(codigo) != null)
            {
                _employeeData.DeleteEmployee(codigo);
                return Ok();
            }
            else
            {
                return BadRequest("Vacio");
            }

        }
    }
}
