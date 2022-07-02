using StudentInformationSystem.BLL.Models;

namespace StudentInformationSystem.BLL
{
    public interface IController
    {
        void AddLecture (ILectureDto lecture);
        void AddLectureTo (ILectureDto lecture, IDepartmentDto department);
        void AddStudent (IStudentDto student);
        void AddStudentTo (IStudentDto student, IDepartmentDto studentDto);
        void TransverStudetnTo (IStudentDto student, IDepartmentDto department);
        void AddDepartment (IDepartmentDto department);

        List<IStudentDto> GetStudentsByDepartmentId (int departmentId);
        List<ILectureDto> GetLecturesByDepartmentId (int departmentId);
        List<ILectureDto> GetLecturesByStudentId (int studentId);

        List<IDepartmentDto> GetDepartments ( );
        List<IDepartmentDto> GetDepartments (string departmentNameSubstring);
        List<IStudentDto> GetStudents ( );
        List<IStudentDto> GetStudents (string departmentNameSubstring);
        List<IStudentDto> GetStudents (string firstNameSubstring, string lastNameSubstring);

    }
}
