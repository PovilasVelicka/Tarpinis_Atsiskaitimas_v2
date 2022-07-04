using StudentInformationSystem.BLL.DTOs;
using StudentInformationSystem.DAL.DataProviders;
using StudentInformationSystem.DAL.Interfaces;
using StudentInformationSystem.DAL.Models;

namespace StudentInformationSystem.BLL
{
    public enum DataProviders
    {
        SQLEntityFramework,
        SQLDapper,
        MonkyDb
    }
    public class Controller : IController
    {
        private readonly IDataProvider _repository;

        public Controller (DataProviders dataprovider, bool inTestMode = false)
        {
            _repository = dataprovider switch
            {
                DataProviders.SQLEntityFramework => new SqlDataProviderEF(inTestMode),
                DataProviders.SQLDapper => new SqlDataProviderDapper(inTestMode),
                DataProviders.MonkyDb => new SqlDataProviderEF(inTestMode),
                _ => null!,
            };
        }

        public IDepartmentDto CreateDepartment (string departmentName, string city)
        {
            var departmentEntity = _repository
                .Departments
                .GetAllByName(departmentName)
                .Where(c => c.City.ToLower( ).Equals(city.ToLower( )))
                .FirstOrDefault( );

            if (departmentEntity == null)
            {
                departmentEntity = new Department(departmentName, city);
                _repository.Departments.AddOrUpdate(departmentEntity);
            }

            return GetDepartmentById(departmentEntity.Id);
        }

        public ILectureDto CreateLectrue (string title)
        {
            var lecture = _repository.Lectures.GetAllByName(title).FirstOrDefault( );
            if (lecture == null)
            {
                lecture = new Lecture(title);
                _repository.Lectures.AddOrUpdate(lecture);
            }
            return GetLectureById(lecture.Id);
        }

        public void AddLectureTo (ILectureDto lecture, IDepartmentDto department)
        {
            var lectureEntity = (Lecture)_repository.Lectures.GetById(lecture.Id);
            var depo = (Department)_repository.Departments.GetById(department.Id);

            if (!depo.Lectures.Where(l => l.Title == lecture.Title).Any( ))
            {
                depo.Lectures.Add(lectureEntity);
                foreach (var student in depo.Students)
                {
                    var studentHasLectrue = GetLecturesByStudentId(student.Id).Where(l => l.Id == lecture.Id).Any( );
                    if (!studentHasLectrue)
                        student.Lectures.Add(lectureEntity);
                }
                _repository.Save( );
            }

        }

        public IStudentDto CreateStudent (string firstName, string lastName, string personalCode)
        {
            var studentEntity = _repository.Students.GetByPersonalCode(personalCode);
            if (studentEntity == null)
            {
                studentEntity = new Student(firstName, lastName, personalCode);
                _repository.Students.AddOrUpdate(studentEntity);
            }
            return GetStudentById(studentEntity.Id);
        }

        public void AddStudentTo (IStudentDto student, IDepartmentDto department)
        {
            var studentEntity = (Student)_repository.Students.GetById(student.Id);
            var departmentEntity = (Department)_repository.Departments.GetById(department.Id);
            studentEntity.Lectures.Clear( );

            studentEntity.Department = departmentEntity;            
            studentEntity.Lectures.AddRange(departmentEntity.Lectures);
            _repository.Save( );
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
                        Title = l.Title
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
                        Title = l.Title,
                    })
                .ToList<ILectureDto>( );
        }

        public List<IStudentDto> GetStudents ( )
        {
            var result = _repository
                .Students
                .GetAll( )
                .Select(x => (Student)x)
                .Select(x => new StudentDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PersonalCode = x.PersonalCode,
                    DepartmentName = x.Department!.Name,
                    DepartmenCity = x.Department!.City,
                }); ;

            return result.ToList<IStudentDto>( );
        }

        public List<IStudentDto> GetStudents (string departmentNameSubstring)
        {
            var result = from student in _repository.Students.GetAll( )
                         join depo in _repository.Departments.GetAll( ) on student.DepartmentId equals depo.Id
                         where depo.Name.ToLower( ).Contains(departmentNameSubstring.ToLower( ))
                         select new StudentDto( )
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

        public ILectureDto GetLectureById (int id)
        {
            var lecture = _repository.Lectures.GetById(id);
            return new LectureDto
            {
                Id = lecture.Id,
                Title = lecture.Title
            };

        }

        public IDepartmentDto GetDepartmentById (int id)
        {
            var depo = _repository.Departments.GetById(id);
            return new DepartmentDto
            {
                Id = depo.Id,
                Name = depo.Name,
                City = depo.City,
            };
        }

        public IStudentDto GetStudentById (int id)
        {
            IDepartmentDto depo = null!;
            var student = _repository.Students.GetById(id);

            if (student.DepartmentId != null)
                depo = GetDepartmentById(student.DepartmentId ?? 0);

            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                PersonalCode = student.PersonalCode,
                DepartmentName = depo?.Name ?? "",
                DepartmenCity = depo?.City ?? "",
            };
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

        public List<ILectureDto> GetLectures ( )
        {
            return _repository
                .Lectures
                .GetAll( )
                .Select(l => new LectureDto
                {
                    Id = l.Id,
                    Title = l.Title,
                })
                .ToList<ILectureDto>( );
        }

        public List<ILectureDto> GetLectures (string lectureNameSubstring)
        {
            return _repository
            .Lectures
            .GetAll( )
            .Where(l => l.Title.ToLower( ).Equals(lectureNameSubstring.ToLower( )))
            .Select(l => new LectureDto
            {
                Id = l.Id,
                Title = l.Title,
            })
            .ToList<ILectureDto>( );
        }
    }
}
