namespace StudentInformationSystem.CL.Interfaces
{
    public interface ILectureRepository : IDisposable
    {
        ILectureEntity GetById(int id);
        IQueryable<ILectureEntity> GetByNameSubstring(string nameSubstring);
        void AddOrUpdate(ILectureEntity entity);
        void Remove(ILectureEntity entity);

    }
}
