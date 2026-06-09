
using System.Diagnostics;

//Module-1-Lab-Session1

string? region = null;

string? upperRegion = region?.ToUpper();

Console.WriteLine($"Region(conditional):{upperRegion}");

string displayRegion = region ?? "Unassigned";
Console.WriteLine($"Region (coalesced):{displayRegion}");


region ??= "Addis Ababa";
Console.WriteLine($"Region (assigned):{region}");


string studentName = "Abeba";
string studentId = "STU-001";
int enrollmentCount = 3;
decimal grantAmount = 1999.99m;
DateTime enrolledAt = DateTime.UtcNow;
string? campusRegion = null;

Console.WriteLine($"Student:{studentName} ({studentId})");
Console.WriteLine($"Courses:{enrollmentCount}");
Console.WriteLine($"Grant:{grantAmount:F2}");
Console.WriteLine($"Enrolled:{enrolledAt:yyyy-MM-dd}");
Console.WriteLine($"Campus:{campusRegion ?? "Not assigned"}");

double grantPerStudent = 1999.99;
double totalAllocation = grantPerStudent * 100_000;

Console.WriteLine($"Total allocated(double):{totalAllocation}");

decimal grantPerStudents = 1999.99m;
decimal totalAllocations = grantPerStudents * 100_000;

Console.WriteLine($"Total allocated(decimal):{totalAllocations}");
Console.WriteLine($"Total allocated(formatted):{totalAllocations:F2}");


var enrollment = new EnrollmentRecord("STU-001","CS-401",DateTime.UtcNow);
Console.WriteLine(enrollment);


var corrected = enrollment with { CourseCode="CS-402"};
Console.WriteLine(corrected);

var duplicate = new EnrollmentRecord("STU-001","CS-401",enrollment.EnrolledAt);
Console.WriteLine($"Same data?{enrollment == duplicate}");

var course = new Courses {Code ="CS_401",Title ="Advanced C#",Capacity =30};
Console.WriteLine($"Course:{course.Title}(Capacity: {course.Capacity})");


try
{
    course.Capacity = -5;
}
catch(ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Caught:{ex.Message}");
}

try
{
    course.Title = "";
}
catch(ArgumentException ex)
{
    Console.WriteLine($"Caught:{ex.Message}");
}

var s = new Student {Id = "S1",Name = "Abebe",Age = 20,GPA =3.8m};
Console.WriteLine($"Student:{s.Name},Gpa:{s.GPA}");

void PrintGradeReport(IEnumerable<IGradable>asessments)
{
    Console.WriteLine("---Grade Report---");
    foreach( var item in asessments)
    {
        Console.WriteLine($"{item.Title}:{item.CalculateGrade():F2}%");
    }
}


IGradable[] cohortAssessments = [
    new Quiz {Title ="C# Basics",CorrectAnswers = 18,TotalQuestions =20},
    new LabAssignment {Title ="Registration API",FunctionalityScore =90m,CodeQualityScore = 85m}
];

PrintGradeReport(cohortAssessments);



//Module-1-Lab-Session2

var service = new EnrollmentService();

var validStudent = new Student { Id = "S1",Name ="Abebe",Age = 20,GPA = 3.8m};
var validCourse = new Courses {Code ="CS-401",Title = "Advanced C#", Capacity = 30};
var result = service.ProcessRegistration(validStudent,validCourse);

Console.WriteLine($"Enrolled:{result.StudentId} in {result.CourseCode}");

try
{
    service.ProcessRegistration(null, validCourse);
}
catch(ArgumentNullException ex)
{
    Console.WriteLine($"Guard caught:{ex.ParamName}");
}

var fullCourse = new Courses {Code = "CS-402",Title = "Full course",Capacity = 1};
fullCourse.EnrolledCount = 1;
try
{
    service.ProcessRegistration(validStudent,fullCourse);
}
catch(InvalidOperationException ex)
{
    Console.WriteLine($"Business rule:{ex.Message}");
}

List<Student> students =
[
    new Student {Id="S1",Name ="Abebe",Age =22, GPA = 3.8m},
    new Student {Id="S2",Name ="Kidane",Age =21, GPA = 2.4m},
    new Student {Id="S3",Name ="Dawit",Age =20, GPA = 3.1m},
    new Student {Id="S4",Name ="Sara",Age =23, GPA = 3.9m},
    new Student {Id="S5",Name ="Frehiwot",Age =19, GPA = 2.0m},
    new Student {Id="S6",Name ="Yonas",Age =24, GPA = 3.5m},
    new Student {Id="S7",Name ="Meron",Age =22, GPA = 1.8m},
    new Student {Id="S8",Name ="Tesfaye",Age =21, GPA = 2.9m},
];

var honorStudents = students.Where(s => s.GPA >= 3.5m);
Console.WriteLine($"Honors students:{honorStudents.Count()}");
Console.WriteLine("Honor students are");
foreach (var en in honorStudents)

Console.WriteLine($" {en.Name}: {en.GPA}");

Console.WriteLine("students in Descending orders");
var leaderboard = students.OrderByDescending(s => s.GPA).Select(s => new{s.Name, s.GPA});
foreach (var entry in leaderboard)
Console.WriteLine($" {entry.Name}: {entry.GPA}");


 var averageGpa = students.Average(s => s.GPA);
 Console.WriteLine($"\nClass Average GPA:{averageGpa:F2}");


var standingGroups = students.GroupBy(s=>s.GPA switch 
{
    >= 3.5m =>"Honors", >= 2.5m =>"Good Standing",>= 2.0m =>"Probation",_=>"Academic Warning"
});
// //  
Console.WriteLine($"\n--- Academic Standing Report---");

foreach(var group in standingGroups)
{
    Console.WriteLine($"\n{group.Key}({group.Count()}):");
    foreach(var st in group)
    {
        Console.WriteLine($"{st.Name} GPA:{st.GPA}");
    }
}
string[] backendCourses = ["C# Essentials", "ASP.NET Core","EF Core"];
string[] frontendCourse = ["TypeScript", "Angular 21"];
string[] allCourses = [..backendCourses,..frontendCourse,"Capstone"];

Console.WriteLine($"\nFull curriculum: {string.Join(",",allCourses)}");



//Module-1-Lab-Session3



