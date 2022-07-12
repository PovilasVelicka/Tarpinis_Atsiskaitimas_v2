using StudentInformationSystem.DAL.DataProviders.Dapper.Repositories;
using StudentInformationSystem.DAL.Interfaces;
using System.Data.SqlClient;
namespace StudentInformationSystem.DAL.DataProviders
{
    public class SqlDataProviderDapper : IDataProvider
    {
        private const string CONNECTION_STRING = @"Server=localhost\SQLEXPRESS;Database=StudentsInfoSystem-prod;Trusted_Connection=True;";
        private readonly SqlConnection _context = null!;
        private DepartmentsRepository _departmentRepository = null!;
        private LecturesRepository _lecturesRepository = null!;
        private StudentRepository _studentRepository = null!;
        public SqlDataProviderDapper (bool inTestMode)
        {
            _context = new SqlConnection(CONNECTION_STRING);
            _context.Open( );
        }

        public IDepartmentRepository Departments
        {
            get
            {
                if (_departmentRepository == null)
                {
                    _departmentRepository = new(_context);
                }

                return _departmentRepository;
            }
        }

        public ILectureRepository Lectures
        {
            get
            {
                if (_lecturesRepository == null)
                {
                    _lecturesRepository = new(_context);
                }

                return _lecturesRepository;
            }
        }

        public IStudentRepository Students
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new(_context);
                }

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
