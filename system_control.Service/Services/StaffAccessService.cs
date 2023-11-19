using AutoMapper;
using BLL.Models.ClientAccess;
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
using BLL.Models.StaffAccess;

namespace BLL.Services
{
    public class StaffAccessService : IStaffAccessService
    {
        private readonly IStaffAccessRepository _staffAccessRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public StaffAccessService(
            IStaffAccessRepository staffAccessRepository,
            IStaffRepository staffRepository,
            IDepartmentRepository departmentRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _staffAccessRepository = staffAccessRepository;
            _staffRepository = staffRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<StaffAccessModel>> GetAllAsync()
        {
            var staffAccesses = await _staffAccessRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StaffAccessModel>>(staffAccesses);
        }

        public async Task<StaffAccessModel> CreateAsync(CreateStaffAccessModel createStaffAccessModel)
        {
            var staffAccess = _mapper.Map<StaffAccess>(createStaffAccessModel);

            var department = await _departmentRepository.GetByAddressAsync(createStaffAccessModel.DepartmentAddress)
                ?? throw new NotFoundException("Department was not found");

            staffAccess.Department = department;

            var firstStaff = await _staffRepository.GetByNameAndDepartmentAsync(createStaffAccessModel.FirstStaffFirstName, createStaffAccessModel.FirstStaffLastName, department.Id)
                ?? throw new NotFoundException("Staff was not found");

            staffAccess.FirstStaff = firstStaff;

            var secondStaff = await _staffRepository.GetByNameAndDepartmentAsync(createStaffAccessModel.SecondStaffFirstName, createStaffAccessModel.SecondStaffLastName, department.Id)
                ?? throw new NotFoundException("Staff was not found");

            staffAccess.SecondStaff = secondStaff;

            await _staffAccessRepository.CreateAsync(staffAccess);
            await _context.SaveChangesAsync();

            return _mapper.Map<StaffAccessModel>(staffAccess);
        }

        public async Task UpdateAsync(int relationId, UpdateStaffAccessModel updateStaffAccessModel)
        {
            var staffAccess = await _staffAccessRepository.GetByRelationIdAsync(updateStaffAccessModel.RelationId)
                              ?? throw new NotFoundException("StaffAccess was not found");

            var department = await _departmentRepository.GetByAddressAsync(updateStaffAccessModel.DepartmentAddress)
    ?? throw new NotFoundException("Department was not found");

            staffAccess.Department = department;

            var firstStaff = await _staffRepository.GetByNameAndDepartmentAsync(updateStaffAccessModel.FirstStaffFirstName, updateStaffAccessModel.FirstStaffLastName, department.Id)
                ?? throw new NotFoundException("Staff was not found");

            staffAccess.FirstStaff = firstStaff;

            var secondStaff = await _staffRepository.GetByNameAndDepartmentAsync(updateStaffAccessModel.SecondStaffFirstName, updateStaffAccessModel.SecondStaffLastName, department.Id)
                ?? throw new NotFoundException("Staff was not found");

            staffAccess.SecondStaff = secondStaff;

            staffAccess.AccessLevel = updateStaffAccessModel.AccessLevel;

            _staffAccessRepository.Update(staffAccess);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int relationId)
        {
            var staffAccess = await _staffAccessRepository.GetByRelationIdAsync(relationId)
                              ?? throw new NotFoundException("StaffAccess was not found");

            _staffAccessRepository.Delete(staffAccess);
            await _context.SaveChangesAsync();
        }

        public async Task<StaffAccessModel> GetByRelationIdAsync(int relationId)
        {
            var staffAccess = await _staffAccessRepository.GetByRelationIdAsync(relationId);
            return _mapper.Map<StaffAccessModel>(staffAccess);
        }

        public Task<PagedList<StaffAccessModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            throw new NotImplementedException();
        }
    }
}
