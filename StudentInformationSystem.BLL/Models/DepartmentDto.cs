namespace StudentInformationSystem.BLL.Models
{
    internal sealed class DepartmentDto : IDepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
