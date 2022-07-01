namespace StudentInformationSystem.CL.Interfaces
{
    public interface IDepartmentRepository
    {
        IDepartmentEntity GetById (int id);
        IQueryable<IDepartmentEntity> GetAll ( );
        IQueryable<IDepartmentEntity> GetAllByName (string nameSubstring);
        IQueryable<IDepartmentEntity> GetAllByCity (string citySubstring);
        void AddOrUpdate (IDepartmentEntity entity);
        void Remove (IDepartmentEntity entity);
    }
}
