using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CL.Interfaces;

namespace StudentInformationSystem.BLL.Models
{
    public interface IStudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmenCity { get; set; }
    }
}
