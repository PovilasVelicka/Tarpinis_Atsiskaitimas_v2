using StudentInformationSystem.CL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StudentInformationSystem.BLL.Models
{
    internal class DepartmentBLL : IDepartmentBLL
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentBLL(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public void AddLecture(int departmentId, ILectureEntity lecture)
        {
            var department = _repository.GetById(departmentId);
            if (!department.Lecture.Where(l => l.Id == lecture.Id).Any())
            {
                department.Lecture.Add(lecture);
                
            }
        }

        public void AddLectures(int departmentId, List<ILectureEntity> lectures)
        {
            foreach (var lecture in lectures)
            {
                AddLecture(departmentId, lecture);
            }
        }

        public void AddStudent(int departmentId, IStudentEntity student)
        {
            var department = _repository.GetById(departmentId);
            if (!department.Lecture.Where(l => l.Id == student.Id).Any())
            {
                department.Students.Add(student);
            }
        }

        public void AddStudents(int departmentId, List<IStudentEntity> students)
        {
            foreach (var student in students)
            {
                AddStudent(departmentId, student);
            }
        }

        public bool CreateDepartment(string name, string city)
        {
            var depoExists =
                _repository
                .GetAll()
                .Where(d => d.Name.ToLower() == name.ToLower() && d.City.ToLower() == city.ToLower())
                .Any();

            if (!depoExists)
            {
                var depoFromObject = (IDepartmentEntity)new object();
                depoFromObject.Name = name;
                depoFromObject.City = city;
                _repository.AddOrUpdate(depoFromObject);
                return true;
            }
            return false;
        }

        public void DeleteDepartment(int departmentId)
        {
            _repository.Remove(_repository.GetById(departmentId));
        }

        public List<IDepartmentEntity> GetByCity(string city)
        {
            return _repository.GetAllByCity(city).ToList();
        }

        public List<IDepartmentEntity> GetByName(string name)
        {
            return _repository.GetAllByNameSubstring(name).ToList();
        }

        public void UpdateDepartment(int departmentId, string name, string city)
        {
            var depo = _repository.GetById(departmentId);
            depo.Name = name;
            depo.City = city;
            _repository.AddOrUpdate(depo);
        }
    }
}
