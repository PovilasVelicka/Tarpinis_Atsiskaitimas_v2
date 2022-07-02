namespace StudentInformationSystem.BLL.Models
{
    public interface IStudentDto
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PersonalCode { get; set; }
        string DepartmentName { get; set; }
        string DepartmenCity { get; set; }
    }
}
