using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using API.Repositories;
using API.Utilities.Handlers;
using API.Utilities.Handler;
using API.DTOs.Educations;
using API.DTOs.Universities;
using System.Net;

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
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            var data = result.Select(i => (EducationDto)i);

            return Ok(new ResponseOkHandler<IEnumerable<EducationDto>>(data));
        }
        //method get dari http untuk getByGuid education
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _educationRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            return Ok(new ResponseOkHandler<EducationDto>((EducationDto)result));
        }
        //method post dari http untuk create education
        [HttpPost]
        public IActionResult Create(CreateEducationDto createEducationDto)
        {
            try
            {
                Education toCreate = createEducationDto;
                var result = _educationRepository.Create(toCreate);

                return Ok(new ResponseOkHandler<EducationDto>((EducationDto)result));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to create data",
                    Error = e.Message
                });
            }
        }

        //method put dari http untuk Update education
        [HttpPut]
        public IActionResult Update(EducationDto educationDto)
        {
            try
            {
                var entity = _educationRepository.GetByGuid(educationDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }
                Education toUpdate = educationDto;
                toUpdate.CreatedDate = entity.CreatedDate;
                var result = _educationRepository.Update(educationDto);

                return Ok(new ResponseOkHandler<String>("Data Updated"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to update data",
                    Error = e.Message
                });
            }
        }
        //method delete dari http untuk delete education
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            try
            {
                var education = _educationRepository.GetByGuid(guid);
                if (education is null)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }
                var result = _educationRepository.Delete(education);
                return Ok(new ResponseOkHandler<String>("Data Deleted"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to delete data",
                    Error = e.Message
                });
            }
        }
    }
}