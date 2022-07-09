namespace StudentInformationSystem.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        IDepartmentEntity GetById (int id);
        IEnumerable<IDepartmentEntity> GetAll ( );
        IEnumerable<IDepartmentEntity> GetAllByName (string nameSubstring);
        IEnumerable<IDepartmentEntity> GetAllByCity (string citySubstring);
        void AddOrUpdate (IDepartmentEntity entity);
        void Remove (IDepartmentEntity entity);
    }
}
