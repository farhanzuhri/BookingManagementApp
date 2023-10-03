using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using API.Repositories;


namespace API.Controllers
{
    //membuat endpoint routing untuk education controller 
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        //membuat education repository untuk mengakses database sebagai readonly dan private
        private readonly IEducationRepository _educationRepository;
        
        public EducationController(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }
        //method get dari http untuk getall universities
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _educationRepository.GetAll();
            if (!result.Any())
            {
                return NotFound("Data Not Found");
            }

            return Ok(result);
        }
        //method get dari http untuk getByGuid education
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _educationRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Data Not Found");

            }
            return Ok(result);
        }
        //method post dari http untuk create education
        [HttpPost]
        public IActionResult Create(Education education)
        {
            var result = _educationRepository.Create(education);
            if (result is null)
            {
                return BadRequest("Failed To Create Data");
            }
            return Ok(result);
        }

        //method put dari http untuk Update education
        [HttpPut]
        public IActionResult Update(Education education)
        {
            var result = _educationRepository.Update(education);
            if (!result)
            {
                return BadRequest("Failed To Update Data");
            }

            return Ok(result);
        }
        //method delete dari http untuk delete education
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var education = _educationRepository.GetByGuid(guid);
            var result = _educationRepository.Delete(education);
            if (!result)
            {
                return BadRequest("Failed To Delete Data");
            }

            return Ok(result);
        }
    }
}