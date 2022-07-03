using StudentInformationSystem.DAL.DataProviders.Dapper;
using StudentInformationSystem.DAL.DataProviders.Dapper.Repositories;
using StudentInformationSystem.DAL.Interfaces;
namespace StudentInformationSystem.DAL.DataProviders
{
    public class SqlDataProviderDapper : IDataProvider
    {

        private readonly RepositoryDbContext _context;
        private IDepartmentRepository _departmentRepository = null!;
        private ILectureRepository _lectureRepository = null!;
        private IStudentRepository _studentRepository = null!;

        public SqlDataProviderDapper ( )
        {
            _context = new(inTestMode: false);
        }

        public SqlDataProviderDapper (bool inTestMode)
        {
            _context = new(inTestMode);
        }

        public IDepartmentRepository Departments
        {
            get
            {
                if (_departmentRepository == null) _departmentRepository = new DepartmentsRepository(_context);

                return _departmentRepository;
            }
        }

        public ILectureRepository Lectures
        {
            get
            {
                if (_lectureRepository == null) _lectureRepository = new LecturesRepository(_context);

                return _lectureRepository;
            }
        }

        public IStudentRepository Students
        {
            get
            {
                if (_studentRepository == null) _studentRepository = new StudentRepository(_context);
                return _studentRepository;
            }
        }

        public void Save ( )
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
                    _context.Dispose( );
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
