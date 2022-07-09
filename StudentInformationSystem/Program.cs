using StudentInformationSystem.BLL;

var _controller = new Controller(
    dataprovider: DataProviders.SQLEntityFramework,
    inTestMode: false);


// Mariau, jeigu gali pabandyk atlikti užduoti nežiūrėdamas į kodą
// naudok _controller. man įdomu ar gausis suprasti.

































StartPresentation( );

#region Presentation


void StartPresentation ( )
{
    Thread.Sleep(5000);
    Console.CursorVisible = false;
    PrintNeo( );

    About( );
    Tests( );
    Console.ReadLine( );
    clearMatrix( );
    Console.Clear( );
    Console.ReadLine( );
}

void PrintNeo ( )
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.CursorVisible = false;
    PrintChars("    Wake up, Neo...");
    printCursor(5);
    Console.Clear( );

    PrintChars("    The matrix has You...");
    printCursor(5);
    Console.Clear( );

    PrintChars("    Follow the white rabbit.");
    printCursor(2);
    Console.WriteLine("\n");

    PrintWords("    Knock, knock, Neo.");
    Thread.Sleep(3000);
    Console.WriteLine( );

}

void About ( )
{
    Console.Clear( );
    Console.ForegroundColor = ConsoleColor.White;
    PrintChars("                  Tema: DB tarpinis atsiskaitymas");
    PrintChars("             Studentas: Povilas Velička");
    PrintChars($"     Atsiskaitymo data: {DateTime.Now.ToLongDateString( )}");
    printCursor(4);
    Console.WriteLine("\n");
    Console.ForegroundColor = ConsoleColor.Green;
    PrintChars("    Šiam darbui atlikti, naudojau Entity FrameWork Core, Model first metodas. Programa suskaidyta į 4 sluoksnius:");
    Console.ForegroundColor = ConsoleColor.White;
    PrintChars("1. DAL - Data Access Layer");
    PrintChars("2. BLL - Business Logic Layer");
    PrintChars("3. UI - User Interface");
    PrintChars("4. TESTS - test layer");
    printCursor(6);

    Console.WriteLine("\n\n");
    Console.ForegroundColor = ConsoleColor.Green;
    PrintChars("    Dabar ataliksiu kelėtą testų įrašant ir patikrinant įvestus duomenys");
    Console.WriteLine( );
    printCursor(2);
    Console.ForegroundColor = ConsoleColor.White;

}

void Tests ( )
{

    AddDepartments( );
    AddLectures( );
    AddStudents( );
    AddLecturesToDepartment( );
    AddStudentToDepartment( );
    AddLectureToDepartmentWithStudents( );
    MoveStudetnToDepartment( );
}

