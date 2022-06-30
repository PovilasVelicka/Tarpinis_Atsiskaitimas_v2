using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Models;
namespace StudentInformationSystem.BLL.Models
{
    internal class LectureBLL : ILectureBLL
    {
        private readonly ILectureRepository _repository;

        public LectureBLL(ILectureRepository repository)
        {
            _repository = repository;
        }

        public ILectureEntity CreateLectrue(string name)
        {
            var id = _repository.GetByNameSubstring(name).FirstOrDefault()?.Id ?? 0;
            ILectureEntity lecture;
            if (id == 0)
                lecture = new Lecture(name);
            else
            {
                lecture = _repository.GetById(id);
            }

            _repository.AddOrUpdate(new Lecture(name));

            return lecture;
        }

        public void DeleteLecture(int lectureId)
        {
            var lecture = _repository.GetById(lectureId);

        }

        public List<ILectureEntity> GetByName(string name)
        {
            return _repository.GetByNameSubstring(name).OrderBy(l => l.Name).ToList();
        }

        public void UpdateLecture(int lectureId, string name)
        {
            var lecture = _repository.GetById(lectureId);
            lecture.Name = name;
            _repository.AddOrUpdate(lecture);
        }
    }
}
