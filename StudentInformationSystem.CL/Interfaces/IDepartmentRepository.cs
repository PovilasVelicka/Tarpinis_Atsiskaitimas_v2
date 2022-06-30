namespace StudentInformationSystem.CL.Interfaces
{
    public interface IDepartmentRepository : IDisposable
    {
        IDepartmentEntity GetById(int id);
        IQueryable<IDepartmentEntity> GetAll();
        IQueryable<IDepartmentEntity> GetAllByNameSubstring(string nameSubstring);
        IQueryable<IDepartmentEntity> GetAllByCity(string city);
        void AddOrUpdate(IDepartmentEntity entity);
        void Remove(IDepartmentEntity entity);

    }
}
