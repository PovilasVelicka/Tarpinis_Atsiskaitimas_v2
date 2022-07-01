using StudentInformationSystem.BLL.Models;
using StudentInformationSystem.DAL;
using StudentInformationSystem.DAL.Models;

namespace StudentInformationSystem.BLL
{
    public class Controller : IController
    {
        private readonly UnitOfWork _controller;
        public Controller ( )
        {
            _controller = new UnitOfWork( );
        }

        public void AddDepartment (IDepartmentDto department)
        {
            var exists = _controller.Departments.GetAllByName(department.Name).Any( );
            if (!exists)
            {
                var departmentEntity = new Department(department.Name, department.City);
                _controller.Departments.AddOrUpdate(departmentEntity);
            }
        }

        public void AddLecture (ILectureDto lecture)
        {
            var exists = _controller.Lectures.GetAllByName(lecture.Title).Any( );
            if (!exists)
            {
                _controller.Lectures.AddOrUpdate(new Lecture(lecture.Title));
            }
        }

        public void AddLectureTo (ILectureDto lecture, IDepartmentDto department)
        {
            AddLecture(lecture);
            var lectureEntity =(Lecture)_controller.Lectures.GetAllByName(lecture.Title).First( );
            var depo = (Department)_controller.Departments.GetById(department.Id);
            if(!depo.Lecture.Where(l=> l.Name == lecture.Title).Any( ))
            {
                depo.Lecture.Add(lectureEntity);
                _controller.Departments.AddOrUpdate(depo);
            }
        }

        public void AddStudent (IStudentDto student)
        {
            var studenNotExists = _controller.Students.GetByPersonalCode(student.PersonalCode) == null;
            if(studenNotExists)
            {
                var studentEntity = new Student(student.FirstName, student.LastName, student.PersonalCode);
                _controller.Students.AddOrUpdate(student);
            }
        }

        public void AddStudentTo (IStudentDto student, IDepartmentDto studentDto)
        {
            throw new NotImplementedException( );
        }

        public void TransverStudetnTo (IStudentDto student, IDepartmentDto department)
        {
            throw new NotImplementedException( );
        }
    }
}
