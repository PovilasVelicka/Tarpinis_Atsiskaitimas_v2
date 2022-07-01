using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Models;

namespace StudentInformationSystem.DAL.Repositories
{
    internal class StudentsRepository : IStudentRepository
    {
        private readonly StudentInfoSystemDbContext _context;

        public StudentsRepository (StudentInfoSystemDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate (IStudentEntity entity)
        {
            var student = (Student)entity;
            _context.Students.Update (student);
            _context.SaveChanges ( );
        }

        public void Remove (IStudentEntity student)
        {
            var studentCasted = (Student)student;
            _context.Students.Remove (studentCasted);
            _context.SaveChanges ( );
        }

        public IQueryable<IStudentEntity> GetAll ( )
        {
            return _context.Students.AsNoTracking ( );
        }

        public IQueryable<IStudentEntity> GetAllByFirstName (string firstName)
        {
            return GetAll ( ).Where (n => n.FirstName.ToLower ( ).Contains (firstName.ToLower ( )));
        }

        public IQueryable<IStudentEntity> GetAllByLastName (string lastName)
        {
            return GetAll ( ).Where (n => n.LastName.ToLower ( ).Contains (lastName.ToLower ( )));
        }

        public IStudentEntity GetById (int id)
        {
            return _context
                .Students
                .Include (x => x.Lectures)
                .Include (d => d.Department)
                .Single (i => i.Id == id);
        }

        public IStudentEntity? GetByPersonalCode (string personalCode)
        {
            return GetAll ( ).FirstOrDefault (p => p.PersonalCode == personalCode);
        }
    }
}
