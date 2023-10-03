using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
        //membuat endpoint routing untuk room controller 
        [ApiController]
        [Route("api/[controller]")]
        public class RoomController : ControllerBase
        {
            //membuat room repository untuk mengakses database sebagai readonly dan private
            private readonly IRoomRepository _roomRepository;
            
            public RoomController(IRoomRepository roomRepository)
            {
                _roomRepository = roomRepository;
            }
            //method get dari http untuk getall universities
            [HttpGet]
            public IActionResult GetAll()
            {
                var result = _roomRepository.GetAll();
                if (!result.Any())
                {
                    return NotFound("Data Not Found");
                }

                return Ok(result);
            }
            //method get dari http untuk getByGuid room
            [HttpGet("{guid}")]
            public IActionResult GetByGuid(Guid guid)
            {
                var result = _roomRepository.GetByGuid(guid);
                if (result is null)
                {
                    return NotFound("Data Not Found");

                }
                return Ok(result);
            }
            //method post dari http untuk create room
            [HttpPost]
            public IActionResult Create(Room room)
            {
                var result = _roomRepository.Create(room);
                if (result is null)
                {
                    return BadRequest("Failed To Create Data");
                }
                return Ok(result);
            }

            //method put dari http untuk Update room
            [HttpPut]
            public IActionResult Update(Room room)
            {
                var result = _roomRepository.Update(room);
                if (!result)
                {
                    return BadRequest("Failed To Update Data");
                }

                return Ok(result);
            }
        //method delete dari http untuk delete room
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
            {
                var room = _roomRepository.GetByGuid(guid);
                var result = _roomRepository.Delete(room);
                if (!result)
                {
                    return BadRequest("Failed To Delete Data");
                }

                return Ok(result);
            }
        }
    }

