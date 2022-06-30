using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CL.Interfaces;

namespace StudentInformationSystem.BLL.Models
{
    internal class LectureBLL : ILectureBLL
    {
        private readonly ILectureRepository _repository;

        public LectureBLL(ILectureRepository repository)
        {
            _repository = repository;
        }

        public bool CreateLectrue(string name)
        {
            var lectureExists = _repository.GetByNameSubstring(name).Any();
            if (!lectureExists)
            {
                var lecture = (ILectureEntity)new object();
                lecture.Name = name;
                _repository.AddOrUpdate(lecture);
                return true;
            }
            return false;
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
