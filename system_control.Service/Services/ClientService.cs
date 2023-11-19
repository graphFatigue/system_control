using AutoMapper;
using BLL.Models.Staff;
using BLL.Services.Interfaces;
using Core.Entity;
using Core.Exceptions;
using Core.Shared;
using DAL.Repositories.Interfaces;
using DAL;
using Google.Apis.Services;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Client;

namespace BLL.Services
{
    public class ClientService: Interfaces.IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ClientService(
            IClientRepository clientRepository,
            IUserRepository userRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _clientRepository = clientRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ClientModel> CreateAsync(CreateClientModel createClientModel)
        {
            var client = new Client();

            var userName = createClientModel.User.Split(' ');
            var firstName = userName[0];
            var lastName = userName[1];

            var user = await _userRepository.GetByNameAsync(firstName, lastName)
                       ?? throw new NotFoundException("User was not found");

            client.User = user;

            await _clientRepository.CreateAsync(client);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClientModel>(client);
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException($"Client with id {id} was not found");

            _clientRepository.Delete(client);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClientModel>> GetAllAsync()
        {
            var client = await _clientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientModel>>(client);
        }

        public async Task<PagedList<ClientModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _clientRepository.GetAllWithFilterAsync(sieveModel);
            var clientModels = _mapper.Map<IEnumerable<ClientModel>>(pagedList.Items);

            var updatedPagedList = PagedList<ClientModel>.Copy(pagedList, clientModels);

            return updatedPagedList;
        }

        public async Task<ClientModel> GetByIdAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException($"Client with id {id} was not found");

            return _mapper.Map<ClientModel>(client);
        }

        public async Task UpdateAsync(int id, UpdateClientModel updateClientModel)
        {
            var client = await _clientRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException($"Staff with id {id} was not found");

            var userName = updateClientModel.User.Split(' ');
            var firstName = userName[0];
            var lastName = userName[1];

            var user = await _userRepository.GetByNameAsync(firstName, lastName)
                       ?? throw new NotFoundException("User was not found");

            client.User = user;

            _clientRepository.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
