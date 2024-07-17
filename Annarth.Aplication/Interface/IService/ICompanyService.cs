using Annarth.Domain.DTO;
using Annarth.Domain.Entities;

namespace Annarth.Application.Interface.IService
{
    public interface ICompanyService
    {
        Task<Company> GetByIdAsync(string id);
        Task<List<Company>> GetAllAsync();
        Task CreateAsync(Company companyDTO);
        Task<Company> UpdateAsync(string id, Company companyDTO);
        Task<bool> DeleteAsync(string id);
    }
}
