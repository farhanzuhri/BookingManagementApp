using API.Contracts;
using API.DTOs.Rooms;
using API.Models;
using API.Utilities.Handler;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    //membuat endpoint routing untuk room controller 
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RoomController : ControllerBase
    {
        //membuat room repository untuk mengakses database sebagai readonly dan private
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IEmployeeRepository _employeeRepository;


        public RoomController(IRoomRepository roomRepository, IBookingRepository bookingRepository, IEmployeeRepository employeeRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("roomsUsed")]
        public IActionResult GetRoomsUsed()
        {
            // Check if any room, booking, and employee or not
            var rooms = _roomRepository.GetAll();
            var bookings = _bookingRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            if (!(rooms.Any() && bookings.Any() && employees.Any()))
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            // Join data rooms, bookings, and employees to get roomsUseToday details
            var roomsUseToday = from r in rooms
                                join b in bookings on r.Guid equals b.RoomGuid
                                join e in employees on b.EmployeeGuid equals e.Guid
                                where (b.StartDate <= DateTime.Today) && (b.EndDate > DateTime.Today)
                                select new RoomUsedTodayDto
                                {
                                    BookingGuid = b.Guid,
                                    RoomName = r.Name,
                                    Status = b.Status.ToString(),
                                    Floor = r.Floor,
                                    BookBy = string.Concat(e.FirstName, " ", e.LastName)
                                };
            if (!roomsUseToday.Any())
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Room Not Found"
                });
            }
            return Ok(new ResponseOkHandler<IEnumerable<RoomUsedTodayDto>>(roomsUseToday));
        }

        [HttpGet("roomsNotUsed")]
        public IActionResult GetRoomsNotUsed()
        {
            // Check if any room and booking or not
            var rooms = _roomRepository.GetAll();
            var bookings = _bookingRepository.GetAll();
            if (!(rooms.Any() && bookings.Any()))
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            // Join data rooms and bookings to get roomsNotUseToday details
            var roomsNotUseToday = from r in rooms
                                   join b in bookings on r.Guid equals b.RoomGuid
                                   where (b.StartDate > DateTime.Today) || (b.EndDate <= DateTime.Today)
                                   select new RoomNotUsedTodayDto
                                   {
                                       RoomGuid = r.Guid,
                                       RoomName = r.Name,
                                       Floor = r.Floor,
                                       Capacity = r.Capacity
                                   };
            if (!roomsNotUseToday.Any())
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Room Not Found"
                });
            }
            return Ok(new ResponseOkHandler<IEnumerable<RoomNotUsedTodayDto>>(roomsNotUseToday));
        }

        //method get dari http untuk getall universities
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _roomRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            var data = result.Select(i => (RoomDto)i);
            return Ok(new ResponseOkHandler<IEnumerable<RoomDto>>(data));
        }
        //method get dari http untuk getByGuid room
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _roomRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            return Ok(new ResponseOkHandler<RoomDto>((RoomDto)result));
        }
        //method post dari http untuk create room
        [HttpPost]
        public IActionResult Create(CreateRoomDto createRoomDto)
        {
            try
            {
                Room toCreate = createRoomDto;
                toCreate.Guid = new Guid();
                var result = _roomRepository.Create(toCreate);
                return Ok(new ResponseOkHandler<RoomDto>((RoomDto)result));

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
        //method put dari http untuk Update room
        [HttpPut]
        public IActionResult Update(RoomDto roomDto)
        {
            try
            {
                var entity = _roomRepository.GetByGuid(roomDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }
                Room toUpdate = roomDto;
                toUpdate.CreatedDate = entity.CreatedDate;
                var result = _roomRepository.Update(roomDto);
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
        //method delete dari http untuk delete room
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            try
            {
                var room = _roomRepository.GetByGuid(guid);
                if (room is null)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }
                var result = _roomRepository.Delete(room);
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

