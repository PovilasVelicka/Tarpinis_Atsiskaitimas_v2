namespace StudentInformationSystem.BLL.Models
{
    internal sealed class LectureDto : ILectureDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
