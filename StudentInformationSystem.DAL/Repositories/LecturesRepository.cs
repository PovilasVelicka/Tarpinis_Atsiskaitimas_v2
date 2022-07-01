using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Models;
namespace StudentInformationSystem.DAL.Repositories
{
    internal class LecturesRepository : ILectureRepository
    {
        private readonly StudentInfoSystemDbContext _context;

        public LecturesRepository(StudentInfoSystemDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate(ILectureEntity entity)
        {
            var lecture = (Lecture)entity;
            var status = _context.Entry(entity).State;
            if(lecture.Id == 0)
                _context.Lectures.Attach(lecture);
            else
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
            return _context
                .Lectures
                .Include(x=>x.Departments)
                .Include(s=>s.Students)
                .Single(i => i.Id == id);
        }

        public IQueryable<ILectureEntity> GetByNameSubstring(string name)
        {
            return GetAll().Where(n => n.Name.ToLower().Contains(name.ToLower()));
        }

        public IQueryable<ILectureEntity> GetAll()
        {
            return _context.Lectures.AsNoTracking();
        }
        //#region Dispose methods
        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {                    
        //            _context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //#endregion
    }
}
