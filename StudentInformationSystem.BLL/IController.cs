using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.BLL.Models;

namespace StudentInformationSystem.BLL
{
    public interface IController
    {
        void AddLecture (ILectureDto lecture);
        void AddLectureTo (ILectureDto lecture, IDepartmentDto department);
        void AddStudent (IStudentDto student);
        void AddStudentTo(IStudentDto student, IDepartmentDto studentDto);
        void TransverStudetnTo (IStudentDto student, IDepartmentDto department);
        void AddDepartment (IDepartmentDto department);
    }
}
