using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using static Api.Controllers.RoomController.RoomDto;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {






        #region DTO
        public IEnumerable<RoomDto> _rooms = new Collection<RoomDto>
        {
            new RoomDto{ Id = 1, Number = "101", RoomType = RoomTypes.economy, price = 2003.40m  },
            new RoomDto{ Id = 2, Number = "102", RoomType = RoomTypes.economy, price = 2045.23m  },
            new RoomDto{ Id = 3, Number = "103", RoomType = RoomTypes.economy, price = 2544.45m  },
            new RoomDto{ Id = 4, Number = "104", RoomType = RoomTypes.economy, price = 2473.22m  },
            new RoomDto{ Id = 5, Number = "201", RoomType = RoomTypes.standart, price = 4510.45m  },
            new RoomDto{ Id = 6, Number = "202", RoomType = RoomTypes.standart, price = 4863.22m  },
            new RoomDto{ Id = 7, Number = "203", RoomType = RoomTypes.standart, price = 4398.25m  },
            new RoomDto{ Id = 8, Number = "204", RoomType = RoomTypes.standart, price = 4125.44m  },
            new RoomDto{ Id = 9, Number = "301", RoomType = RoomTypes.luxury, price = 6452.34m  },
            new RoomDto{ Id = 10, Number = "302", RoomType = RoomTypes.luxury, price = 6714.12m  },
            new RoomDto{ Id = 11, Number = "303", RoomType = RoomTypes.luxury, price = 6712.77m  },
        };

        public class RoomDto
        {
            public int Id { get; set; }
            public string Number { get; set; }
            public RoomTypes RoomType { get; set; }
            public decimal price { get; set; }
        }

        public enum RoomTypes { economy, standart, luxury } 
        #endregion

    }
}
