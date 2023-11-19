using AutoMapper;
using BLL.Models.UserRoom;
using BLL.Services.Interfaces;
using Core.Shared;
using DAL.Repositories.Interfaces;
using DAL;
using Sieve.Models;
using BLL.Models.StaffAccess;
using Core.Entity;
using Core.Exceptions;
using DAL.Repositories;
using BLL.Models.Client;

namespace BLL.Services
{
    public class UserRoomService : IUserRoomService
    {
        private readonly IUserRoomRepository _userRoomRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UserRoomService(IUserRoomRepository userRoomRepository, 
            IUserRepository userRepository, 
            IRoomRepository roomRepository,
            IMapper mapper,
            AppDbContext context) 
        { 
            _userRoomRepository = userRoomRepository;
            _userRepository = userRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserRoomModel> CreateAsync(CreateUserRoomModel createUserRoomModel)
        {
            var userRoom = _mapper.Map<UserRoom>(createUserRoomModel);

            var userName = createUserRoomModel.User.Split(' ');
            var firstName = userName[0];
            var lastName = userName[1];

            var user = await _userRepository.GetByNameAsync(firstName, lastName)
                ?? throw new NotFoundException("User was not found");

            userRoom.User = user;

            var room = await _roomRepository.GetByNumberAsync(createUserRoomModel.RoomNumber, createUserRoomModel.DepartmentAddress)
                ?? throw new NotFoundException("Room was not found");

            userRoom.Room = room;

            userRoom.AccessLevel = createUserRoomModel.AccessLevel;

            await _userRoomRepository.CreateAsync(userRoom);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserRoomModel>(userRoom);
        }

        public async Task DeleteAsync(int relationId)
        {
            var userRoom = await _userRoomRepository.GetByRelationIdAsync(relationId)
                  ?? throw new NotFoundException("UserRoom was not found");

            _userRoomRepository.Delete(userRoom);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRoomModel>> GetAllAsync()
        {
            var userRooms = await _userRoomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserRoomModel>>(userRooms);
        }

        public Task<PagedList<UserRoomModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRoomModel> GetByRelationIdAsync(int relationId)
        {
            var userRoom = await _userRoomRepository.GetByRelationIdAsync(relationId);
            return _mapper.Map<UserRoomModel>(userRoom);
        }

        public async Task UpdateAsync(int RelationId, UpdateUserRoomModel updateUserRoomModel)
        {
            var userRoom = await _userRoomRepository.GetByRelationIdAsync(updateUserRoomModel.RelationId)
                              ?? throw new NotFoundException("UserRoom was not found");

            var userName = updateUserRoomModel.User.Split(' ');
            var firstName = userName[0];
            var lastName = userName[1];

            var user = await _userRepository.GetByNameAsync(firstName, lastName)
                ?? throw new NotFoundException("User was not found");

            userRoom.User = user;

            var room = await _roomRepository.GetByNumberAsync(updateUserRoomModel.RoomNumber, updateUserRoomModel.DepartmentAddress)
                ?? throw new NotFoundException("Room was not found");

            userRoom.Room = room;

            userRoom.AccessLevel = updateUserRoomModel.AccessLevel;

            await _userRoomRepository.CreateAsync(userRoom);
            await _context.SaveChangesAsync();
        }
    }
}
