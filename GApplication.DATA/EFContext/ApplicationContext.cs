using GApplication.DATA.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.DATA.EFContext
{
   public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }
    }
}
