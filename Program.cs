using System;

partial class Program
{
    static void Main()
    {
        // Initialize the repository
        var repository = new SchoolRepository();

        // Create a new subject
        var mathSubject = new Subject
        {
            Title = "Mathematics",
            MaximumCapacity = 30
        };
        repository.AddSubject(mathSubject);

        // Add some students
        var student1 = new Student
        {
            Name = "anna smith",
            EnrollmentDate = DateTime.Now
        };
        var student2 = new Student
        {
            Name = "Bob rogers",
            EnrollmentDate = DateTime.Now
        };

        repository.AddStudent(student1);
        repository.AddStudent(student2);

        // Enroll students in the subject
        repository.EnrollStudentToSubject(student1.StudentId, mathSubject.SubjectId);
        repository.EnrollStudentToSubject(student2.StudentId, mathSubject.SubjectId);

        // Read and display data
        var subjects = repository.GetAllSubjects();
        foreach (var subject in subjects)
        {
            Console.WriteLine($"Subject: {subject.Title}");
            foreach (var student in subject.Students)
            {
                Console.WriteLine($" - Student: {student.Name}");
            }
        }
    }
}
