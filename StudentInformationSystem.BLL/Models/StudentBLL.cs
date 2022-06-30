using StudentInformationSystem.CL.Interfaces;

namespace StudentInformationSystem.BLL.Models
{
    internal class StudentBLL : IStudentBLL
    {
        readonly IStudentRepository _repository;

        public StudentBLL(IStudentRepository repository)
        {
            _repository = repository;
        }

        public bool CreateStudent(string firstName, string lastName, string personalCode)
        {
            var studentExists = _repository.GetByPersonalCode(personalCode) != null;
            if (!studentExists)
            {
                var student = (IStudentEntity)new object();
                student.FirstName = firstName;
                student.LastName = lastName;
                student.PersonalCode = personalCode;
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
            var student = _repository.GetById(studentId);
            student.Department = department;
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
