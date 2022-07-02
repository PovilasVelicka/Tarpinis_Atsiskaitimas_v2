using StudentInformationSystem.BLL.DTOs;

namespace StudentInformationSystem.BLL
{
    internal interface IController
    {
        ILectureDto AddLecture (string title);
        void AddLectureTo (ILectureDto lecture, IDepartmentDto department);
        ILectureDto GetLectureById (int id);
        List<IStudentDto> GetStudentsByDepartmentId (int departmentId);
        List<ILectureDto> GetLecturesByDepartmentId (int departmentId);
        List<ILectureDto> GetLecturesByStudentId (int studentId);


        IDepartmentDto AddDepartment (string departmentName, string city);
        IDepartmentDto GetDepartmentById (int departmentId);
        List<IDepartmentDto> GetDepartments ( );
        List<IDepartmentDto> GetDepartments (string departmentNameSubstring);


        IStudentDto AddStudent (string firstName, string lastName, string personalCode);
        void AddStudentTo (IStudentDto student, IDepartmentDto studentDto);
        IStudentDto GetStudentById (int id);
        List<IStudentDto> GetStudents ( );
        List<IStudentDto> GetStudents (string departmentNameSubstring);
        List<IStudentDto> GetStudents (string firstNameSubstring, string lastNameSubstring);




    }
}
