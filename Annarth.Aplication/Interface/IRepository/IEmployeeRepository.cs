using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using MongoDB.Bson;

namespace Annarth.Application.Interface.IRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(ObjectId id);
        Task<List<Employee>> GetAllAsync();
        Task CreateAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(ObjectId id);
        Task<List<Employee>> GetFilteredAsync(EmployeeFiltrarDTO criteria);
    }
}
