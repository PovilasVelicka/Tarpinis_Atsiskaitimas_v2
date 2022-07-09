using StudentInformationSystem.DAL.Interfaces;
using System.Data;
using Dapper;

namespace StudentInformationSystem.DAL.DataProviders.Dapper.Repositories
{
    internal class DepartmentsRepository : BaseRepository<IDepartmentEntity>, IDepartmentRepository
    {
        public DepartmentsRepository (IDbConnection dbConnection) : base(dbConnection) { }     

        public void AddOrUpdate (IDepartmentEntity entity)
        {
            throw new NotImplementedException( );
        }

        public IEnumerable<IDepartmentEntity> GetAll ( )
        {
            return base.Get("", "");
        }

        public IEnumerable<IDepartmentEntity> GetAllByCity (string citySubstring)
        {
            throw new NotImplementedException( );
        }

        public IEnumerable<IDepartmentEntity> GetAllByName (string nameSubstring)
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
