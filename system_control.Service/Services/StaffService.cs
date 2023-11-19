using AutoMapper;
using BLL.Services.Interfaces;
using Core.Enum;
using Core.Exceptions;
using Core.Shared;
using DAL.Repositories.Interfaces;
using DAL;
using Sieve.Models;
using BLL.Models.Staff;
using Core.Entity;
using BLL.Models.Visit;
using DAL.Repositories;

namespace BLL.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public StaffService(
            IStaffRepository staffRepository,
            IUserRepository userRepository,
            IDepartmentRepository departmentRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _staffRepository = staffRepository;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<StaffModel> CreateAsync(CreateStaffModel createStaffModel)
        {
            var staff = new Staff();

            var userName = createStaffModel.User.Split(' ');
            var firstName = userName[0];
            var lastName = userName[1];

            var user = await _userRepository.GetByNameAsync(firstName, lastName)
                       ?? throw new NotFoundException("User was not found");

            staff.User = user;

            var department = await _departmentRepository.GetByAddressAsync(createStaffModel.DepartmentAddress)
                       ?? throw new NotFoundException("Department was not found");

            staff.Department = department;
            
            staff.DateOfEmployment = createStaffModel.DateOfEmployment;
            staff.Position = createStaffModel.Position;

            await _staffRepository.CreateAsync(staff);
            await _context.SaveChangesAsync();

            return _mapper.Map<StaffModel>(staff);
        }

        public async Task DeleteAsync(int id)
        {
            var staff = await _staffRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException($"Staff with id {id} was not found");

            _staffRepository.Delete(staff);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StaffModel>> GetAllAsync()
        {
            var staff = await _staffRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StaffModel>>(staff);
        }

        public async Task<PagedList<StaffModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _staffRepository.GetAllWithFilterAsync(sieveModel);
            var staffModels = _mapper.Map<IEnumerable<StaffModel>>(pagedList.Items);

            var updatedPagedList = PagedList<StaffModel>.Copy(pagedList, staffModels);

            return updatedPagedList;
        }

        public async Task<StaffModel> GetByIdAsync(int id)
        {
            var staff = await _staffRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException($"Staff with id {id} was not found");

            return _mapper.Map<StaffModel>(staff);
        }

        public async Task UpdateAsync(int id, UpdateStaffModel updateStaffModel)
        {
            var staff = await _staffRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException($"Staff with id {id} was not found");

            var userName = updateStaffModel.User.Split(' ');
            var firstName = userName[0];
            var lastName = userName[1];

            var user = await _userRepository.GetByNameAsync(firstName, lastName)
                       ?? throw new NotFoundException("User was not found");

            staff.User = user;

            var department = await _departmentRepository.GetByAddressAsync(updateStaffModel.DepartmentAddress)
                       ?? throw new NotFoundException("Department was not found");

            staff.Department = department;

            staff.DateOfEmployment = updateStaffModel.DateOfEmployment;
            staff.Position = updateStaffModel.Position;

            _staffRepository.Update(staff);
            await _context.SaveChangesAsync();
        }
    }
}

