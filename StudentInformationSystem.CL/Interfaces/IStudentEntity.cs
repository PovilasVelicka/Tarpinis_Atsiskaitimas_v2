using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.CL.Interfaces
{
    public interface IStudentEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalCode { get; set; }


        List<ILectureEntity> Entities { get; set; }
        IDepartmentEntity Department { get; set; }
    }
}
