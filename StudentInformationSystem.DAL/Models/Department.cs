using StudentInformationSystem.CL.Interfaces;

namespace StudentInformationSystem.DAL.Models
{
    public class Department : IDepartmentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;

        public virtual List<Student> Students { get; set; } = null!;
        public virtual List<Lecture> Lectures { get; set; } = null!;
        private Department() { }

        public Department(string name, string city)
        {
            Name = name;
            City = city;
            Students = new List<Student>();
            Lectures = new List<Lecture>();
        }
    }
}
