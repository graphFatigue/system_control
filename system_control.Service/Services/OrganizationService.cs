using AutoMapper;
using BLL.Models.Organization;
using BLL.Services.Interfaces;
using Core.Entity;
using Core.Enum;
using Core.Exceptions;
using Core.Shared;
using DAL;
using DAL.Repositories.Interfaces;
using Sieve.Models;

namespace BLL.Services
{
    public class OrganizationService: IOrganizationService
    {
        private readonly AppDbContext _context;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;

        public OrganizationService(
            AppDbContext context,
            IOrganizationRepository organizationRepository,
            IMapper mapper)
        {
            _context = context;
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrganizationModel>> GetAllAsync()
        {
            var organizations = await _organizationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrganizationModel>>(organizations);
        }

        public async Task<PagedList<OrganizationModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _organizationRepository.GetAllWithFilterAsync(sieveModel);
            var organizationModels = _mapper.Map<IEnumerable<OrganizationModel>>(pagedList.Items);

            var updatedPagedList = PagedList<OrganizationModel>.Copy(pagedList, organizationModels);

            return updatedPagedList;
        }

        public async Task<OrganizationModel> GetByIdAsync(int id)
        {
            var organization = await _organizationRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Organization with id {id} was not found");

            return _mapper.Map<OrganizationModel>(organization);
        }

        public async Task<OrganizationModel> CreateAsync(CreateOrganizationModel createOrganizationModel)
        {
            var organization = _mapper.Map<Organization>(createOrganizationModel);

            await _organizationRepository.CreateAsync(organization);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrganizationModel>(organization);
        }

        public async Task UpdateAsync(int id, UpdateOrganizationModel updateOrganizationModel)
        {
            var organization = await _organizationRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Club with id {id} was not found");

            if (!string.IsNullOrWhiteSpace(updateOrganizationModel.Name))
            {
                organization.Name = updateOrganizationModel.Name;
            }

            if (!string.IsNullOrWhiteSpace(updateOrganizationModel.Description))
            {
                organization.Description = updateOrganizationModel.Description;
            }

            if (!string.IsNullOrWhiteSpace(updateOrganizationModel.Country))
            {
                organization.Country = Enum.Parse<Country>(updateOrganizationModel.Country);
            }

            if (!string.IsNullOrWhiteSpace(updateOrganizationModel.TypeOrganization))
            {
                organization.TypeOrganization = Enum.Parse<TypeOrganization>(updateOrganizationModel.TypeOrganization);
            }

            _organizationRepository.Update(organization);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var organization = await _organizationRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Club with id {id} was not found");

            if (organization.Departments != null && organization.Departments.Any())
            {
                throw new BadRequestException($"Organization with id {id} can't be deleted, it still has departments");
            }
            _organizationRepository.Delete(organization);
            await _context.SaveChangesAsync();
        }
    }
}
