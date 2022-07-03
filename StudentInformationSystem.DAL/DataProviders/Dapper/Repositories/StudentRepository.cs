using StudentInformationSystem.DAL.Interfaces;

namespace StudentInformationSystem.DAL.DataProviders.Dapper.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        public void AddOrUpdate (IStudentEntity student)
        {
            throw new NotImplementedException( );
        }

        public IQueryable<IStudentEntity> GetAll ( )
        {
            throw new NotImplementedException( );
        }

        public IQueryable<IStudentEntity> GetAllByFirstName (string firstName)
        {
            throw new NotImplementedException( );
        }

        public IQueryable<IStudentEntity> GetAllByLastName (string lastName)
        {
            throw new NotImplementedException( );
        }

        public IStudentEntity GetById (int id)
        {
            throw new NotImplementedException( );
        }

        public IStudentEntity? GetByPersonalCode (string personalCode)
        {
            throw new NotImplementedException( );
        }

        public void Remove (IStudentEntity student)
        {
            throw new NotImplementedException( );
        }
    }
}
