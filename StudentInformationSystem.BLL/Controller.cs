using StudentInformationSystem.BLL.Models;
using StudentInformationSystem.DAL;
using StudentInformationSystem.DAL.Models;

namespace StudentInformationSystem.BLL
{
    public class Controller : IController
    {
        private readonly UnitOfWork _repository;
        public Controller ( )
        {
            _repository = new UnitOfWork( );
        }

        public void AddDepartment (IDepartmentDto department)
        {
            var exists = _repository.Departments.GetAllByName(department.Name).Any( );
            if (!exists)
            {
                var departmentEntity = new Department(department.Name, department.City);
                _repository.Departments.AddOrUpdate(departmentEntity);
            }
        }

        public void AddLecture (ILectureDto lecture)
        {
            var exists = _repository.Lectures.GetAllByName(lecture.Title).Any( );
            if (!exists)
            {
                _repository.Lectures.AddOrUpdate(new Lecture(lecture.Title));
            }
        }

        public void AddLectureTo (ILectureDto lecture, IDepartmentDto department)
        {
            AddLecture(lecture);
            var lectureEntity = (Lecture)_repository.Lectures.GetAllByName(lecture.Title).First( );
            var depo = (Department)_repository.Departments.GetById(department.Id);
            if (!depo.Lectures.Where(l => l.Name == lecture.Title).Any( ))
            {
                depo.Lectures.Add(lectureEntity);
                _repository.Departments.AddOrUpdate(depo);
            }
        }

        public void AddStudent (IStudentDto student)
        {
            var studenNotExists = _repository.Students.GetByPersonalCode(student.PersonalCode) == null;
            if (studenNotExists)
            {
                var studentEntity = new Student(student.FirstName, student.LastName, student.PersonalCode);
                _repository.Students.AddOrUpdate(studentEntity);
            }
        }

        public void AddStudentTo (IStudentDto student, IDepartmentDto department)
        {
            var studentEntity = (Student)_repository.Students.GetById(student.Id);
            var departmentEntity = (Department)_repository.Departments.GetById(department.Id);

            studentEntity.Department = departmentEntity;
            studentEntity.Lectures.Clear( );
            studentEntity.Lectures.AddRange(departmentEntity.Lectures);
            _repository.Save( );
        }

        public void TransverStudetnTo (IStudentDto student, IDepartmentDto department)
        {
            AddStudentTo(student, department);
        }
        public List<IDepartmentDto> GetDepartments ( )
        {
            throw new NotImplementedException( );
        }

        public List<IDepartmentDto> GetDepartments (string departmentNameSubstring)
        {
            throw new NotImplementedException( );
        }

        public List<ILectureDto> GetLecturesByDepartmentId (int departmentId)
        {
            throw new NotImplementedException( );
        }

        public List<ILectureDto> GetLecturesByStudentId (int studentId)
        {
            throw new NotImplementedException( );
        }

        public List<IStudentDto> GetStudents ( )
        {
            throw new NotImplementedException( );
        }

        public List<IStudentDto> GetStudents (string departmentNameSubstring)
        {
            throw new NotImplementedException( );
        }

        public List<IStudentDto> GetStudents (string firstNameSubstring, string lastNameSubstring)
        {
            throw new NotImplementedException( );
        }

        public List<IStudentDto> GetStudentsByDepartmentId (int departmentId)
        {
            throw new NotImplementedException( );
        }


    }
}
