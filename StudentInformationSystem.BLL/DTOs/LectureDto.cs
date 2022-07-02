namespace StudentInformationSystem.BLL.DTOs
{
    internal sealed class LectureDto : ILectureDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
