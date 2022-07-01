using StudentInformationSystem.CL.Interfaces;

namespace StudentInformationSystem.DAL.Models
{
    public class Lecture : ILectureEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Department> Departments { get; set; } = null!;
        public List<Student> Students { get; set; } = null!;
        private Lecture() { }

        public Lecture(string name)
        {
            Name = name;
            Departments = new List<Department>();
            Students = new List<Student>();
        }
    }
}
