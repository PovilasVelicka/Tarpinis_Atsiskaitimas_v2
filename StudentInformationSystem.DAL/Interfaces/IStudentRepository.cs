namespace StudentInformationSystem.DAL.Interfaces
{
    public interface IStudentRepository
    {
        IStudentEntity GetById (int id);
        IStudentEntity? GetByPersonalCode (string personalCode);
        IEnumerable<IStudentEntity> GetAll ( );
        IEnumerable<IStudentEntity> GetAllByFirstName (string firstName);
        IEnumerable<IStudentEntity> GetAllByLastName (string lastName);
        void AddOrUpdate (IStudentEntity student);
        void Remove (IStudentEntity student);
    }
}
