using StudentInformationSystem.BLL;

var service = new InvormationService();
Defaults(true);

service.Departments.CreateDepartment("CodeAcademy Klaipedos filialas", "Klaipeda");
var department = service.Departments.GetByName("CodeAcademy Klaipedos filialas").First();

service.Lectures.CreateLectrue("Dapper");
var lecture = service.Lectures.GetByName("Dapper").First();

service.Departments.AddLecture(department.Id, lecture);

service.Students.CreateStudent("Povilas", "Velicka", "37501050000", department);


void Defaults(bool create)
{
    if (create)
    {
        AddDepartments();
        AddStudents();
        AddLectures();
        AddLecturesToStudents();
    }
}

void AddDepartments()
{
    for (int i = 1; i <= 10; i++)
    {
        service.Departments.CreateDepartment(
            $"Mokyklos departmentas nr: {i}",
            GetRandomCity());
    }
}

void AddStudents()
{
    for (int i = 0; i < 10; i++)
    {
        var availableDepartments = service.Departments.GetByName(GetRandomCity());
        foreach (var depo in availableDepartments)
        {
            service.Students.CreateStudent(
                firstName: $"Vardenis {new Random().Next(1000)}",
                lastName: $"Pavardenis {new Random().Next(1000)}",
                personalCode: DateTime.Now.ToString("yyyyMMddhh0"),
                department: depo);
        }
    }
}

void AddLectures()
{
    for (int i = 0; i < 10; i++)
    {
        var availableDepartments = service.Departments.GetByName(GetRandomCity());
        foreach (var depo in availableDepartments)
        {
            service.Lectures.CreateLectrue(
                $"Paskaita {DateTime.Now.AddDays(new Random().Next(0, 30)).ToShortDateString()} dienos;");
        }
    }
}

void AddLecturesToStudents()
{
    var students = service.Students.GetStudentByFirstName("VarDen");
    foreach (var student in students)
    {
         service.Students.AddLecturesFromDepartment(student.Id,student.)
    }

    
}
string GetRandomCity()
{
    string[] cities = new string[]
    {
            "Vilnius", "Kaunas",
            "Klaipėda", "Šiauliai",
            "Panevėžys", "Alytus",
            "Marijampolė", "Mažeikiai"
    };

    return cities[new Random().Next(0, cities.Count())];
}
