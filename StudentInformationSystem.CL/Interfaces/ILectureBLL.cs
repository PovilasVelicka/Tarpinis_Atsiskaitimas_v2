namespace StudentInformationSystem.CL.Interfaces
{
    public interface ILectureBLL
    {
        ILectureEntity CreateLectrue(string name);
        List<ILectureEntity> GetByName(string name);
        void UpdateLecture(int lectureId, string name);
        void DeleteLecture(int lectureId);
    }
}