void AddDepartments ( )
{
    Console.ForegroundColor = ConsoleColor.Green;
    PrintChars("    TEST - Naujų padalinių įvedimas:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine( );
    PrintChars("1. Naudojant komandą CreateDepartment, įvesiu du naujus padalinius");
    Console.WriteLine( );
    Console.WriteLine(String.Format("    Id: {0,-3} Name: {1,-30} City: {2} ", "***", "CodeAcademy Klaipėdos filialas", "Klaipėda"));
    Console.WriteLine(String.Format("    Id: {0,-3} Name: {1,-30} City: {2} ", "***", "CodeAcademy Kauno filialas", "Kaunas"));
    printCursor(4);
    _controller.CreateDepartment("CodeAcademy Klaipėdos filialas", "Klaipėda");
    _controller.CreateDepartment("CodeAcademy Kauno filialas", "Kaunas");
    Console.WriteLine( );

    PrintChars("2. Naudojant komandą GetDepartments atliksiu įvestu duomenų patikrinimą");

    Console.WriteLine( );
    foreach (var item in _controller.GetDepartments( ))
    {
        Console.WriteLine(String.Format("    Id: {0,-3} Name: {1,-30} City: {2} ", item.Id, item.Name, item.City));
    }
    Console.ForegroundColor = ConsoleColor.White;
    printCursor(4);
}

void AddLectures ( )
{
    string[ ] lectureNames = new string[ ]
         {
                "Duomenu bazes",
                "DBMS",
                "Duomenu baziu projektavimas",
                "Entity Framework core",
                "NoSqlDb",
                "Dapper"
         };
    Console.ForegroundColor = ConsoleColor.Green;
    PrintChars("    TEST - Naujų paskaitų įvedimas:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine( );
    PrintChars("1. Naudojant komandą CreateLectures, įvesiu paskaitas:");
    Console.WriteLine( );
    foreach (var item in lectureNames)
    {
        Console.WriteLine(String.Format("    Id: {0,-3} Title: {1,-30}", "***", item));
        _controller.CreateLectrue(item);
    }
    printCursor(4);
    PrintChars("2. Naudojant komandą GetLectures atliksiu įvestu duomenų patikrinimą");

    Console.WriteLine( );
    foreach (var item in _controller.GetLectures( ))
    {
        Console.WriteLine(String.Format("    Id: {0,-3} Title: {1,-30}", item.Id, item.Title));
    }
    Console.ForegroundColor = ConsoleColor.White;
    printCursor(4);
}

void AddStudents ( )
{
    Console.ForegroundColor = ConsoleColor.Green;
    PrintChars("    TEST - Naujų studentų įvedimas:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine( );
    PrintChars("1. Naudojant komandą CreateStudent, įvesiu 7 studentus:");
    Console.WriteLine( );
    for (int i = 1; i <= 7; i++)
    {
        Console.WriteLine(String.Format("    Id: {0,-3} Vardas: {1,-20} Pavardė: {2,-20} A/K: {3}", "***", $"Vardas{i}", $"Pavardė{i}", $"3000000000{i}"));
        _controller.CreateStudent($"Vardas{i}", $"Pavardė{i}", $"3000000000{i}");
    }
    Console.WriteLine( );
    printCursor(4);
    PrintChars("2. Naudojant komandą GetStudents atliksiu įvestu duomenų patikrinimą");

    Console.WriteLine( );
    foreach (var item in _controller.GetStudents( ))
    {
        Console.WriteLine(String.Format("    Id: {0,-3} Vardas: {1,-20} Pavardė: {2,-20} A/K: {3}", item.Id, item.FirstName, item.LastName, item.PersonalCode));
    }
    Console.ForegroundColor = ConsoleColor.White;
    printCursor(4);
}

void AddLecturesToDepartment ( )
{
    Console.ForegroundColor = ConsoleColor.Green;
    PrintChars("    TEST - Esamų paskaitų priskirimas departmentui:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine( );
    PrintChars("1. Sukurtos paskaitos nepriklauso nei vinam departmentui, todėl naudojant komandą AddLectureTo, ");
    PrintChars("   priskirsiu po trys paskaitas kiekvienam departmentui, ");
    PrintChars("   o pirmą pasiakitą įvesiu abiems departmentams:");
    Console.WriteLine( );

    var departments = _controller.GetDepartments( );
    var lectures = _controller.GetLectures( );
    for (int i = 0; i < lectures.Count; i++)
    {
        if (i == 0) _controller.AddLectureTo(lectures[i], departments[1]);
        if (i < 3)
            _controller.AddLectureTo(lectures[i], departments[0]);
        else
            _controller.AddLectureTo(lectures[i], departments[1]);
    }
    printCursor(4);

    PrintChars("2. Naudojant komandą GetLecturesByDepartmentId atliksiu įvestu duomenų patikrinimą");
    Console.WriteLine( );

    foreach (var depo in _controller.GetDepartments( ))
    {
        Console.WriteLine(String.Format("    Id: {0,-3} Name: {1,-30} City: {2} ", depo.Id, depo.Name, depo.City));
        foreach (var lecture in _controller.GetLecturesByDepartmentId(depo.Id))
        {
            Console.WriteLine(String.Format("    ----Id: {0,-3} Title: {1,-30}", lecture.Id, lecture.Title));
        }
    }

    Console.ForegroundColor = ConsoleColor.White;
    printCursor(4);
}

void AddStudentToDepartment ( )
{
    Console.ForegroundColor = ConsoleColor.Green;
    PrintChars("    TEST - Esamų studentų priskirimas departmentui:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine( );
    PrintChars("1. Naudojant komanda AddStudentTo įtrauksiu po trys studentus kiekvienam departmentui:");
    Console.WriteLine( );

    var departments = _controller.GetDepartments( );
    var studet = _controller.GetStudents( );
    for (int i = 0; i < studet.Count - 1; i++)
    {
        if (i < 3)
            _controller.AddStudentTo(studet[i], departments[0]);
        else
            _controller.AddStudentTo(studet[i], departments[1]);
    }
    printCursor(4);

    PrintChars("2. Naudojant komandą GetStudentsByDepartmentId atliksiu priskirtu studentų patikrinimą");
    Console.WriteLine( );
    foreach (var depo in _controller.GetDepartments( ))
    {
        Console.WriteLine(String.Format("    Id: {0,-3} Name: {1,-30} City: {2} ", depo.Id, depo.Name, depo.City));
        foreach (var student in _controller.GetStudentsByDepartmentId(depo.Id))
        {
            Console.WriteLine(String.Format("    ----Id: {0,-3} Vardas: {1,-20} Pavardė: {2,-20} A/K: {3}", student.Id, student.FirstName, student.LastName, student.PersonalCode));
        }
    }

    Console.ForegroundColor = ConsoleColor.White;
    printCursor(4);

    PrintChars("3. O dabar, naudojan GetLecturesByStudentId, patikrinsiu ar prisiskirė studentams paskaitos pagal departmentą;");
    Console.WriteLine( );
    foreach (var student in _controller.GetStudents( ))
    {
        Console.WriteLine(String.Format("    Id: {0,-3} Vardas: {1,-20} Pavardė: {2,-20} A/K: {3}", student.Id, student.FirstName, student.LastName, student.PersonalCode));
        foreach (var lecture in _controller.GetLecturesByStudentId(student.Id))
        {
            Console.WriteLine(String.Format("    ----Id: {0,-3} Title: {1,-30}", lecture.Id, lecture.Title));
        }
    }

    Console.ForegroundColor = ConsoleColor.White;
    printCursor(4);

}

void AddLectureToDepartmentWithStudents ( )
{
    Console.ForegroundColor = ConsoleColor.Green;
    PrintChars("    TEST - Esamų paskaitų priskirimas departmentui, kur jau yra studentų:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine( );

    PrintChars("1. Naudojant komandą CreateLectures, įvesiu paskaitą, Programuotojų darbas Lietuvoje:");
    Console.WriteLine( );

    var lecture = _controller.CreateLectrue("Programuotojų darbas Lietuvoje");
    Console.WriteLine( );
    PrintChars("Paskaita įvesta");
    printCursor(4);
    Console.WriteLine( );
    PrintChars("2. Naudojant komandą AddLectureTo įtrauksiu paskaitą į padalinį su ID = 1:");
    var depo = _controller.GetDepartmentById(1);

    _controller.AddLectureTo(lecture, depo);
    Console.WriteLine( );
    PrintChars($"Paskaita įtraukta į padalinį pavadinimas: {depo.Name}");
    Console.WriteLine( );
    printCursor(4);
    PrintChars("3. O dabar patikrinsiu ar paskaita prisidėjo studentams esanteims padalinyje su ID = 1:");
    var depoStudents = _controller.GetStudentsByDepartmentId(depo.Id);
    Console.WriteLine( );
    foreach (var studentItem in depoStudents)
    {
        Console.WriteLine(String.Format("    Id: {0,-3} Vardas: {1,-20} Pavardė: {2,-20} A/K: {3}", studentItem.Id, studentItem.FirstName, studentItem.LastName, studentItem.PersonalCode));
        var studentLectures = _controller.GetLecturesByStudentId(studentItem.Id);
        foreach (var lectureItem in studentLectures)
        {
            Console.WriteLine(String.Format("    ----Id: {0,-3} Title: {1,-30}", lectureItem.Id, lectureItem.Title));
        }
    }
    printCursor(4);
}

void MoveStudetnToDepartment ( )
{
    Console.ForegroundColor = ConsoleColor.Green;
    PrintChars("    TEST - Perkelti studentą į kitą padalinį:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine( );

    PrintChars("1. O dabar perkeliu studenta SU ID 1 į padalinį su ID 2:");
    Console.WriteLine( );
    var student = _controller.GetStudentById(1);
    var depo = _controller.GetDepartmentById(2);
    Console.WriteLine( );
    PrintChars($"Studentas {student.FirstName}, a/k {student.PersonalCode}, perkeltas į padalinį {depo.Name}");
    _controller.AddStudentTo(student, depo);
    Console.WriteLine( );
    PrintChars("2. Tikrinam ar studentui prisiskyrė paskaitos:");
    Console.WriteLine( );
    foreach (var lectur in _controller.GetLecturesByStudentId(student.Id))
    {
        Console.WriteLine(String.Format("    Id: {0,-3} Title: {1,-30}", lectur.Id, lectur.Title));
    }
}

void PrintChars (string text)
{
    Console.WriteLine( );
    foreach (var nextChar in text.ToCharArray( ))
    {
        Console.Write(nextChar);
        Thread.Sleep(1);
    }
}

void PrintWords (string text)
{
    Console.WriteLine( );
    foreach (var word in text.Split(new char[ ] { ' ' }))
    {
        Console.Write(word + " ");
        Thread.Sleep(250);
    }
}

void printCursor (int count)
{
    var cursorSimbol = " #";
    var curPosition = Console.GetCursorPosition( );

    for (int i = 0; i < count; i++)
    {
        Console.SetCursorPosition(curPosition.Left, curPosition.Top);
        Console.Write(cursorSimbol);
        Thread.Sleep(500);
        Console.SetCursorPosition(curPosition.Left, curPosition.Top);
        Console.Write(new string(' ', cursorSimbol.Length));
        Thread.Sleep(500);
    }
    Console.SetCursorPosition(curPosition.Left, curPosition.Top);
    Console.Write(new string(' ', cursorSimbol.Length));

}

void clearMatrix ( )
{
    var width = Console.WindowWidth;
    var height = Console.WindowHeight;
    var matrica = width * height;
    bool[ , ] temp = new bool[width, height];

    for (int h = 0; h < height; h++)
    {
        for (int w = 0; w < width; w++)
        {
            temp[w, h] = false;
        }
    }
    for (int i = 0; i < matrica; i++)
    {
        int w;// = new Random( ).Next(0, width);
        int h;// = new Random( ).Next(0, height);
        do
        {
            w = new Random( ).Next(0, width);
            h = new Random( ).Next(0, height);
        } while (temp[w, h] == true);
        temp[w, h] = true;

        Console.SetCursorPosition(w, h);
        Console.Write(' ');
    }
}
#endregion
































