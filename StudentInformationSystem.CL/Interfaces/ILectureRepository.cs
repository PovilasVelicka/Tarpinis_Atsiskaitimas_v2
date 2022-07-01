namespace StudentInformationSystem.CL.Interfaces
{
    public interface ILectureRepository 
    {
        ILectureEntity GetById(int id);
        IQueryable<ILectureEntity> GetByNameSubstring(string nameSubstring);
        IQueryable<ILectureEntity> GetAll();
        void AddOrUpdate(ILectureEntity entity);
        void Remove(ILectureEntity entity);

    }
}
