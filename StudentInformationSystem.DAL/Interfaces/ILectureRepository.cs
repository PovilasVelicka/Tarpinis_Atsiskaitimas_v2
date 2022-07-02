namespace StudentInformationSystem.DAL.Interfaces
{
    public interface ILectureRepository
    {
        ILectureEntity GetById (int id);
        IQueryable<ILectureEntity> GetByDepartmentId (int departmentId);
        IQueryable<ILectureEntity> GetByStudentId (int studentId);
        IQueryable<ILectureEntity> GetAllByName (string nameSubstring);
        IQueryable<ILectureEntity> GetAll ( );
        void AddOrUpdate (ILectureEntity entity);
        void Remove (ILectureEntity entity);
    }
}
