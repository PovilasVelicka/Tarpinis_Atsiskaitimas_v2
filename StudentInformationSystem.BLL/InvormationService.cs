using StudentInformationSystem.BLL.Models;
using StudentInformationSystem.CL.Interfaces;

namespace StudentInformationSystem.BLL
{
    public class InvormationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentBLL _studentBLL;
        private readonly IDepartmentBLL _departmentBLL;
        private readonly ILectureBLL _lectureBLL;
        public InvormationService()
        {
            throw new NotImplementedException("Need implement UnitOfWork class");
            _unitOfWork = (IUnitOfWork)new object();
            _lectureBLL = new LectureBLL(_unitOfWork.Lectures);
            _departmentBLL = new DepartmentBLL(_unitOfWork.Departments);
            _studentBLL = new StudentBLL(_unitOfWork.Students);
        }


        public IStudentBLL Students { get => _studentBLL; }
        public IDepartmentBLL DepartmentBLL { get => _departmentBLL; }
        public ILectureBLL lectureBLL { get => _lectureBLL; }

    }
}
