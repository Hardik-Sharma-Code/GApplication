using GApplication.DATA.BaseRepositry;
using GApplication.DATA.EFContext;
using GApplication.DATA.Model;
using GApplication.DATA.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.DATA.BaseRepositry
{
    public class EmployeesRepository : BaseRepository<Employees>, IEmployeesRepository
    {

        private readonly ApplicationContext db;

        public EmployeesRepository(ApplicationContext db) : base(db)
        {
            this.db = db;
        }
       
    }
}
