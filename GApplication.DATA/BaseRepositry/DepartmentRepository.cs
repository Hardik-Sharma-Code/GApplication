using GApplication.DATA.BaseRepositry;
using GApplication.DATA.EFContext;
using GApplication.DATA.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.DATA.BaseRepositry
{
    public class DepartmentRepository:BaseRepository<Department>,IDepartmentRepository
    {
        private readonly ApplicationContext _db;

        public DepartmentRepository(ApplicationContext db): base(db)
        {
            this._db = db;
        }

        public async Task<Department> FindByNameAsync(string name)
        {
            var _deptName  = await _db.Departments.Where(x=>x.DepartmentName == name).FirstOrDefaultAsync();
            return _deptName;
        }
    }
}
