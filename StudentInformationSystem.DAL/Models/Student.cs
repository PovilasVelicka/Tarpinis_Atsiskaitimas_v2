using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StudentInformationSystem.BLL")]

namespace StudentInformationSystem.DAL.Models
{

    [Table("Students", Schema = "InfoSystem")]
    [Index("PersonalCode", Name = "UX_Students_PersonalCode", IsUnique = true)]
    internal class Student : IStudentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(11)]
        public string PersonalCode { get; set; } = null!;

        public virtual List<Lecture> Lectures { get; set; } = new List<Lecture>( );

        public int? DepartmentId { get; set; } = null!;

        public virtual Department? Department { get; set; } = null!;

        private Student ( ) { }

        public Student (string firstName, string lastName, string personalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalCode = personalCode;         
        }
    }
}

