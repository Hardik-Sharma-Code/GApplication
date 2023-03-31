using GApplication.DATA.BaseRepositry;
using GApplication.DATA.EFContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.DATA.BaseRepositry
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _db;
        public IEmployeesRepository employees { get; }
        public IDepartmentRepository departments { get; }

        public UnitOfWork(ApplicationContext db,
                            IEmployeesRepository employees, IDepartmentRepository departments)
        {
            this._db = db;
            this.employees = employees;
            this.departments= departments;
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}
