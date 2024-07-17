using Annarth.Application.Interface.IRepository;
using Annarth.Application.Interface.IService;
using Annarth.Domain.Entities;

namespace Annarth.Application.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> GetByIdAsync(string id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task CreateAsync(Company company)
        {
            await _companyRepository.CreateAsync(company);
        }

        public async Task<Company> UpdateAsync(string id, Company company)
        {
            return await _companyRepository.UpdateAsync(id, company);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _companyRepository.DeleteAsync(id);
        }
    }
}
