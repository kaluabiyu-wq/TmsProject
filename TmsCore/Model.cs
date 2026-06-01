

using System.Security.Cryptography.X509Certificates;

public record EnrollmentRecord(string StudentId, string CourseCode,DateTime EnrolledAt);

public class Enrollment
{
    public string StudentId{get;set;}=string.Empty;
    public  readonly string CourseCode;

    public DateTime ProcessedAt {get;set;}

}

public class Course
{
    private int _capacity;
    
    public int Capacity
    {
        get => _capacity;
        set
        {
            if (value <= 0)
            throw new ArgumentOutOfRangeException("Capacity must be positive.");
            _capacity = value;
         
        }

    }
}

public class Courses
{
    public required string Code {get;init;}

    public required string Title
    {
        get;
        set =>field =!string.IsNullOrWhiteSpace(value)
        ? value
       : throw new ArgumentException("Title Cannot be empty or whiteSpace",nameof(value));

    }
    public int Capacity {get; set;}
    // {
    //     get;
    //     set => field = value > 0
    //     ? value
    //     :throw new ArgumentOutOfRangeException(nameof(value),"System Constraint:Capacity must be greater than zero.");
    // }
    public int EnrolledCount {get; set;}
}

public class Student
{
    public required string Id {get;init;}
    public required string  Name
    {
        get;
        set => field =!string.IsNullOrWhiteSpace(value)
        ? value
        : throw new ArgumentException ("Name cannot be empty or whitespace.",nameof(value));

    }
    public int Age
    {
        get;
        set => field = value is >= 16 and <= 100
        ? value
        :throw new ArgumentOutOfRangeException(nameof(value),"Age must be between 16 and 100,");

    }
    public decimal GPA
    {
        get;
        set => field = value is > 0.0m and <=4.0m
        ? value
        :throw new ArgumentOutOfRangeException(nameof(value),"GPA must be between 0.0 and 4.0");
    }
}

public interface IGradable
{
    string Title{get;}
    decimal CalculateGrade();
}

public class Quiz : IGradable
{
    public required string Title {get;init;}
    public required int CorrectAnswers{get;init;}
    public required int TotalQuestions {get;init;}
    public decimal CalculateGrade()
    {
        if (TotalQuestions == 0) return 0m;
        return (decimal)CorrectAnswers / TotalQuestions * 100m;
      
    }
}

public class LabAssignment : IGradable
{
    public required string Title {get;init;}
    public required decimal FunctionalityScore{get;init;}
    public required decimal CodeQualityScore {get;init;}
    public decimal CalculateGrade()
    {
         return (FunctionalityScore * 0.7m) + (CodeQualityScore * 0.3m);
      
    }
}

 
 public class TmsDatabaseException : Exception
{
    public string Operation {get;}

    public TmsDatabaseException(string operation,string message)
    :base(message)
    {
        Operation = operation;
    }
}
public class CapacityReachedException: InvalidOperationException
{
    public string CourseCode {get;}
    public CapacityReachedException(string courseCode)
    :base($"Course {courseCode} has reached maximum capacity.")
    {
        CourseCode = courseCode;
    }
    public CapacityReachedException(string courseCode,Exception innerException)
    :base($"Course {courseCode} has reached maximumn capacity.", innerException)
    {
        CourseCode = courseCode;
    }
}

