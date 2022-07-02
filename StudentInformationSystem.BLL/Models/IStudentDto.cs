﻿namespace StudentInformationSystem.BLL.Models
{
    public interface IStudentDto
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string PersonalCode { get; }
        string DepartmentName { get; }
        string DepartmenCity { get; }
    }
}
