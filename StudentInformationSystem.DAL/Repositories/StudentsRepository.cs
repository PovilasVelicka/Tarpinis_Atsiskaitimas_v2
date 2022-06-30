﻿using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Models;

namespace StudentInformationSystem.DAL.Repositories
{
    internal class StudentsRepository : IStudentRepository
    {
        private readonly StudentInfoSystemDbContext _context;

        public StudentsRepository()
        {
            _context = new StudentInfoSystemDbContext();
        }

        public void AddOrUpdate(IStudentEntity entity)
        {
            var student = (Student)entity;
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Remove(IStudentEntity student)
        {
            var studentCasted = (Student)student;
            _context.Students.Remove(studentCasted);
            _context.SaveChanges();
        }

        public IQueryable<IStudentEntity> GetAll()
        {
            return _context.Students;
        }

        public IQueryable<IStudentEntity> GetAllByFirstName(string firstName)
        {
            return GetAll().Where(n => n.FirstName.ToLower().Contains(firstName.ToLower()));
        }

        public IQueryable<IStudentEntity> GetAllByLastName(string lastName)
        {
            return GetAll().Where(n => n.LastName.ToLower().Contains(lastName.ToLower()));
        }

        public IStudentEntity GetById(int id)
        {
            return _context.Students.Single(i => i.Id == id);
        }

        public IStudentEntity? GetByPersonalCode(string personalCode)
        {
            return GetAll().FirstOrDefault(p => p.PersonalCode == personalCode);
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