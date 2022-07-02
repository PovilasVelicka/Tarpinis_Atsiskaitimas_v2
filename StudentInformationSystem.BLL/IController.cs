using StudentInformationSystem.BLL.Models;

namespace StudentInformationSystem.BLL
{
    internal interface IController
    {
        ILectureDto AddLecture (string title);
        void AddLectureTo (ILectureDto lecture, IDepartmentDto department);
        IStudentDto AddStudent (string firstName, string lastName, string personalCode);
        void AddStudentTo (IStudentDto student, IDepartmentDto studentDto);
        void TransverStudetnTo (IStudentDto student, IDepartmentDto department);
        IDepartmentDto AddDepartment (string departmentName, string city);

        List<IStudentDto> GetStudentsByDepartmentId (int departmentId);
        List<ILectureDto> GetLecturesByDepartmentId (int departmentId);
        List<ILectureDto> GetLecturesByStudentId (int studentId);

        List<IDepartmentDto> GetDepartments ( );
        List<IDepartmentDto> GetDepartments (string departmentNameSubstring);
        List<IStudentDto> GetStudents ( );
        List<IStudentDto> GetStudents (string departmentNameSubstring);
        List<IStudentDto> GetStudents (string firstNameSubstring, string lastNameSubstring);

        ILectureDto GetLectureById (int id);
        IDepartmentDto GetDepartmentById (int departmentId);
        IStudentDto GetStudentById (int id);
    }
}
