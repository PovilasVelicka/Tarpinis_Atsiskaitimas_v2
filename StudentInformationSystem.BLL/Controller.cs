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
            return GetAllDepartments( ).ToList<IDepartmentDto>( );
        }

        public List<IDepartmentDto> GetDepartments (string departmentNameSubstring)
        {
            var nameLowerCase = departmentNameSubstring.ToLower( );

            return GetAllDepartments( )
                .Where(d => d.Name.ToLower( ).Contains(nameLowerCase)).
                ToList<IDepartmentDto>( );
        }

        public List<ILectureDto> GetLecturesByDepartmentId (int departmentId)
        {
            return _repository
                .Lectures
                .GetByDepartmentId(departmentId)
                .Select(l =>
                    new LectureDto
                    {
                        Id = l.Id,
                        Title = l.Name
                    })
                .ToList<ILectureDto>( );
        }

        public List<ILectureDto> GetLecturesByStudentId (int studentId)
        {
            return _repository
                .Lectures
                .GetByStudentId(studentId)
                .Select(l =>
                    new LectureDto
                    {
                        Id = l.Id,
                        Title = l.Name,
                    })
                .ToList<ILectureDto>( );
        }

        public List<IStudentDto> GetStudents ( )
        {
            var result = from student in _repository.Students.GetAll( )
                         join depo in _repository.Departments.GetAll( ) on student.DepartmentId equals depo.Id
                         select new StudentDto
                         {
                             Id = student.Id,
                             FirstName = student.FirstName,
                             LastName = student.LastName,
                             PersonalCode = student.PersonalCode,
                             DepartmentName = depo.Name,
                             DepartmenCity = depo.City,
                         };
            return result.ToList<IStudentDto>( );
        }

        public List<IStudentDto> GetStudents (string departmentNameSubstring)
        {
            var result = from student in _repository.Students.GetAll( )
                         join depo in _repository.Departments.GetAll( ) on student.DepartmentId equals depo.Id
                         where depo.Name.ToLower( ).Contains(departmentNameSubstring.ToLower( ))
                         select new StudentDto
                         {
                             Id = student.Id,
                             FirstName = student.FirstName,
                             LastName = student.LastName,
                             PersonalCode = student.PersonalCode,
                             DepartmentName = depo.Name,
                             DepartmenCity = depo.City,
                         };
            return result.ToList<IStudentDto>( );
        }

        public List<IStudentDto> GetStudents (string firstNameSubstring, string lastNameSubstring)
        {
            var result = from student in _repository.Students.GetAll( )
                         join depo in _repository.Departments.GetAll( ) on student.DepartmentId equals depo.Id
                         where student.FirstName.ToLower( ).Contains(firstNameSubstring.ToLower( ))
                               && student.LastName.ToLower( ).Contains(lastNameSubstring.ToLower( ))
                         select new StudentDto
                         {
                             Id = student.Id,
                             FirstName = student.FirstName,
                             LastName = student.LastName,
                             PersonalCode = student.PersonalCode,
                             DepartmentName = depo.Name,
                             DepartmenCity = depo.City,
                         };
            return result.ToList<IStudentDto>( );
        }

        public List<IStudentDto> GetStudentsByDepartmentId (int departmentId)
        {
            var result = from student in _repository.Students.GetAll( )
                         join depo in _repository.Departments.GetAll( ) on student.DepartmentId equals depo.Id
                         where depo.Id.Equals(departmentId)
                         select new StudentDto
                         {
                             Id = student.Id,
                             FirstName = student.FirstName,
                             LastName = student.LastName,
                             PersonalCode = student.PersonalCode,
                             DepartmentName = depo.Name,
                             DepartmenCity = depo.City,
                         };
            return result.ToList<IStudentDto>( );
        }

        private IQueryable<IDepartmentDto> GetAllDepartments ( )
        {
            return
             _repository
             .Departments
             .GetAll( )
             .Select(d =>
                 new DepartmentDto( )
                 {
                     Id = d.Id,
                     Name = d.Name,
                     City = d.City
                 });
        }


    }
}
