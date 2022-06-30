using StudentInformationSystem.CL.Interfaces;

namespace StudentInformationSystem.DAL.Models
{
    internal class Lecture : ILectureEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<IDepartmentEntity> Departments { get; set; } = null!;

        private Lecture() { }

        public Lecture(string name)
        {
            Name = name;
            Departments = new List<IDepartmentEntity>();
        }
    }
}
