using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Repositories;

namespace StudentInformationSystem.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryDbContext context = new ( );
        private IDepartmentRepository _departmentRepository = null!;
        private ILectureRepository _lectureRepository = null!;
        private IStudentRepository _studentRepository = null!;

        public IDepartmentRepository Departments
        {
            get
            {
                if (_departmentRepository == null) 
                    _departmentRepository = new DepartmentsRepository (context);

                return _departmentRepository;
            }
        }

        public ILectureRepository Lectures
        {
            get
            {
                if (_lectureRepository == null) 
                    _lectureRepository = new LecturesRepository (context);

                return _lectureRepository;
            }
        }

        public IStudentRepository Students
        {
            get
            {
                if (_studentRepository == null) 
                    _studentRepository = new StudentsRepository (context);

                return _studentRepository;
            }
        }

        public void Save ( )
        {
            context.SaveChanges ( );
        }

        #region Dispose methods
        private bool disposed = false;

        protected virtual void Dispose (bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose ( );
                }
            }
            this.disposed = true;
        }

        public void Dispose ( )
        {
            Dispose (true);
            GC.SuppressFinalize (this);
        }
        #endregion

    }
}
