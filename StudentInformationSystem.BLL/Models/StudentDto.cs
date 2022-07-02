namespace StudentInformationSystem.BLL.Models
{
    internal sealed class StudentDto : IStudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PersonalCode { get; set; } = null!;
        public string DepartmentName { get; set; } = null!;
        public string DepartmenCity { get; set; } = null!;
    }
}
