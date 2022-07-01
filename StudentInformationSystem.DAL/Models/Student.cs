using StudentInformationSystem.CL.Interfaces;
namespace StudentInformationSystem.DAL.Models
{
    public class Student : IStudentEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PersonalCode { get; set; } = null!;


        public List<Lecture> Lectures { get; set; } = null!;

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; } = null!;

        private Student ( ) { }

        public Student (string firstName, string lastName, string personalCode)
        {
            // DepartmentId = departmentId;
            FirstName = firstName;
            LastName = lastName;
            PersonalCode = personalCode;
            Lectures = new List<Lecture> ( );
        }
    }
}

