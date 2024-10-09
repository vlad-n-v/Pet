using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        #region DTO example
        private List<RoomDto> _rooms = new List<RoomDto>
        {
            new RoomDto{ Id = 1, Number = "101", RoomType = RoomTypes.economy, price = 2003.40m  },
            new RoomDto{ Id = 2, Number = "102", RoomType = RoomTypes.economy, price = 2045.23m  },
            new RoomDto{ Id = 3, Number = "103", RoomType = RoomTypes.economy, price = 2544.45m  },
            new RoomDto{ Id = 4, Number = "104", RoomType = RoomTypes.economy, price = 2473.22m  },
            new RoomDto{ Id = 5, Number = "201", RoomType = RoomTypes.standard, price = 4510.45m  },
            new RoomDto{ Id = 6, Number = "202", RoomType = RoomTypes.standard, price = 4863.22m  },
            new RoomDto{ Id = 7, Number = "203", RoomType = RoomTypes.standard, price = 4398.25m  },
            new RoomDto{ Id = 8, Number = "204", RoomType = RoomTypes.standard, price = 4125.44m  },
            new RoomDto{ Id = 9, Number = "301", RoomType = RoomTypes.luxury, price = 6452.34m  },
            new RoomDto{ Id = 10, Number = "302", RoomType = RoomTypes.luxury, price = 6714.12m  },
            new RoomDto{ Id = 11, Number = "303", RoomType = RoomTypes.luxury, price = 6712.77m  },
        };

        public class RoomDto
        {
            public long Id { get; set; }
            public string Number { get; set; }
            public RoomTypes RoomType { get; set; }
            public decimal price { get; set; }
        }

        public enum RoomTypes { economy, standard, luxury }
        #endregion


        [HttpGet]
        public IEnumerable<RoomDto> Get()
        {
            return _rooms;
        }


        [HttpGet("{id}")]
        public RoomDto GetById(long id)
        {
            return _rooms.FirstOrDefault(r => r.Id == id);
        }


        [HttpPost]
        public void AddRoom(RoomDto room)
        {
            _rooms.Add(room);
        }


        [HttpPut("{id}")]
        public ActionResult PutRoom(long id, RoomDto room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            RoomDto roomItem = _rooms.Find(r => r.Id == id);
            if (roomItem == null)
            {
                return NotFound();
            }

            roomItem = room;
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteRoom(long id)
        {
            RoomDto roomIten = _rooms.Find(r => r.Id == id);
            if (roomIten == null)
            {
                return NotFound();
            }
            _rooms.Remove(roomIten); 

            return NoContent();
        }
    }
}
