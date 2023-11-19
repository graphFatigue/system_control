using AutoMapper;
using BLL.Models.Staff;
using BLL.Services.Interfaces;
using Core.Entity;
using Core.Exceptions;
using Core.Shared;
using DAL.Repositories.Interfaces;
using DAL;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Admin;

namespace BLL.Services
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public AdminService(
            IAdminRepository adminRepository,
            IUserRepository userRepository,
            IDepartmentRepository departmentRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<AdminModel> CreateAsync(CreateAdminModel createAdminModel)
        {
            var admin = new Admin();

            var userName = createAdminModel.User.Split(' ');
            var firstName = userName[0];
            var lastName = userName[1];

            var user = await _userRepository.GetByNameAsync(firstName, lastName)
                       ?? throw new NotFoundException("User was not found");

            admin.User = user;

            var department = await _departmentRepository.GetByAddressAsync(createAdminModel.DepartmentAddress)
                       ?? throw new NotFoundException("Department was not found");

            admin.Department = department;

            await _adminRepository.CreateAsync(admin);
            await _context.SaveChangesAsync();

            return _mapper.Map<AdminModel>(admin);
        }

        public async Task DeleteAsync(int id)
        {
            var admin = await _adminRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException($"Admin with id {id} was not found");

            _adminRepository.Delete(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AdminModel>> GetAllAsync()
        {
            var admin = await _adminRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AdminModel>>(admin);
        }

        public async Task<PagedList<AdminModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _adminRepository.GetAllWithFilterAsync(sieveModel);
            var adminModels = _mapper.Map<IEnumerable<AdminModel>>(pagedList.Items);

            var updatedPagedList = PagedList<AdminModel>.Copy(pagedList, adminModels);

            return updatedPagedList;
        }

        public async Task<AdminModel> GetByIdAsync(int id)
        {
            var admin = await _adminRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException($"Admin with id {id} was not found");

            return _mapper.Map<AdminModel>(admin);
        }

        public async Task UpdateAsync(int id, UpdateAdminModel updateAdminModel)
        {
            var admin = await _adminRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException($"Staff with id {id} was not found");

            var userName = updateAdminModel.User.Split(' ');
            var firstName = userName[0];
            var lastName = userName[1];

            var user = await _userRepository.GetByNameAsync(firstName, lastName)
                       ?? throw new NotFoundException("User was not found");

            admin.User = user;

            var department = await _departmentRepository.GetByAddressAsync(updateAdminModel.DepartmentAddress)
                       ?? throw new NotFoundException("Department was not found");

            admin.Department = department;

            _adminRepository.Update(admin);
            await _context.SaveChangesAsync();
        }
    }
}
