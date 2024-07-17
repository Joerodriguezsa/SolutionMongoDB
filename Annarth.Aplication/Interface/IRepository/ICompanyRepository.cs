using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using MongoDB.Bson;

namespace Annarth.Application.Interface.IRepository
{
    public interface ICompanyRepository
    {
        Task<Company> GetByIdAsync(string id);
        Task<List<Company>> GetAllAsync();
        Task CreateAsync(Company companyDTO);
        Task<Company> UpdateAsync(string id, Company companyDTO);
        Task<bool> DeleteAsync(string id);
    }
}
