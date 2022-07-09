namespace StudentInformationSystem.DAL.Interfaces
{
    public interface ILectureRepository
    {
        ILectureEntity GetById (int id);
        IEnumerable<ILectureEntity> GetByDepartmentId (int departmentId);
        IEnumerable<ILectureEntity> GetByStudentId (int studentId);
        IEnumerable<ILectureEntity> GetAllByName (string nameSubstring);
        IEnumerable<ILectureEntity> GetAll ( );
        void AddOrUpdate (ILectureEntity entity);
        void Remove (ILectureEntity entity);
    }
}
