using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.CL.Interfaces
{
    public interface IDepartmentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        //List<IStudentEntity> Students { get; set; }
        //List<ILectureEntity> Lecture { get; set; }
    }
}
