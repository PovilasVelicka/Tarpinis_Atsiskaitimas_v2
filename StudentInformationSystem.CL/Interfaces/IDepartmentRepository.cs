using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.CL.Interfaces
{
    public interface IDepartmentRepository
    {
        IDepartmentEntity GetById(int id);
        IQueryable<IDepartmentEntity> GetAll();
        IQueryable<IDepartmentEntity> GetAllByNameSubstring(string nameSubstring);
        IQueryable<IDepartmentEntity> GetAllByCity(string city);
        void AddOrUpdate(IDepartmentEntity entity);
        void Remove(IDepartmentEntity entity);       

    }
}
