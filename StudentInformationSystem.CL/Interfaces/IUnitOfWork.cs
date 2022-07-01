namespace StudentInformationSystem.CL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IDepartmentRepository Departments { get; }
        public ILectureRepository Lectures { get; }
        public IStudentRepository Students { get; }
        public void Save();
    }
}
