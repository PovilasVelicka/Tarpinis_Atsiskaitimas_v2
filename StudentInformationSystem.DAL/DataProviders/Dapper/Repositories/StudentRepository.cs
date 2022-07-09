using StudentInformationSystem.DAL.Interfaces;
using System.Data;

namespace StudentInformationSystem.DAL.DataProviders.Dapper.Repositories
{

    internal class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _context;

        public StudentRepository (IDbConnection context)
        {
            _context = context;
        }

        public void AddOrUpdate (IStudentEntity student)
        {
            throw new NotImplementedException( );
        }

        public IEnumerable<IStudentEntity> GetAll ( )
        {
            throw new NotImplementedException( );
        }

        public IEnumerable<IStudentEntity> GetAllByFirstName (string firstName)
        {
            throw new NotImplementedException( );
        }

        public IEnumerable<IStudentEntity> GetAllByLastName (string lastName)
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
