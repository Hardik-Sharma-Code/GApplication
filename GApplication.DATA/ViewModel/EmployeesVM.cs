using GApplication.DATA.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;

namespace GApplication.DATA.ViewModel
{
    public class EmployeesVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string[] EmployeeType{ get; set; }
        public string EDepartment { get; set; }
        public List<EmployeeTypeList> employeeTypeLists { get; set; }


    }
    public class EmployeeTypeList
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
    

   
}
