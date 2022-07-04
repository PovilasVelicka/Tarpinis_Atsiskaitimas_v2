using StudentInformationSystem.BLL;

namespace BLL_tests
{
    public class Tests
    {
        private readonly Controller _controller;

        readonly string[ ] lectureNames = new string[ ]
            {
                "Duomenu bazes",
                "DBMS",
                "Duomenu baziu projektavimas",
                "Entity Framework core",
                "NoSqlDb",
                "Dapper"
            };

        public Tests ( )
        {
            _controller = new Controller(
            dataprovider: DataProviders.SQLEntityFramework,
            inTestMode: true);

            // Create departments

            var firstDepo = _controller.CreateDepartment("CodeAcademy Klaipedos filialas", "Klaipeda");
            var secondDepo = _controller.CreateDepartment("CodeAcademy Kauno filialas", "Kaunas");
            var thirtDepo = _controller.CreateDepartment("Code Academy Vilnius", "Vilnius");

            // create lessions and add to department

            _controller.AddLectureTo(_controller.CreateLectrue(lectureNames[0]), firstDepo);
            _controller.AddLectureTo(_controller.CreateLectrue(lectureNames[1]), firstDepo);
            _controller.AddLectureTo(_controller.CreateLectrue(lectureNames[2]), secondDepo);
            _controller.AddLectureTo(_controller.CreateLectrue(lectureNames[3]), secondDepo);
            _controller.AddLectureTo(_controller.CreateLectrue(lectureNames[4]), thirtDepo);
            _controller.AddLectureTo(_controller.CreateLectrue(lectureNames[5]), thirtDepo);

            // create students and add to department

            _controller.AddStudentTo(_controller.CreateStudent("Student1", "Department Klaipeda", "30000000001"), firstDepo);
            _controller.AddStudentTo(_controller.CreateStudent("Student2", "Department Klaipeda", "30000000002"), firstDepo);
            _controller.AddStudentTo(_controller.CreateStudent("Student3", "Department Kaunas", "30000000003"), secondDepo);
            _controller.AddStudentTo(_controller.CreateStudent("Student4", "Department Kaunas", "30000000004"), secondDepo);
            _controller.AddStudentTo(_controller.CreateStudent("Student5", "Department Vilnius", "30000000005"), thirtDepo);
            _controller.AddStudentTo(_controller.CreateStudent("Student6", "Department Vilnius", "30000000006"), thirtDepo);

            // create depo without students

            var depoWithoutStudents = _controller.CreateDepartment("Depo Without Students", "Mosedis");

            // create student without depo

            var studentWithoutDepo = _controller.CreateStudent("Student7", "Department WithoutDepo", "30000000007");

            // create leesion without depo

            var lessionWithouDepo = _controller.CreateLectrue("ASP.NET");

            // add student to depo without lecturs

            _controller.AddStudentTo(studentWithoutDepo, depoWithoutStudents);

            // add lectrure to depo without lectures but with student

            _controller.AddLectureTo(lessionWithouDepo, depoWithoutStudents);

            // move studetn to other depo and assing other depo lectures

            _controller.AddStudentTo(_controller.GetStudentsByDepartmentId(firstDepo.Id)[0], secondDepo);

        }

        [Test]
        public void CheckCreatedDepartmentsCount ( )
        {
            var actual = _controller.GetDepartments( ).ToList( );
            Assert.That(actual.Count( ), Is.EqualTo(4));
        }

        [Test]
        public void FirstDepartmentLessionsCount ( )
        {
            var actual = _controller.GetDepartments("CodeAcademy Klaipedos filialas").First( );

            var lectu = _controller.GetLecturesByDepartmentId(actual.Id);

            Assert.That(lectu.Count( ), Is.EqualTo(2));

        }

        [Test]
        public void SecondDepartmentStudentCount ( )
        {
            var actual = _controller.GetDepartments("CodeAcademy Kauno filialas").First( );

            var students = _controller.GetStudentsByDepartmentId(actual.Id);

            Assert.That(students.Count( ), Is.EqualTo(3));
        }

        [Test]
        public void ChecMovedStudentLectures ( )
        {
            var student = _controller.GetStudents("Student1", "Department Klaipeda").First( );
            var lectures = _controller.GetLecturesByStudentId(student.Id).ToList( );
            Assert.IsTrue(lectures.Any(l => l.Title.Equals("Duomenu baziu projektavimas")));
        }
    }
}