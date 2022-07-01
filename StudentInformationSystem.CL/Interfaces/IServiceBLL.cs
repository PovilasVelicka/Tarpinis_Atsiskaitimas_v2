namespace StudentInformationSystem.CL.Interfaces
{
    public interface IServiceBLL : IDisposable
    {
        public IStudentBLL Students { get; }
        public IDepartmentBLL Departments { get; }
        public ILectureBLL Lectures { get; }
        public void SaveChanges();

    }
}
