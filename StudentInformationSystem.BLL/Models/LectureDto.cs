namespace StudentInformationSystem.BLL.Models
{
    public class LectureDto : ILectureDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
