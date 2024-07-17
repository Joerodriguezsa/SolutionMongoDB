using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using MongoDB.Bson;

namespace Annarth.Application.Interface.IService
{
    public interface IEmployeeService
    {
        Task<Employee> GetByIdAsync(ObjectId id);
        Task<List<Employee>> GetAllAsync();
        Task CreateAsync(Employee Employee);
        Task<Employee> UpdateAsync(Employee Employee);
        Task<bool> DeleteAsync(ObjectId id);
        Task<List<Employee>> GetFilteredAsync(EmployeeFiltrarDTO criteria);
    }
}
