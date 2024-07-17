using Annarth.Application.Interface.IRepository;
using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Annarth.Infrastructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AnnarthMongoDbContext _annarthDbContext;

        public CompanyRepository(AnnarthMongoDbContext annarthDbContext)
        {
            _annarthDbContext = annarthDbContext;
        }

        public async Task<Company> GetByIdAsync(string id)
        {
            return await _annarthDbContext.Companies.Find(c => c.Id.ToString() == id).FirstOrDefaultAsync();
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _annarthDbContext.Companies.Find(_ => true).ToListAsync();
        }

        public async Task CreateAsync(Company company)
        {
            await _annarthDbContext.Companies.InsertOneAsync(company);
        }

        public async Task<Company> UpdateAsync(string id, Company company)
        {
            var result = await _annarthDbContext.Companies.ReplaceOneAsync(c => c.Id.ToString() == id, company);
            return result.IsAcknowledged ? company : null;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _annarthDbContext.Companies.DeleteOneAsync(c => c.Id.ToString() == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}
