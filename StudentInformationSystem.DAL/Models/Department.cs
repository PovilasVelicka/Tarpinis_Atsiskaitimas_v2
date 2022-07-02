using StudentInformationSystem.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
[assembly:InternalsVisibleTo("StudentInformationSystem.BLL")]

namespace StudentInformationSystem.DAL.Models
{
    [Table("Departments",Schema ="InfoSystem")]
    internal class Department : IDepartmentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50)]
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
