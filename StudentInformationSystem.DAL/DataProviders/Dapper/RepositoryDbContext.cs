using StudentInformationSystem.DAL.Models;

namespace StudentInformationSystem.DAL.DataProviders.Dapper
{
    internal class RepositoryDbContext:IDisposable
    {
        private readonly bool _inMemory;

        public IQueryable<Student> Students { get; set; } = null!;
        public IQueryable<Department> Departments { get; set; } = null!;
        public IQueryable<Lecture> Lectures { get; set; } = null!;


        public RepositoryDbContext ( )
        {
            _inMemory = false;
        }

        public RepositoryDbContext (bool inTestMode)
        {
            _inMemory = inTestMode;
        }
        public void SaveChanges ( )
        {

        }
        #region Dispose methods
        private bool disposed = false;

        protected virtual void Dispose (bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    throw new Exception( );
                }
            }
            disposed = true;
        }

        public void Dispose ( )
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
