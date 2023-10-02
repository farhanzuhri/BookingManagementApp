using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BookingController
    {
        //membuat endpoint routing untuk booking controller 
        [ApiController]
        [Route("api/[controller]")]
        public class BookıngController : ControllerBase
        {
            //membuat booking repository untuk mengakses database sebagai readonly dan private
            private readonly IBookingRepository _bookingRepository;
            
            public BookıngController(IBookingRepository bookingRepository)
            {
                _bookingRepository = bookingRepository;
            }
            //method get dari http untuk getall universities
            [HttpGet]
            public IActionResult GetAll()
            {
                var result = _bookingRepository.GetAll();
                if (!result.Any())
                {
                    return NotFound("Data Not Found");
                }

                return Ok(result);
            }
            //method get dari http untuk getByGuid booking
            [HttpGet("{guid}")]
            public IActionResult GetByGuid(Guid guid)
            {
                var result = _bookingRepository.GetByGuid(guid);
                if (result is null)
                {
                    return NotFound("Data Not Found");

                }
                return Ok(result);
            }
            //method post dari http untuk create booking
            [HttpPost]
            public IActionResult Create(Booking booking)
            {
                var result = _bookingRepository.Create(booking);
                if (result is null)
                {
                    return BadRequest("Failed To Create Data");
                }
                return Ok(result);
            }

            //method put dari http untuk Update booking
            [HttpPut]
            public IActionResult Update(Booking booking)
            {
                var result = _bookingRepository.Update(booking);
                if (!result)
                {
                    return BadRequest("Failed To Update Data");
                }

                return Ok(result);
            }
            //method delete dari http untuk delete booking
            [HttpDelete]
            public IActionResult Delete(Guid guid)
            {
                var booking = _bookingRepository.GetByGuid(guid);
                var result = _bookingRepository.Delete(booking);
                if (!result)
                {
                    return BadRequest("Failed To Delete Data");
                }

                return Ok(result);
            }
        }
    }
}
