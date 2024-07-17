using Microsoft.EntityFrameworkCore;
using Annarth.Application.Interface.IRepository;
using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using System.Data;

namespace Annarth.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AnnarthDbContext _annarthDbContext;

        public EmployeeRepository(AnnarthDbContext annarthDbContext)
        {
            _annarthDbContext = annarthDbContext;
        }

        /// <summary>
        /// Retorna Employee por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _annarthDbContext.Employee.Include(w => w.Company).FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Retorna Listado de Employee Registrados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _annarthDbContext.Employee.Include(w => w.Company).ToListAsync();
        }

        /// <summary>
        /// Creacion de Employee
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns>Registrado Creado</returns>
        public async Task CreateAsync(Employee Employee)
        {
            _annarthDbContext.Employee.Add(Employee);
            await _annarthDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Actualizacion de Employee
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        public async Task<Employee> UpdateAsync(Employee Employee)
        {
            var existingEmployee = await _annarthDbContext.Employee.FirstOrDefaultAsync(r => r.Id == Employee.Id);

            if (existingEmployee != null)
            {
                existingEmployee.CompanyId = Employee.CompanyId;
                existingEmployee.CreatedOn = Employee.CreatedOn;
                existingEmployee.DeletedOn = Employee.DeletedOn;
                existingEmployee.Email = Employee.Email;
                existingEmployee.Fax = Employee.Fax;
                existingEmployee.Name = Employee.Name;
                existingEmployee.Lastlogin = Employee.Lastlogin;
                existingEmployee.Password = Employee.Password;
                existingEmployee.PortalId = Employee.PortalId;
                existingEmployee.RoleId = Employee.RoleId;
                existingEmployee.StatusId = Employee.StatusId;
                existingEmployee.Telephone = Employee.Telephone;
                existingEmployee.UpdatedOn = Employee.UpdatedOn;
                existingEmployee.Username = Employee.Username;

        _annarthDbContext.Entry(existingEmployee).State = EntityState.Modified;

                try
                {
                    await _annarthDbContext.SaveChangesAsync();
                    return existingEmployee;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(Employee.Id))
                    {
                        return null;
                    }
                    throw;
                }
            }
            return null;
        }

        /// <summary>
        /// Borrado de registro Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var Employee = await _annarthDbContext.Employee.FindAsync(id);
            if (Employee == null)
            {
                return false;
            }

            _annarthDbContext.Employee.Remove(Employee);
            await _annarthDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Validacion si existe Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        private bool EmployeeExists(int id)
        {
            return _annarthDbContext.Employee.Any(e => e.Id == id);
        }

        /// <summary>
        /// Filtra los empleados según los criterios proporcionados
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public async Task<List<Employee>> GetFilteredAsync(EmployeeFiltrarDTO criteria)
        {
            IQueryable<Employee> query = _annarthDbContext.Employee.Include(w => w.Company);

            if (criteria.CompanyId.HasValue)
            {
                query = query.Where(e => e.CompanyId == criteria.CompanyId.Value);
            }

            if (!string.IsNullOrEmpty(criteria.CompanyName))
            {
                query = query.Where(e => e.Company.CompanyName.Contains(criteria.CompanyName));
            }

            if (!string.IsNullOrEmpty(criteria.Email))
            {
                query = query.Where(e => e.Email.Contains(criteria.Email));
            }

            if (!string.IsNullOrEmpty(criteria.Fax))
            {
                query = query.Where(e => e.Fax.Contains(criteria.Fax));
            }

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                query = query.Where(e => e.Name.Contains(criteria.Name));
            }

            if (!string.IsNullOrEmpty(criteria.Username))
            {
                query = query.Where(e => e.Username.Contains(criteria.Username));
            }

            if (criteria.RoleId.HasValue)
            {
                query = query.Where(e => e.RoleId == criteria.RoleId.Value);
            }

            if (criteria.StatusId.HasValue)
            {
                query = query.Where(e => e.StatusId == criteria.StatusId.Value);
            }

            if (!string.IsNullOrEmpty(criteria.Telephone))
            {
                query = query.Where(e => e.Telephone.Contains(criteria.Telephone));
            }

            return await query.ToListAsync();
        }

    }
}
