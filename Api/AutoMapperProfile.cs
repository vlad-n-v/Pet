using AutoMapper;
using Data.Entities;
using static Core.DTOs.Models.RoomDTO;

namespace Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() // TODO: Не уверен что правильно разместил профиль. Как правильно регистрировать ?
        {
            CreateMap<Room, RoomResponseDto>().ReverseMap();
            CreateMap<Room, CreateRoomDto>().ReverseMap();
            CreateMap<Room, UpdateRoomDto>().ReverseMap();
        }
    }
}
