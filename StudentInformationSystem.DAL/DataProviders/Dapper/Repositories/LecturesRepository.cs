using StudentInformationSystem.DAL.Interfaces;
using System.Data;

namespace StudentInformationSystem.DAL.DataProviders.Dapper.Repositories
{
    internal class LecturesRepository : ILectureRepository
    {
        private readonly IDbConnection  _context;

        public LecturesRepository (IDbConnection context)
        {
            _context = context;
        }

        public void AddOrUpdate (ILectureEntity entity)
        {
            throw new NotImplementedException( );
        }

        public IEnumerable<ILectureEntity> GetAll ( )
        {
            throw new NotImplementedException( );
        }

        public IEnumerable<ILectureEntity> GetAllByName (string nameSubstring)
        {
            throw new NotImplementedException( );
        }

        public IEnumerable<ILectureEntity> GetByDepartmentId (int departmentId)
        {
            throw new NotImplementedException( );
        }

        public ILectureEntity GetById (int id)
        {
            throw new NotImplementedException( );
        }

        public IEnumerable<ILectureEntity> GetByStudentId (int studentId)
        {
            throw new NotImplementedException( );
        }

        public void Remove (ILectureEntity entity)
        {
            throw new NotImplementedException( );
        }
    }
}
