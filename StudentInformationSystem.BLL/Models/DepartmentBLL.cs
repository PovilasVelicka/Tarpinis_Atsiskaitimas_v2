using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Models;

namespace StudentInformationSystem.BLL.Models
{
    internal class DepartmentBLL : IDepartmentBLL
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentBLL (IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public void AddLecture (int departmentId, ILectureEntity lecture)
        {
            var department = (Department)GetById (departmentId);
            if (!department.Lecture.Where (l => l.Id == lecture.Id).Any ( ))
            {
                department.Lecture.Add ((Lecture)lecture);
                _repository.AddOrUpdate (department);
            }
        }

        public void AddLectures (int departmentId, List<ILectureEntity> lectures)
        {
            foreach (var lecture in lectures)
            {
                AddLecture (departmentId, lecture);
            }
        }

        public void AddStudent (int departmentId, IStudentEntity student)
        {
            var department = (Department)GetById (departmentId);
            if (!department.Students.Where (l => l.Id == student.Id).Any ( ))
            {
                department.Students.Add ((Student)student);
                _repository.AddOrUpdate (department);
            }
        }

        public void AddStudents (int departmentId, List<IStudentEntity> students)
        {
            foreach (var student in students)
            {
                AddStudent (departmentId, student);
            }
        }

        public IDepartmentEntity CreateDepartment (string name, string city)
        {
            var depoId =
                _repository
                .GetAll ( )
                .Where (d => d.Name.ToLower ( ) == name.ToLower ( ) && d.City.ToLower ( ) == city.ToLower ( ))
                .FirstOrDefault ( )?.Id ?? 0;
            IDepartmentEntity department;
            if (depoId == 0)
            {
                department = new Department (name, city);
                _repository.AddOrUpdate (department);
            }
            else
                department = GetById (depoId);

            return department;
        }

        public void DeleteDepartment (int departmentId)
        {
            _repository.Remove (_repository.GetById (departmentId));
        }

        public List<IDepartmentEntity> GetByCity (string city)
        {
            return _repository.GetAllByCity (city).ToList ( );
        }

        public IDepartmentEntity GetById (int id)
        {
            return _repository.GetById (id);
        }

        public List<IDepartmentEntity> GetByName (string name)
        {
            return _repository.GetAllByName (name).ToList ( );
        }

        public void UpdateDepartment (int departmentId, string name, string city)
        {
            var depo = (Department)GetById (departmentId);
            depo.Name = name;
            depo.City = city;
            _repository.AddOrUpdate (depo);
        }
    }
}
