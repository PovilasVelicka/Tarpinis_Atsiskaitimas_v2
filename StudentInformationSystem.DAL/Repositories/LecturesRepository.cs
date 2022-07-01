using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Models;
namespace StudentInformationSystem.DAL.Repositories
{
    internal class LecturesRepository : ILectureRepository
    {
        private readonly RepositoryDbContext _context;

        public LecturesRepository (RepositoryDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate (ILectureEntity entity)
        {
            _context.Lectures.Update((Lecture)entity);
            _context.SaveChanges( );
        }

        public void Remove (ILectureEntity entity)
        {
            _context.Lectures.Remove((Lecture)entity;);
            _context.SaveChanges( );
        }

        public ILectureEntity GetById (int id)
        {
            return _context
                .Lectures
                .Include(x => x.Departments)
                .Include(s => s.Students)
                .Single(i => i.Id == id);
        }

        public IQueryable<ILectureEntity> GetAll ( )
        {
            return _context.Lectures.AsNoTracking( );
        }

        public IQueryable<ILectureEntity> GetAllByName (string nameSubstring)
        {
            return GetAll( )
                .Where(n => n.Name.ToLower( ).Contains(nameSubstring.ToLower( )));
        }
    }
}
