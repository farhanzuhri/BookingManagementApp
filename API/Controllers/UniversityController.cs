using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using API.Repositories;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversityController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _universityRepository.GetAll();
            if (!result.Any())
            {
                return NotFound("Data Not Found");
            }

            return Ok(result);
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _universityRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(University university)
        {
            var result = _universityRepository.Create(university);
            if (result is null)
            {
                return BadRequest("Failed to create data");
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(University university)
        {
            var updateUniversity = _universityRepository.Update(university);

            if (!updateUniversity)
            {
                return BadRequest("Failed to update data");
            }

            return Ok(updateUniversity);
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var university = _universityRepository.GetByGuid(guid);
            var deletedUniversity = _universityRepository.Delete(university);
            if (!deletedUniversity)
            {
                return BadRequest("Failed To Delete Data");
            }

            return Ok(deletedUniversity);
        }
    }
}
