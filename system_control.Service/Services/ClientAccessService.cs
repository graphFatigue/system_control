using AutoMapper;
using BLL.Models.ClientStaffAccess;
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
using BLL.Models.ClientAccess;
using BLL.Models.Room;

namespace BLL.Services
{
    public class ClientAccessService: IClientAccessService
    {
        private readonly IClientAccessRepository _clientAccessRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public ClientAccessService(
            IClientAccessRepository clientAccessRepository,
            IClientRepository clientRepository,
            IDepartmentRepository departmentRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _clientAccessRepository = clientAccessRepository;
            _clientRepository = clientRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ClientAccessModel>> GetAllAsync()
        {
            var clientAccesses = await _clientAccessRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientAccessModel>>(clientAccesses);
        }

        public async Task<ClientAccessModel> CreateAsync(CreateClientAccessModel createClientAccessModel)
        {
            var clientAccess = _mapper.Map<ClientAccess>(createClientAccessModel);

            var firstClient = await _clientRepository.GetByNameAsync(createClientAccessModel.FirstClientFirstName, createClientAccessModel.FirstClientLastName)
                ?? throw new NotFoundException("Client was not found");

            clientAccess.FirstClient = firstClient;

            var secondClient = await _clientRepository.GetByNameAsync(createClientAccessModel.SecondClientFirstName, createClientAccessModel.SecondClientLastName)
                ?? throw new NotFoundException("Staff was not found");

            clientAccess.SecondClient = secondClient;

            var department = await _departmentRepository.GetByAddressAsync(createClientAccessModel.DepartmentAddress)
                ?? throw new NotFoundException("Department was not found");

            clientAccess.Department = department;   

            await _clientAccessRepository.CreateAsync(clientAccess);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClientAccessModel>(clientAccess);
        }

        public async Task UpdateAsync(int relationId, UpdateClientAccessModel updateClientAccessModel)
        {
            var clientAccess = await _clientAccessRepository.GetByRelationIdAsync(updateClientAccessModel.RelationId)
                              ?? throw new NotFoundException("ClientAccess was not found");

            var firstClient = await _clientRepository.GetByNameAsync(updateClientAccessModel.FirstClientFirstName, updateClientAccessModel.FirstClientLastName)
                ?? throw new NotFoundException("Client was not found");

            clientAccess.FirstClient = firstClient;

            var secondClient = await _clientRepository.GetByNameAsync(updateClientAccessModel.SecondClientFirstName, updateClientAccessModel.SecondClientLastName)
                ?? throw new NotFoundException("Staff was not found");

            clientAccess.SecondClient = secondClient;

            var department = await _departmentRepository.GetByAddressAsync(updateClientAccessModel.DepartmentAddress)
                ?? throw new NotFoundException("Department was not found");

            clientAccess.Department = department;

            clientAccess.AccessLevel = updateClientAccessModel.AccessLevel;

            _clientAccessRepository.Update(clientAccess);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int relationId)
        {
            var clientAccess = await _clientAccessRepository.GetByRelationIdAsync(relationId)
                              ?? throw new NotFoundException("ClientAccess was not found");

            _clientAccessRepository.Delete(clientAccess);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientAccessModel> GetByRelationIdAsync(int relationId)
        {
            var clientAccess = await _clientAccessRepository.GetByRelationIdAsync(relationId);
            return _mapper.Map<ClientAccessModel>(clientAccess);
        }

        public Task<PagedList<ClientAccessModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            throw new NotImplementedException();
        }
    }
}
