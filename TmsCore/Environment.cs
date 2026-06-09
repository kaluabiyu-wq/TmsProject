
public class EnrollmentService

{
    public EnrollmentRecord ProcessRegistration(Student? student,Courses? course)
    {

         if(student is null)
        throw new ArgumentNullException(nameof(student));
        if(course is null)
        throw new ArgumentNullException(nameof(course));
        if(course.Capacity == 0 )
         throw new CapacityReachedException($"{course.Code}");
        if(course.EnrolledCount >= course.Capacity)
        throw new InvalidOperationException("Course has reached capacity.");
        
         //throw new ArgumentNullException($"Course '{course.Title}' is at full capacity.");

        // Console.WriteLine($"Enrolling (student.Name) in {course.Title}");
    

   var standing = student.GPA switch
{
    >= 3.5m =>"Honors", >= 2.5m =>"Good Standing", _=>"Academic Warning"

};
Console.WriteLine($"{student.Name} is in {standing}");

        
return new EnrollmentRecord(student.Id,course.Code,DateTime.UtcNow);

    }
 public Action<Student>? Listener { get; set; }

    public void FinalizeEnrollment(Student s)
    {
        Console.WriteLine("Persisting to database...");

            Listener?.Invoke(s);
    }
}

