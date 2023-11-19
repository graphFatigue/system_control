using AutoMapper;
using BLL.Models.User;
using BLL.Models.Visit;
using BLL.Services.Interfaces;
using Core.Entity;
using Core.Exceptions;
using Core.Shared;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Sieve.Models;

namespace BLL.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IClientStaffAccessRepository _clientStaffAccessRepository;
        private readonly IUserRoomRepository _userRoomRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public VisitService(
            IVisitRepository visitRepository,
            IDepartmentRepository departmentRepository,
            IRoomRepository roomRepository,
            IClientRepository clientRepository,
            IStaffRepository staffRepository,
            IClientStaffAccessRepository clientStaffAccessRepository,
            IUserRoomRepository userRoomRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _visitRepository = visitRepository;
            _departmentRepository = departmentRepository;
            _roomRepository = roomRepository;
            _clientRepository = clientRepository;
            _staffRepository = staffRepository;
            _clientStaffAccessRepository = clientStaffAccessRepository;
            _userRoomRepository = userRoomRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<VisitModel>> GetAllAsync()
        {
            var visits = await _visitRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VisitModel>>(visits);
        }

        public Task<PagedList<VisitModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            throw new NotImplementedException();
        }

        public async Task<VisitModel> CreateAsync(CreateVisitModel createVisitModel)
        {
            var visit = _mapper.Map<Visit>(createVisitModel);

            var department = await _departmentRepository.GetByAddressAsync(createVisitModel.DepartmentAddress)
                                   ?? throw new NotFoundException("Department was not found");

            var room = await _roomRepository.GetByNumberAsync(createVisitModel.RoomNumber, department.Address)
                       ?? throw new NotFoundException("Room was not found");

            visit.Room = room;

            var client = await _clientRepository.GetByNameAsync(createVisitModel.ClientFirstName, createVisitModel.ClientLastName)
                ?? throw new NotFoundException("Client was not found");

            visit.Client = client;

            var staff = await _staffRepository.GetByNameAndDepartmentAsync(createVisitModel.StaffFirstName, createVisitModel.StaffLastName, department.Id)
                ?? throw new NotFoundException("Staff was not found");

            visit.Staff = staff;

            var accessLevelClientStaff = await _clientStaffAccessRepository.GetByClientStaffDepartmmentAsync(client.Id, staff.Id, department.Id);

            if (accessLevelClientStaff == null)
            {
                ClientStaffAccess createAccessLevelClientStaff = new ClientStaffAccess()
                {
                    Client = client,
                    Staff = staff,
                    Department = department,
                    AccessLevel = Core.Enum.AccessLevel.Allowed,
                };
                _context.ClientStaffAccess.Add(createAccessLevelClientStaff);
                await _context.SaveChangesAsync();
            }
            else if (accessLevelClientStaff.AccessLevel == Core.Enum.AccessLevel.Denied)
            {
                throw new NotFoundException("Access is denied");
            };

            var staffAccess = await _userRoomRepository.GetByUserRoomAsync(staff.UserId, room.Id);
            var clientAccess = await _userRoomRepository.GetByUserRoomAsync(client.UserId, room.Id);

            if (staffAccess == null)
            {
                UserRoom createStaffRoomAccess = new UserRoom()
                {
                    User = staff.User,
                    Room = room,
                    AccessLevel = Core.Enum.AccessLevel.Allowed,
                };
                _context.UserRoom.Add(createStaffRoomAccess);
                await _context.SaveChangesAsync();
            }
            else if (staffAccess.AccessLevel == Core.Enum.AccessLevel.Denied)
            {
                throw new NotFoundException("Access is denied");
            };

            if (clientAccess == null)
            {
                UserRoom createClientRoomAccess = new UserRoom()
                {
                    User = client.User,
                    Room = room,
                    AccessLevel = Core.Enum.AccessLevel.Allowed,
                };
                _context.UserRoom.Add(createClientRoomAccess);
                await _context.SaveChangesAsync();
            }
            else if (clientAccess.AccessLevel == Core.Enum.AccessLevel.Denied)
            {
                throw new NotFoundException("Access is denied");
            };

            await _visitRepository.CreateAsync(visit);
            await _context.SaveChangesAsync();

            return _mapper.Map<VisitModel>(visit);
        }

        public async Task UpdateAsync(int id, UpdateVisitModel updateVisitModel)
        {
            var visit = await _visitRepository.GetByIdAsync(updateVisitModel.Id)
                              ?? throw new NotFoundException("Visit was not found");

            var department = await _departmentRepository.GetByAddressAsync(updateVisitModel.DepartmentAddress)
                                   ?? throw new NotFoundException("Department was not found");

            var room = await _roomRepository.GetByNumberAsync(updateVisitModel.RoomNumber, department.Address)
                       ?? throw new NotFoundException("Room was not found");

            visit.Room = room;

            var client = await _clientRepository.GetByNameAsync(updateVisitModel.ClientFirstName, updateVisitModel.ClientLastName)
                ?? throw new NotFoundException("Client was not found");

            visit.Client = client;

            var staff = await _staffRepository.GetByNameAndDepartmentAsync(updateVisitModel.StaffFirstName, updateVisitModel.StaffLastName, department.Id)
                ?? throw new NotFoundException("Staff was not found");

            visit.Staff = staff;

            visit.Purpose = updateVisitModel.Purpose;
            visit.DateTime = updateVisitModel.DateTime;

            _visitRepository.Update(visit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var visit = await _visitRepository.GetByIdAsync(id)
                              ?? throw new NotFoundException("Competition was not found");

            _visitRepository.Delete(visit);
            await _context.SaveChangesAsync();
        }

        public async Task<VisitModel> GetByIdAsync(int id)
        {
            var visit = await _visitRepository.GetByIdAsync(id);
            return _mapper.Map<VisitModel>(visit);
        }
    }
}
