using AutoMapper;
using Data.Entities;
using static Core.DTOs.Models.RoomDTO;

namespace Api
{
    public class RoomsProfile : Profile
    {
        public RoomsProfile()
        {
            CreateMap<Room, RoomResponseDto>().ReverseMap();
            CreateMap<Room, CreateRoomDto>().ReverseMap();
            CreateMap<Room, UpdateRoomDto>().ReverseMap();
        }
    }
}
