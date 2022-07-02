
using StudentInformationSystem.BLL;
using StudentInformationSystem.CL.Interfaces;
using StudentInformationSystem.DAL.Models;

namespace BLL_tests
{
    public class Tests
    {
        readonly string[] lectureNames = new string[]
            {
                "Duomenu bazes",
                "DBMS",
                "Duomenu baziu projektavimas",
                "Entity Framework core",
                "NoSqlDb",
                "Dapper"
            };


        //[Test]
        //public void Department_CreaateCheck_Test()
        //{
            
        //    using (IServiceBLL service = new InvormationService())
        //    {
        //        var depoName = "CodeAcademy Klaipedos filialas";
        //        var depoCity = "Klaipeda";
        //        IDepartmentEntity department = service.Departments.CreateDepartment(depoName, depoCity);


        //        Assert.That(department.Id, Is.GreaterThan(0));

        //        Assert.That(department.Name, Is.EqualTo(depoName));

        //        Assert.That(department.City, Is.EqualTo(depoCity));

        //        //service.Departments.DeleteDepartment(department.Id);
        //    };
        //}

        //[Test]
        //public void Student_CreaateAndAddToDepartment_Test()
        //{
        //    using (IServiceBLL service = new InvormationService())
        //    {

        //        var depoName = "CodeAcademy Kauno filialas";
        //        var depoCity = "Kaunas";
        //        var firstName = "Vardenis";
        //        var lastName = "Pavardenis";
        //        var personalCode = "37501050001";

        //        IDepartmentEntity department = service.Departments.CreateDepartment(depoName, depoCity);
        //        IStudentEntity student = service.Students.CreateStudent(firstName, lastName, personalCode, department.Id);



        //        Assert.That(student.Id, Is.GreaterThan(0));

        //        Assert.That(student.FirstName, Is.EqualTo(firstName));

        //        Assert.That(student.LastName, Is.EqualTo(lastName));

        //        Assert.That(student.PersonalCode, Is.EqualTo(personalCode));

        //        Assert.That(student.DepartmentId, Is.EqualTo(department.Id));

        //        //service.Departments.DeleteDepartment(department.Id);

        //    }
        //}

        //[Test]
        //public void AddStudentToExistDepartment_Test()
        //{
        //    using (IServiceBLL service = new InvormationService())
        //    {
        //        var depoName = "CodeAcademy Klaipedos filialas";
        //        IDepartmentEntity? department = service.Departments.GetByName(depoName).FirstOrDefault();
        //        if (department != null)
        //        {
        //            var firstName = "Petras";
        //            var lastName = "Lakûnas";
        //            var personalCode = "36501050000";

        //            IStudentEntity student = service.Students.CreateStudent(firstName, lastName, personalCode, department.Id);

        //            Assert.That(student.Id, Is.GreaterThan(0));

        //            Assert.That(student.FirstName, Is.EqualTo(firstName));

        //            Assert.That(student.LastName, Is.EqualTo(lastName));

        //            Assert.That(student.PersonalCode, Is.EqualTo(personalCode));

        //            Assert.That(student.DepartmentId, Is.EqualTo(department.Id));

        //        }

        //    };
        //}

        //[Test]
        //public void CreateLectures_Test()
        //{
            
        //    using (IServiceBLL service = new InvormationService())
        //    {
        //        foreach (var lecture in lectureNames)
        //        {
        //            service.Lectures.CreateLectrue(lecture);
        //        }
        //        foreach (var lecture in lectureNames)
        //        {
        //            var lectures = service.Lectures.GetByName(lecture);
        //            Assert.That(lectures, Has.Count.EqualTo(1));
        //        }
        //    }
        //}

        //[Test]
        //public void AssignLecturToDepartment_Test()
        //{
        //    using (IServiceBLL service = new InvormationService())
        //    {
        //        var depoName = "CodeAcademy Klaipedos filialas";
        //        var depart = service.Departments.GetByName(depoName).FirstOrDefault();
        //        var lecture = service.Lectures.GetByName(lectureNames[1]).FirstOrDefault();
        //        if (depart != null && lecture !=null)
        //        {
        //            service.Departments.AddLecture(depart.Id, lecture);

        //            var depo = (Department)service.Departments.GetById(depart.Id);
        //            var lectureCount = depo.Lectures.Where(l => l.Id == lecture.Id).Count();
        //            Assert.That(lectureCount, Is.EqualTo(1));
        //        }                
        //    }
        //}

        //[Test]
        //public void AssignLecturFromDepartmentToStudent_Test()
        //{
        //    using (IServiceBLL service = new InvormationService())
        //    {
        //        var depoName = "CodeAcademy Klaipedos filialas";
        //        var studentPersonalCode = "36501050000";

        //        var depart = service.Departments.GetByName(depoName).FirstOrDefault();
        //        var student = service.Students.GetStudentByPersonalCode(studentPersonalCode);
            
        //        if (depart != null && student  != null)
        //        {
                    
        //            service.Students.MoveToDepartment(student.Id, depart);

        //           //?? service.Students.AddLecturesFromDepartment(student.Id,depart);

        //            var depo = (Department)service.Departments.GetById(depart.Id);
        //            var 
        //            var varStudent = depo.Students.Where(s => s.Id == s.Id).Count();
        //            Assert.That(lectureCount, Is.EqualTo(1));
        //        }
        //    }
        //}
    }
}