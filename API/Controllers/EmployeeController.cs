using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
        //membuat endpoint routing untuk employee controller 
        [ApiController]
        [Route("api/[controller]")]
        public class EmployeeController : ControllerBase
        {
            //membuat employee repository untuk mengakses database sebagai readonly dan private
            private readonly IEmployeeRepository _employeeRepository;
            
            public EmployeeController(IEmployeeRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }
            //method get dari http untuk getall universities
            [HttpGet]
            public IActionResult GetAll()
            {
                var result = _employeeRepository.GetAll();
                if (!result.Any())
                {
                    return NotFound("Data Not Found");
                }

                return Ok(result);
            }
            //method get dari http untuk getByGuid employee
            [HttpGet("{guid}")]
            public IActionResult GetByGuid(Guid guid)
            {
                var result = _employeeRepository.GetByGuid(guid);
                if (result is null)
                {
                    return NotFound("Data Not Found");

                }
                return Ok(result);
            }
            //method post dari http untuk create employee
            [HttpPost]
            public IActionResult Create(Employee employee)
            {
                var result = _employeeRepository.Create(employee);
                if (result is null)
                {
                    return BadRequest("Failed To Create Data");
                }
                return Ok(result);
            }

            //method put dari http untuk Update employee
            [HttpPut]
            public IActionResult Update(Employee employee)
            {
                var result = _employeeRepository.Update(employee);
                if (!result)
                {
                    return BadRequest("Failed To Update Data");
                }

                return Ok(result);
            }
        //method delete dari http untuk delete employee
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
            {
                var employee = _employeeRepository.GetByGuid(guid);
                var result = _employeeRepository.Delete(employee);
                if (!result)
                {
                    return BadRequest("Failed To Delete Data");
                }

                return Ok(result);
            }
        }
    }
