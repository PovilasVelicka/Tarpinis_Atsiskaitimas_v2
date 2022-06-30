namespace StudentInformationSystem.CL.Interfaces
{
    public interface ILectureBLL
    {
        protected ILectureRepository LectureRepository { get;  }
        bool CreateLectrue(string name);
        List<ILectureEntity> GetByName(string name);
        void UpdateLecture(int lectureId, string name);
        void DeleteLecture(int lectureId);
    }
}
