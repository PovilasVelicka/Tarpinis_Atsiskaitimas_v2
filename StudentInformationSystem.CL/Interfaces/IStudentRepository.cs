namespace StudentInformationSystem.CL.Interfaces
{
    public interface IStudentRepository : IDisposable
    {
        IStudentEntity GetById(int id);
        IStudentEntity? GetByPersonalCode(string personalCode);
        IQueryable<IStudentEntity> GetAll();
        IQueryable<IStudentEntity> GetAllByFirstName(string firstName);
        IQueryable<IStudentEntity> GetAllByLastName(string lastName);
        void AddOrUpdate(IStudentEntity student);
        void Remove(IStudentEntity student);
    }
}
