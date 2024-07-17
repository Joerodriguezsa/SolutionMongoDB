using Annarth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annarth.Infrastructure
{
    public class AnnarthDbContext: DbContext
    {
        public AnnarthDbContext(DbContextOptions<AnnarthDbContext> options): base(options)
        {
            InitalizeContext();
        }

        protected virtual void InitalizeContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //Database.SetCommandTimeout(360);
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }    
}
