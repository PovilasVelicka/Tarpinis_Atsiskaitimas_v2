namespace StudentInformationSystem.CL.Interfaces
{
    public interface IStudentBLL
    {
       // protected IStudentRepository StudentRepository { get; }
        IStudentEntity CreateStudent(string firstName, string lastName, string personalCode, int departmentId);
        IStudentEntity? GetStudentByPersonalCode(string personalCode);
        List<IStudentEntity> GetStudentByFirstName(string firstName);
        List<IStudentEntity> GetStudentByLastName(string lastName);
        IStudentEntity GetById(int id);
        void MoveToDepartment(int studentId, IDepartmentEntity department);        
        void AddLecturesFromDepartment(int studentId, IDepartmentEntity department);
        void DeleteStudent(int studentId);
        void UpdateStudent(int studentId, string firstName, string lastName, string personalCode);
      
    }
}
