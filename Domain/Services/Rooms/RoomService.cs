﻿using System.Data;
using AutoMapper;
using Data.Entities;
using Data.Repository;
using static Core.DTOs.Models.RoomDTO;

namespace Domain.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }


        public async Task<List<RoomResponseDto>> GetAsync()
        {
            List<Room> rooms = await _roomRepository.GetAsync();
            if (rooms == null || !rooms.Any())
            {
                throw new Exception("'Rooms' not found in the 'roomRepository'");
            }
            return rooms.Select(_mapper.Map<RoomResponseDto>).ToList();
        }


        public async Task<RoomResponseDto> GetByIdAsync(long id)
        {
            Room roomItem = await _roomRepository.GetByIdAsync(id);
            if (roomItem == null)
            {
                throw new Exception("The 'Room' object with the specified 'ID' not found");
            }
            return _mapper.Map<RoomResponseDto>(roomItem);
        }


        public async Task<RoomResponseDto> CreateAsync(CreateRoomDto room)
        {
            Room roomItem = await _roomRepository.CreateAsync(_mapper.Map<Room>(room));
            if (roomItem == null)
            {
                throw new Exception("The 'Room' object could not be created");
            }
            return _mapper.Map<RoomResponseDto>(roomItem);
        }


        public async Task<RoomResponseDto> UpdateAsync(UpdateRoomDto room)
        {
            if (room == null)
            {
                throw new Exception("The 'Room' should not be 'Null'");
            }
            Room roomItem = await _roomRepository.UpdateAsync(_mapper.Map<Room>(room));
            return _mapper.Map<RoomResponseDto>(roomItem);
        }


        public async Task DeleteAsync(long id)
        {
            await _roomRepository.DeleteAsync(id);
        }
    }
}
