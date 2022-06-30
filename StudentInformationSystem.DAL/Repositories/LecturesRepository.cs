using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Models;
namespace StudentInformationSystem.DAL.Repositories
{
    internal class LecturesRepository : ILectureRepository
    {
        private readonly StudentInfoSystemDbContext _context;

        public LecturesRepository()
        {
            _context = new StudentInfoSystemDbContext();
        }

        public void AddOrUpdate(ILectureEntity entity)
        {
            var lecture = (Lecture)entity;
            _context.Lectures.Update(lecture);
            _context.SaveChanges();
        }

        public void Remove(ILectureEntity entity)
        {
            var lecture = (Lecture)entity;
            _context.Lectures.Remove(lecture);
            _context.SaveChanges();
        }

        public ILectureEntity GetById(int id)
        {
            return _context.Lectures.AsNoTracking().Single(i => i.Id == id);
        }

        public IQueryable<ILectureEntity> GetByNameSubstring(string name)
        {
            return GetAll().Where(n => n.Name.ToLower().Contains(name.ToLower()));
        }

        public IQueryable<ILectureEntity> GetAll()
        {
            return _context.Lectures.AsNoTracking();
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
