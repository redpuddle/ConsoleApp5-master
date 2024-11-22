using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class SchoolRepository
{
    private readonly SchoolContext _context;

    public SchoolRepository()
    {
        _context = new SchoolContext();
        _context.Database.EnsureCreated();
    }

    public void AddSubject(Subject subject)
    {
        _context.Subjects.Add(subject);
        _context.SaveChanges();
    }

    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public void EnrollStudentToSubject(int studentId, int subjectId)
    {
        var student = _context.Students.Find(studentId);
        var subject = _context.Subjects.Find(subjectId);

        if (student != null && subject != null && subject.Students.Count < subject.MaximumCapacity)
        {
            subject.Students.Add(student);
            _context.SaveChanges();
        }
    }

    public List<Subject> GetAllSubjects()
    {
        return _context.Subjects.Include(s => s.Students).ToList();
    }

    public List<Student> GetStudentsForSubject(int subjectId)
    {
        var subject = _context.Subjects.Include(s => s.Students).FirstOrDefault(s => s.SubjectId == subjectId);
        return subject?.Students ?? new List<Student>();
    }
}
