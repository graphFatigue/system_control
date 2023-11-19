using AutoMapper;
using BLL.Models.Department;
using BLL.Services.Interfaces;
using Core.Entity;
using Core.Exceptions;
using Core.Shared;
using DAL.Repositories.Interfaces;
using DAL;
using Sieve.Models;
using BLL.Models.Room;
using BLL.Models.Staff;

namespace BLL.Services
{
    public class RoomService: IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public RoomService(
            IRoomRepository roomRepository,
            IDepartmentRepository departmentRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _roomRepository = roomRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<RoomModel>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomModel>>(rooms);
        }

        public async Task<PagedList<RoomModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _roomRepository.GetAllWithFilterAsync(sieveModel);
            var roomModels = _mapper.Map<IEnumerable<RoomModel>>(pagedList.Items);

            var updatedPagedList = PagedList<RoomModel>.Copy(pagedList, roomModels);

            return updatedPagedList;
        }

        public async Task<RoomModel> CreateAsync(CreateRoomModel createRoomModel)
        {
            var room = _mapper.Map<Room>(createRoomModel);

            var department = await _departmentRepository.GetByAddressAsync(createRoomModel.DepartmentAddress)
                ?? throw new NotFoundException("Department was not found");

            room.Department = department;

            await _roomRepository.CreateAsync(room);
            await _context.SaveChangesAsync();

            return _mapper.Map<RoomModel>(room);
        }

        public async Task UpdateAsync(int id, UpdateRoomModel updateRoomModel)
        {
            var room = await _roomRepository.GetByIdAsync(updateRoomModel.Id)
                              ?? throw new NotFoundException("Room was not found");

            var department = await _departmentRepository.GetByAddressAsync(updateRoomModel.DepartmentAddress)
                ?? throw new NotFoundException("Department was not found");

            room.Department = department;
            room.Floor = updateRoomModel.Floor;
            room.Number = updateRoomModel.Number;

            _roomRepository.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id)
                              ?? throw new NotFoundException("Room was not found");

            _roomRepository.Delete(room);
            await _context.SaveChangesAsync();
        }

        public async Task<RoomModel> GetByIdAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Room with id {id} was not found");

            return _mapper.Map<RoomModel>(room);
        }
    }
}
