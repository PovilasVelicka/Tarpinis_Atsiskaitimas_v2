using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("StudentInformationSystem.BLL")]

namespace StudentInformationSystem.DAL.Models
{
    [Table("Lectures", Schema = "InfoSystem")]
    [Index("Title", Name = "UX_Lecture_Title", IsUnique = true)]
    internal class Lecture : ILectureEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = null!;

        public virtual List<Department> Departments { get; set; } = null!;
        public virtual List<Student> Students { get; set; } = null!;
        private Lecture ( ) { }

        public Lecture (string title)
        {
            Title = title;
            Departments = new List<Department>( );
            Students = new List<Student>( );
        }
    }
}
