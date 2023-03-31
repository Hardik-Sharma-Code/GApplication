using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.DATA.Model
{
   public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public Department Department { get; set; }
    }
}
