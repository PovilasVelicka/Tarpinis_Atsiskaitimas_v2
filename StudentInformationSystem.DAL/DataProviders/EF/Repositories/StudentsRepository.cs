using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DAL.DataProviders.EF;
using StudentInformationSystem.DAL.Interfaces;
using StudentInformationSystem.DAL.Models;
namespace StudentInformationSystem.DAL.Repositories
{
    internal class StudentsRepository : IStudentRepository
    {
        private readonly RepositoryDbContext _context;

        public StudentsRepository (RepositoryDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate (IStudentEntity entity)
        {
            _context.Students.Update((Student)entity);
            _context.SaveChanges( );
        }

        public void Remove (IStudentEntity student)
        {
            _context.Students.Remove((Student)student);
            _context.SaveChanges( );
        }

        public IQueryable<IStudentEntity> GetAll ( )
        {
            return _context.Students.AsNoTracking( );
        }

        public IQueryable<IStudentEntity> GetAllByFirstName (string firstNameSubstring)
        {
            return GetAll( )
                .Where(n => n.FirstName.ToLower( ).Contains(firstNameSubstring.ToLower( )));
        }

        public IQueryable<IStudentEntity> GetAllByLastName (string lastNameSubstring)
        {
            return GetAll( )
                .Where(n => n.LastName.ToLower( ).Contains(lastNameSubstring.ToLower( )));
        }

        public IStudentEntity GetById (int id)
        {
            return _context
                .Students
                .Include(x => x.Lectures)
                .Include(d => d.Department)
                .Single(i => i.Id == id);
        }

        public IStudentEntity? GetByPersonalCode (string personalCode)
        {
            return _context
                .Students
                .Include(x => x.Lectures)
                .Include(d => d.Department)
                .FirstOrDefault(p => p.PersonalCode == personalCode);
        }
    }
}
