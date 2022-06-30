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
            return _context.Departments;
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
            return _context.Departments.Single(i => i.Id == id);
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
