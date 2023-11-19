using AutoMapper;
using BLL.Models.User;
using BLL.Services.Interfaces;
using Core.Entity;
using Core.Exceptions;
using Core.Shared;
using DAL;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Sieve.Models;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(
            IUserRepository userRepository,
            AppDbContext context,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public async Task<PagedList<UserModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var users = await _userRepository.GetAllWithFilterAsync(sieveModel);
            return _mapper.Map<PagedList<UserModel>>(users);
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> CreateAsync(CreateUserModel createUserModel)
        {
            var user = _mapper.Map<User>(createUserModel);

            user.UserName = createUserModel.Email;

            var result = await _userManager.CreateAsync(user, createUserModel.Email);

            if (!result.Succeeded)
            {
                throw new Exception("Failed to create user");
            }

            return _mapper.Map<UserModel>(user);
        }

        public async Task UpdateAsync(int id, UpdateUserModel updateUserModel)
        {
            var user = await _userRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException("User was not found");

            user.FirstName = updateUserModel.FirstName;
            user.LastName = updateUserModel.LastName;
            user.Patronymic = updateUserModel.Patronymic;

            _userRepository.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException("User was not found");

            _userRepository.Delete(user);
            await _context.SaveChangesAsync();
        }
    }
}
