using StudentInformationSystem.BLL;
using StudentInformationSystem.CL.Interfaces;

var service = new InvormationService();

service.Departments.CreateDepartment("CodeAcademy Klaipedos filialas", "Klaipeda");
var department = service.Departments.GetByName("CodeAcademy Klaipedos filialas").First();

service.Lectures.CreateLectrue("Dapper");
var lecture = service.Lectures.GetByName("Dapper").First();

service.Departments.AddLecture(department.Id, lecture);


service.Students.CreateStudent("Povilas", "Velicka", "37501050000", department);


