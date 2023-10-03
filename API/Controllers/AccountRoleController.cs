using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
        //membuat endpoint routing untuk accountRole controller 
        [ApiController]
        [Route("api/[controller]")]
        public class AccountRoleController : ControllerBase
        {
            //membuat accountRole repository untuk mengakses database sebagai readonly dan private
            private readonly IAccountRoleRepository _accountRoleRepository;
           
            public AccountRoleController(IAccountRoleRepository accountRoleRepository)
            {
                _accountRoleRepository = accountRoleRepository;
            }
            //method get dari http untuk getall universities
            [HttpGet]
            public IActionResult GetAll()
            {
                var result = _accountRoleRepository.GetAll();
                if (!result.Any())
                {
                    return NotFound("Data Not Found");
                }

                return Ok(result);
            }
            //method get dari http untuk getByGuid accountRole
            [HttpGet("{guid}")]
            public IActionResult GetByGuid(Guid guid)
            {
                var result = _accountRoleRepository.GetByGuid(guid);
                if (result is null)
                {
                    return NotFound("Data Not Found");

                }
                return Ok(result);
            }
            //method post dari http untuk create accountRole
            [HttpPost]
            public IActionResult Create(AccountRole accountRole)
            {
                var result = _accountRoleRepository.Create(accountRole);
                if (result is null)
                {
                    return BadRequest("Failed To Create Data");
                }
                return Ok(result);
            }

            //method put dari http untuk Update accountRole
            [HttpPut]
            public IActionResult Update(AccountRole accountRole)
            {
                var result = _accountRoleRepository.Update(accountRole);
                if (!result)
                {
                    return BadRequest("Failed To Update Data");
                }

                return Ok(result);
            }
        //method delete dari http untuk delete accountRole
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
            {
                var accountRole = _accountRoleRepository.GetByGuid(guid);
                var result = _accountRoleRepository.Delete(accountRole);
                if (!result)
                {
                    return BadRequest("Failed To Delete Data");
                }

                return Ok(result);
            }
        }
    }
