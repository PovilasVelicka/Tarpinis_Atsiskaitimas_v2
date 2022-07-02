namespace StudentInformationSystem.DAL.Interfaces
{
    public interface IStudentEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalCode { get; set; }
        public int? DepartmentId { get; set; }

        // List<ILectureEntity> Lectures { get; set; }
        // IDepartmentEntity Department { get; set; }

    }
}
