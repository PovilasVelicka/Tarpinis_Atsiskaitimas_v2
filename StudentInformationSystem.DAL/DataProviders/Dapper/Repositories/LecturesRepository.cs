using StudentInformationSystem.DAL.Interfaces;

namespace StudentInformationSystem.DAL.DataProviders.Dapper.Repositories
{
    internal class LecturesRepository : ILectureRepository
    {
        public void AddOrUpdate (ILectureEntity entity)
        {
            throw new NotImplementedException( );
        }

        public IQueryable<ILectureEntity> GetAll ( )
        {
            throw new NotImplementedException( );
        }

        public IQueryable<ILectureEntity> GetAllByName (string nameSubstring)
        {
            throw new NotImplementedException( );
        }

        public IQueryable<ILectureEntity> GetByDepartmentId (int departmentId)
        {
            throw new NotImplementedException( );
        }

        public ILectureEntity GetById (int id)
        {
            throw new NotImplementedException( );
        }

        public IQueryable<ILectureEntity> GetByStudentId (int studentId)
        {
            throw new NotImplementedException( );
        }

        public void Remove (ILectureEntity entity)
        {
            throw new NotImplementedException( );
        }
    }
}
