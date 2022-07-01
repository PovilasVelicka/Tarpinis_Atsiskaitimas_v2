using StudentInformationSystem.BLL;

var service = new InvormationService();
Defaults(true);



void Defaults(bool create)
{
    if (create)
    {
        AddDepartments();
        AddStudents();
        AddLectures();
        AddLecturesToStudents();
        service.SaveChanges();
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
        var availableDepartments = service.Departments.GetByCity(GetRandomCity());
        foreach (var depo in availableDepartments)
        {
            service.Students.CreateStudent(
                firstName: $"Vardenis {new Random().Next(1000)}",
                lastName: $"Pavardenis {new Random().Next(1000)}",
                personalCode: GetRandomPersonalCode(),
                departmentId: depo.Id);
        }
    }
}

void AddLectures()
{
    for (int i = 0; i < 10; i++)
    {
        var availableDepartments = service.Departments.GetByCity(GetRandomCity());
        var lectureName = $"Paskaita {DateTime.Now.AddDays(new Random().Next(0, 30)).ToShortDateString()} dienos";
        
        foreach (var depo in availableDepartments)        
        {
            var lecture = service.Lectures.CreateLectrue(lectureName);
                   
            service.Departments.AddLecture(depo.Id, lecture);
        }
    }
}

void AddLecturesToStudents()
{
    var students = service.Students.GetStudentByFirstName("VarDen");
    foreach (var student in students)
    {
        var depo = service.Departments.GetById(student.DepartmentId);
        service.Students.AddLecturesFromDepartment(student.Id, depo);
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

string GetRandomPersonalCode()
{
    return 
        $"{new Random().Next(3,10)}" +
        $"{new Random().Next(50,99)}" +
        $"{new Random().Next(1,13)}" +
        $"{new Random().Next(1,28)}" +
        $"{new Random().Next (0,9999).ToString("0000")}";
}
