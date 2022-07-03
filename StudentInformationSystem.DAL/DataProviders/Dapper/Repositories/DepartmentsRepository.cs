using StudentInformationSystem.DAL.Interfaces;

namespace StudentInformationSystem.DAL.DataProviders.Dapper.Repositories
{
    internal class DepartmentsRepository : IDepartmentRepository
    {
        private readonly RepositoryDbContext _context;

        public DepartmentsRepository (RepositoryDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate (IDepartmentEntity entity)
        {
            throw new NotImplementedException( );
        }

        public IQueryable<IDepartmentEntity> GetAll ( )
        {
            throw new NotImplementedException( );
        }

        public IQueryable<IDepartmentEntity> GetAllByCity (string citySubstring)
        {
            throw new NotImplementedException( );
        }

        public IQueryable<IDepartmentEntity> GetAllByName (string nameSubstring)
        {
            throw new NotImplementedException( );
        }

        public IDepartmentEntity GetById (int id)
        {
            throw new NotImplementedException( );
        }

        public void Remove (IDepartmentEntity entity)
        {
            throw new NotImplementedException( );
        }
    }
}
