using API.Contracts;
using API.DTOs;
using API.DTOs.Bookings;
using API.Models;
using API.Utilities.Handler;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }
                var data = result.Select(i => (BookingDto)i);

                return Ok(new ResponseOkHandler<IEnumerable<BookingDto>>(data));
            }
            //method get dari http untuk getByGuid booking
            [HttpGet("{guid}")]
            public IActionResult GetByGuid(Guid guid)
            {
                var result = _bookingRepository.GetByGuid(guid);
                if (result is null)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }
                return Ok(new ResponseOkHandler<BookingDto>((BookingDto)result));
            }
            //method post dari http untuk create booking
            [HttpPost]
            public IActionResult Create(CreateBookingDto createBookingDto)
            {
                try
                {
                    Booking toCreate = createBookingDto;
                    var result = _bookingRepository.Create(toCreate);
                    return Ok(new ResponseOkHandler<BookingDto>((BookingDto)result));

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

            //method put dari http untuk Update booking
            [HttpPut]
            public IActionResult Update(BookingDto bookingDto)
            {
                try
                {
                    var entity = _bookingRepository.GetByGuid(bookingDto.Guid);
                    if (entity is null)
                    {
                        return NotFound(new ResponseErrorHandler
                        {
                            Code = StatusCodes.Status404NotFound,
                            Status = HttpStatusCode.NotFound.ToString(),
                            Message = "Data Not Found"
                        });
                    }
                    Booking toUpdate = bookingDto;
                    toUpdate.CreatedDate = entity.CreatedDate;
                    var result = _bookingRepository.Update(bookingDto);
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
            //method delete dari http untuk delete booking
            [HttpDelete("{guid}")]
            public IActionResult Delete(Guid guid)
            {
                try
                {
                    var booking = _bookingRepository.GetByGuid(guid);
                    if (booking is null)
                    {
                        return NotFound(new ResponseErrorHandler
                        {
                            Code = StatusCodes.Status404NotFound,
                            Status = HttpStatusCode.NotFound.ToString(),
                            Message = "Data Not Found"
                        });
                    }
                    var result = _bookingRepository.Delete(booking);
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
}
