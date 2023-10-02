using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using API.Repositories;

namespace API.Controllers
{
        //membuat endpoint routing untuk account controller 
        [ApiController]
        [Route("api/[controller]")]
        public class AccountController : ControllerBase
        {
            //membuat account repository untuk mengakses database sebagai readonly dan private
            private readonly IAccountRepository _accountRepository;
            
            public AccountController(IAccountRepository accountRepository)
            {
                _accountRepository = accountRepository;
            }
            //method get dari http untuk getall universities
            [HttpGet]
            public IActionResult GetAll()
            {
                var result = _accountRepository.GetAll();
                if (!result.Any())
                {
                    return NotFound("Data Not Found");
                }

                return Ok(result);
            }
            //method get dari http untuk getByGuid account
            [HttpGet("{guid}")]
            public IActionResult GetByGuid(Guid guid)
            {
                var result = _accountRepository.GetByGuid(guid);
                if (result is null)
                {
                    return NotFound("Data Not Found");

                }
                return Ok(result);
            }
            //method post dari http untuk create account
            [HttpPost]
            public IActionResult Create(Account account)
            {
                var result = _accountRepository.Create(account);
                if (result is null)
                {
                    return BadRequest("Failed To Create Data");
                }
                return Ok(result);
            }

            //method put dari http untuk Update account
            [HttpPut]
            public IActionResult Update(Account account)
            {
                var result = _accountRepository.Update(account);
                if (!result)
                {
                    return BadRequest("Failed To Update Data");
                }

                return Ok(result);
            }
            //method delete dari http untuk delete account
            [HttpDelete]
            public IActionResult Delete(Guid guid)
            {
                var account = _accountRepository.GetByGuid(guid);
                var result = _accountRepository.Delete(account);
                if (!result)
                {
                    return BadRequest("Failed To Delete Data");
                }

                return Ok(result);
            }
        }
    }
