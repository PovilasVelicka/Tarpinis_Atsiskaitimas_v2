namespace StudentInformationSystem.CL.Interfaces
{
    public interface IStudentBLL
    {
        protected IStudentRepository StudentRepository { get; }
        bool CreateStudent(string firstName, string lastName, string personalCode);
        IStudentEntity GetStudentByPersonalCode(string personalCode);
        List<IStudentEntity> GetStudentByFirstName(string firstName);
        List<IStudentEntity> GetStudentByLastName(string lastName);
        void MoveToDepartment(int studentId, int departmentId);
        void DeleteStudent(int studentId);
        void UpdateStudent(int studentId, string firstName, string lastName, string personalCode);
    }
}
