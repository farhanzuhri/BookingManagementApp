using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
        //membuat endpoint routing untuk role controller 
        [ApiController]
        [Route("api/[controller]")]
        public class RoleController : ControllerBase
        {
            //membuat role repository untuk mengakses database sebagai readonly dan private
            private readonly IRoleRepository _roleRepository;
            
            public RoleController(IRoleRepository roleRepository)
            {
                _roleRepository = roleRepository;
            }
            //method get dari http untuk getall universities
            [HttpGet]
            public IActionResult GetAll()
            {
                var result = _roleRepository.GetAll();
                if (!result.Any())
                {
                    return NotFound("Data Not Found");
                }

                return Ok(result);
            }
            //method get dari http untuk getByGuid role
            [HttpGet("{guid}")]
            public IActionResult GetByGuid(Guid guid)
            {
                var result = _roleRepository.GetByGuid(guid);
                if (result is null)
                {
                    return NotFound("Data Not Found");

                }
                return Ok(result);
            }
            //method post dari http untuk create role
            [HttpPost]
            public IActionResult Create(Role role)
            {
                var result = _roleRepository.Create(role);
                if (result is null)
                {
                    return BadRequest("Failed To Create Data");
                }
                return Ok(result);
            }

            //method put dari http untuk Update role
            [HttpPut]
            public IActionResult Update(Role role)
            {
                var result = _roleRepository.Update(role);
                if (!result)
                {
                    return BadRequest("Failed To Update Data");
                }

                return Ok(result);
            }
            //method delete dari http untuk delete role
            [HttpDelete]
            public IActionResult Delete(Guid guid)
            {
                var role = _roleRepository.GetByGuid(guid);
                var result = _roleRepository.Delete(role);
                if (!result)
                {
                    return BadRequest("Failed To Delete Data");
                }

                return Ok(result);
            }
        }
    }

