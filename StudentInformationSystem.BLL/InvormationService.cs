using StudentInformationSystem.BLL.Models;
using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL;
namespace StudentInformationSystem.BLL
{
    public class InvormationService : IServiceBLL
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentBLL _studentBLL;
        private readonly IDepartmentBLL _departmentBLL;
        private readonly ILectureBLL _lectureBLL;

        public IStudentBLL Students { get => _studentBLL; }
        public IDepartmentBLL Departments { get => _departmentBLL; }
        public ILectureBLL Lectures { get => _lectureBLL; }

        public InvormationService()
        {
            _unitOfWork = new UnitOfWork();
            _lectureBLL = new LectureBLL(_unitOfWork.Lectures);
            _departmentBLL = new DepartmentBLL(_unitOfWork.Departments);
            _studentBLL = new StudentBLL(_unitOfWork.Students);
        }

        public void SaveChanges()
        {
            _unitOfWork.Save();
        }

        



        #region Dispose methods
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
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
