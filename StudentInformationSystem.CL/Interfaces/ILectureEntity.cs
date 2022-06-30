namespace StudentInformationSystem.CL.Interfaces
{
    public interface ILectureEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        List<IDepartmentEntity> Departments { get; set; }
    }
}
