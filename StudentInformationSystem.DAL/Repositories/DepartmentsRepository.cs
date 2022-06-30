using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Models;
namespace StudentInformationSystem.DAL.Repositories
{
    internal class DepartmentsRepository : IDepartmentRepository
    {
        readonly StudentInfoSystemDbContext _context;
        public DepartmentsRepository()
        {
            _context = new StudentInfoSystemDbContext();
        }
        public void AddOrUpdate(IDepartmentEntity entity)
        {
            var department = (Department)entity;
            //switch (_context.Entry(department).State)
            //{
            //    case EntityState.Detached:
            //        _context.Departments.Update(department);
            //        _context.Entry(entity).State = EntityState.Added;
            //        break;
            //    case EntityState.Unchanged:
            //        _context.Departments.Append(department);
            //        break;
            //    case EntityState.Modified:
            //        _context.Departments.Update(department);
            //        break;
            //    case EntityState.Added:
            //        _context.Departments.Add(department);
            //        break;
            //}
            //_context.Departments.Append(department);

            if(department.Id==0)
                _context.Departments.Add(department);
            else
                _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void Remove(IDepartmentEntity entity)
        {
            var department = (Department)entity;
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public IQueryable<IDepartmentEntity> GetAll()
        {
            return _context.Departments;// .AsNoTracking();
        }

        public IQueryable<IDepartmentEntity> GetAllByCity(string city)
        {
            return GetAll().Where(x => x.City.ToLower().Contains(city.ToLower()));
        }

        public IQueryable<IDepartmentEntity> GetAllByNameSubstring(string name)
        {
            return GetAll().Where(n => n.Name.ToLower().Contains(name.ToLower()));
        }

        public IDepartmentEntity GetById(int id)
        {
            return _context
                .Departments
                .Include(l=> l.Lecture )
                .Include(l=>l.Students)
                .Single(i => i.Id == id);
        }

        #region Dispose methods
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.SaveChanges();
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
