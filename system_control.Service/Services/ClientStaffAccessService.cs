using AutoMapper;
using BLL.Models.Visit;
using BLL.Services.Interfaces;
using Core.Entity;
using Core.Exceptions;
using Core.Shared;
using DAL.Repositories.Interfaces;
using DAL;
using Sieve.Models;
using DAL.Repositories;
using BLL.Models.ClientStaffAccess;
using BLL.Models.Admin;

namespace BLL.Services
{
    public class ClientStaffAccessService: IClientStaffAccessService
    {
        private readonly IClientStaffAccessRepository _clientStaffAccessRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public ClientStaffAccessService(
            IClientStaffAccessRepository clientStaffAccessRepository,
            IClientRepository clientRepository,
            IStaffRepository staffRepository,
            IDepartmentRepository departmentRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _clientStaffAccessRepository = clientStaffAccessRepository;
            _clientRepository = clientRepository;
            _staffRepository = staffRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ClientStaffAccessModel>> GetAllAsync()
        {
            var clientStaffAccesses = await _clientStaffAccessRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientStaffAccessModel>>(clientStaffAccesses);
        }

        public async Task<ClientStaffAccessModel> CreateAsync(CreateClientStaffAccessModel createClientStaffAccessModel)
        {
            var clientStaffAccess = _mapper.Map<ClientStaffAccess>(createClientStaffAccessModel);

            var client = await _clientRepository.GetByNameAsync(createClientStaffAccessModel.ClientFirstName, createClientStaffAccessModel.ClientLastName)
                ?? throw new NotFoundException("Client was not found");

            clientStaffAccess.Client = client;

            var department = await _departmentRepository.GetByAddressAsync(createClientStaffAccessModel.DepartmentAddress)
                ?? throw new NotFoundException("Department was not found");

            var staff = await _staffRepository.GetByNameAndDepartmentAsync(createClientStaffAccessModel.StaffFirstName, createClientStaffAccessModel.StaffLastName, department.Id)
                ?? throw new NotFoundException("Staff was not found");

            clientStaffAccess.Staff = staff;

            await _clientStaffAccessRepository.CreateAsync(clientStaffAccess);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClientStaffAccessModel>(clientStaffAccess);
        }

        public async Task UpdateAsync(int relationId, UpdateClientStaffAccessModel updateClientStaffAccessModel)
        {
            var clientStaffAccess = await _clientStaffAccessRepository.GetByRelationIdAsync(updateClientStaffAccessModel.RelationId)
                              ?? throw new NotFoundException("ClientStaffAccess was not found");

            var client = await _clientRepository.GetByNameAsync(updateClientStaffAccessModel.ClientFirstName, updateClientStaffAccessModel.ClientLastName)
                ?? throw new NotFoundException("Client was not found");

            clientStaffAccess.Client = client;

            var department = await _departmentRepository.GetByAddressAsync(updateClientStaffAccessModel.DepartmentAddress)
                ?? throw new NotFoundException("Department was not found");

            clientStaffAccess.Department = department;

            var staff = await _staffRepository.GetByNameAndDepartmentAsync(updateClientStaffAccessModel.StaffFirstName, updateClientStaffAccessModel.StaffLastName, department.Id)
                ?? throw new NotFoundException("Staff was not found");

            clientStaffAccess.Staff = staff;

            clientStaffAccess.AccessLevel = updateClientStaffAccessModel.AccessLevel;

            _clientStaffAccessRepository.Update(clientStaffAccess);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int relationId)
        {
            var clientStaffAccess = await _clientStaffAccessRepository.GetByRelationIdAsync(relationId)
                              ?? throw new NotFoundException("ClientStaffAccess was not found");

            _clientStaffAccessRepository.Delete(clientStaffAccess);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientStaffAccessModel> GetByRelationIdAsync(int relationId)
        {
            var clientStaffAccess = await _clientStaffAccessRepository.GetByRelationIdAsync(relationId);
            return _mapper.Map<ClientStaffAccessModel>(clientStaffAccess);
        }

        public Task<PagedList<ClientStaffAccessModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            throw new NotImplementedException();
        }
    }
}
