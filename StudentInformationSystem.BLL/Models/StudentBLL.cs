using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Models;
namespace StudentInformationSystem.BLL.Models
{
    internal class StudentBLL : IStudentBLL
    {
        readonly IStudentRepository _repository;

        public StudentBLL(IStudentRepository repository)
        {
            _repository = repository;
        }

        public bool CreateStudent(string firstName, string lastName, string personalCode, int departmentId)
        {
            var studentExists = _repository.GetByPersonalCode(personalCode) != null;
            if (!studentExists)
            {
                var student = new Student(firstName, lastName, personalCode, departmentId);

                _repository.AddOrUpdate(student);
                return true;
            }
            return false;
        }

        public void DeleteStudent(int studentId)
        {
            var student = _repository.GetById(studentId);
            _repository.Remove(student);
        }

        public List<IStudentEntity> GetStudentByFirstName(string firstName)
        {
            return _repository.GetAllByFirstName(firstName).OrderBy(s => s.FirstName).ToList();
        }

        public List<IStudentEntity> GetStudentByLastName(string lastName)
        {
            return GetStudentByLastName(lastName).OrderBy(s => s.LastName).ToList();
        }

        public IStudentEntity? GetStudentByPersonalCode(string personalCode)
        {
            return _repository.GetByPersonalCode(personalCode);
        }

        public void MoveToDepartment(int studentId, IDepartmentEntity department)
        {
            var student = (Student)_repository.GetById(studentId);
            var depo = (Department)department;
            student.Department = depo;
            student.Lectures.Clear();
            AddLecturesFromDepartment(studentId, depo);
            _repository.AddOrUpdate(student);
        }

        public void AddLecturesFromDepartment(int studentId, IDepartmentEntity department)
        {
            var student = (Student)_repository.GetById(studentId);
            var depo = (Department)department;
            foreach (var lecture in depo.Lecture)
            {
                if (!student.Lectures.Where(x => x.Id == lecture.Id).Any())
                {
                    student.Lectures.Add(lecture);
                }
            }
            _repository.AddOrUpdate(student);

        }

        public void UpdateStudent(int studentId, string firstName, string lastName, string personalCode)
        {
            var student = _repository.GetById(studentId);
            student.FirstName = firstName;
            student.LastName = lastName;
            student.PersonalCode = personalCode;
            _repository.AddOrUpdate(student);
        }
    }
}
