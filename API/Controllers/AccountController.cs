using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using API.Repositories;
using API.DTOs.Accounts;
using API.Utilities.Handler;

namespace API.Controllers
{
        //membuat endpoint routing untuk account controller 
        [ApiController]
        [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        //membuat account repository untuk mengakses database sebagai readonly dan private
        private readonly IAccountRepository _accountRepository;
        //dependency injection dilakukan
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
            var data = result.Select(i => (AccountDto)i);
            return Ok(data);
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
            return Ok((AccountDto)result);
        }
        //method post dari http untuk create account
        [HttpPost]
        public IActionResult Create(CreateAccountDto account)
        {
            Account toCreate = account;
            toCreate.Password = HashHandler.HashPassword(account.Password);

            var result = _accountRepository.Create(toCreate);

            if (result is null)
            {
                return BadRequest("Failed To Create Data");
            }
            return Ok((AccountDto)result);
        }

        //method put dari http untuk Update account
        [HttpPut]
        public IActionResult Update(AccountDto account)
        {
            var result = _accountRepository.Update(account);
            if (!result)
            {
                return BadRequest("Failed To Update Data");
            }

            return Ok(result);
        }
        //method delete dari http untuk delete account
        [HttpDelete("{guid}")]
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
