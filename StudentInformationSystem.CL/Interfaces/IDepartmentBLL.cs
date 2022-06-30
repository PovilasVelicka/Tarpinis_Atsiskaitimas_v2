using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.CL.Interfaces
{
    public interface IDepartmentBLL
    {
      //  protected IDepartmentRepository DepartmentRepository { get; }
        bool CreateDepartment(string name, string city);
        List<IDepartmentEntity> GetByName(string name);
        List<IDepartmentEntity> GetByCity(string city);
        void AddStudents(int departmentId, List<IStudentEntity> students);
        void AddStudent(int departmentId, IStudentEntity student);
        void AddLectures(int departmentId, List<ILectureEntity> lectures);
        void AddLecture(int departmentId, ILectureEntity lecture);
        void UpdateDepartment(int departmentId, string name , string city );
        void DeleteDepartment(int departmentId);
    }
}
