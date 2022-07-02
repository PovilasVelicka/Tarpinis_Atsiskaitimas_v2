using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Models;
namespace StudentInformationSystem.DAL.Repositories
{
    internal class DepartmentsRepository : IDepartmentRepository
    {
        private readonly RepositoryDbContext _context;
        public DepartmentsRepository (RepositoryDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate (IDepartmentEntity entity)
        {
            _context.Departments.Update((Department)entity);
            _context.SaveChanges( );
        }

        public void Remove (IDepartmentEntity entity)
        {
            _context.Departments.Remove((Department)entity);
            _context.SaveChanges( );
        }

        public IQueryable<IDepartmentEntity> GetAll ( )
        {
            return _context.Departments.AsNoTracking( );
        }

        public IQueryable<IDepartmentEntity> GetAllByCity (string city)
        {
            return GetAll( )
                .Where(x => x.City.ToLower( ).Contains(city.ToLower( )));
        }

        public IQueryable<IDepartmentEntity> GetAllByName (string name)
        {
            return GetAll( )
                .Where(n => n.Name.ToLower( ).Contains(name.ToLower( )));
        }

        public IDepartmentEntity GetById (int id)
        {
            return _context
                .Departments
                .Include(l => l.Lectures)
                .Include(l => l.Students)
                .Single(i => i.Id == id);
        }
    }
}
