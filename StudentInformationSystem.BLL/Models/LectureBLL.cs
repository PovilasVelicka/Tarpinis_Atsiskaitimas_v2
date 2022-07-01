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
  
            if (id == 0)
            {
                var lecture = new Lecture(name);
                _repository.AddOrUpdate(lecture);
                id = lecture.Id;
            }
       
            return _repository.GetById(id);
        }

        public void DeleteLecture(int lectureId)
        {
            var lecture = _repository.GetById(lectureId);

        }

        public ILectureEntity GetById(int id)
        {
            return _repository.GetById(id);
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
