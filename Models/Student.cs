using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int StudentId { get; set; }
    public string Name { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public List<Subject> Subjects { get; set; } = new List<Subject>();
}