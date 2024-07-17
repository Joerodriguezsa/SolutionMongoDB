﻿using Microsoft.EntityFrameworkCore;
using Annarth.Application.Interface.IRepository;
using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using System.Data;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Annarth.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AnnarthMongoDbContext _annarthDbContext;

        public EmployeeRepository(AnnarthMongoDbContext annarthDbContext)
        {
            _annarthDbContext = annarthDbContext;
        }

        /// <summary>
        /// Retorna Employee por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee> GetByIdAsync(ObjectId id)
        {
            return await _annarthDbContext.Employees.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Retorna Listado de Employee Registrados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _annarthDbContext.Employees.Find(_ => true).ToListAsync();
        }

        /// <summary>
        /// Creacion de Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task CreateAsync(Employee employee)
        {
            await _annarthDbContext.Employees.InsertOneAsync(employee);
        }

        /// <summary>
        /// Actualizacion de Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var result = await _annarthDbContext.Employees.ReplaceOneAsync(e => e.Id == employee.Id, employee);
            return result.IsAcknowledged ? employee : null;
        }

        /// <summary>
        /// Borrado de registro Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        public async Task<bool> DeleteAsync(ObjectId id)
        {
            var result = await _annarthDbContext.Employees.DeleteOneAsync(e => e.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        /// <summary>
        /// Filtra los empleados según los criterios proporcionados
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public async Task<List<Employee>> GetFilteredAsync(EmployeeFiltrarDTO criteria)
        {
            var filter = Builders<Employee>.Filter.Empty;

            //if (criteria.CompanyId.HasValue)
            //{
            //    filter &= Builders<Employee>.Filter.Eq(e => e.CompanyId, criteria.CompanyId.Value);
            //}

            if (!string.IsNullOrEmpty(criteria.CompanyName))
            {
                filter &= Builders<Employee>.Filter.Where(e => e.Company.CompanyName.Contains(criteria.CompanyName));
            }

            if (!string.IsNullOrEmpty(criteria.Email))
            {
                filter &= Builders<Employee>.Filter.Where(e => e.Email.Contains(criteria.Email));
            }

            if (!string.IsNullOrEmpty(criteria.Fax))
            {
                filter &= Builders<Employee>.Filter.Where(e => e.Fax.Contains(criteria.Fax));
            }

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                filter &= Builders<Employee>.Filter.Where(e => e.Name.Contains(criteria.Name));
            }

            if (!string.IsNullOrEmpty(criteria.Username))
            {
                filter &= Builders<Employee>.Filter.Where(e => e.Username.Contains(criteria.Username));
            }

            if (criteria.RoleId.HasValue)
            {
                filter &= Builders<Employee>.Filter.Eq(e => e.RoleId, criteria.RoleId.Value);
            }

            if (criteria.StatusId.HasValue)
            {
                filter &= Builders<Employee>.Filter.Eq(e => e.StatusId, criteria.StatusId.Value);
            }

            if (!string.IsNullOrEmpty(criteria.Telephone))
            {
                filter &= Builders<Employee>.Filter.Where(e => e.Telephone.Contains(criteria.Telephone));
            }

            return await _annarthDbContext.Employees.Find(filter).ToListAsync();
        }
    }
}
