namespace StudentInformationSystem.DAL.Interfaces
{
    public interface IDataProvider : IDisposable
    {
        public IDepartmentRepository Departments { get; }
        public ILectureRepository Lectures { get; }
        public IStudentRepository Students { get; }
        public void Save ( );
    }
}
