using AutoMapper;
using BLL.Models.Client;
using BLL.Models.Department;
using BLL.Models.Organization;
using BLL.Models.Staff;
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
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public DepartmentService(
            IDepartmentRepository departmentRepository,
            IOrganizationRepository organizationRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _departmentRepository = departmentRepository;
            _organizationRepository = organizationRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentModel>>(departments);
        }

        public async Task<PagedList<DepartmentModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _departmentRepository.GetAllWithFilterAsync(sieveModel);
            var departmentModels = _mapper.Map<IEnumerable<DepartmentModel>>(pagedList.Items);

            var updatedPagedList = PagedList<DepartmentModel>.Copy(pagedList, departmentModels);

            return updatedPagedList;
        }

        public async Task<DepartmentModel> CreateAsync(CreateDepartmentModel createDepartmentModel)
        {
            var department = _mapper.Map<Department>(createDepartmentModel);

            var organization = await _organizationRepository.GetByNameAsync(createDepartmentModel.OrganizationName)
                ?? throw new NotFoundException("Organization was not found");

            department.Organization = organization;
            //department.Address = createDepartmentModel.Address;

            await _departmentRepository.CreateAsync(department);
            await _context.SaveChangesAsync();

            return _mapper.Map<DepartmentModel>(department);
        }

        public async Task UpdateAsync(int id, UpdateDepartmentModel updateDepartmentModel)
        {
            var department = await _departmentRepository.GetByIdAsync(updateDepartmentModel.Id)
                              ?? throw new NotFoundException("Competition was not found");

            var organization = await _organizationRepository.GetByNameAsync(updateDepartmentModel.OrganizationName)
                ?? throw new NotFoundException("Organization was not found");

            department.Organization = organization;
            department.Address = updateDepartmentModel.Address;

            _departmentRepository.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id)
                              ?? throw new NotFoundException("Competition was not found");

            if (department.Rooms != null && department.Rooms.Any())
            {
                throw new BadRequestException($"Department with id {id} can't be deleted, it still has rooms");
            }

            _departmentRepository.Delete(department);
            await _context.SaveChangesAsync();
        }

        public async Task<DepartmentModel> GetByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Department with id {id} was not found");

            return _mapper.Map<DepartmentModel>(department);
        }
    }
}
