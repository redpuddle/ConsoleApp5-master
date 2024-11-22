using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Subject
{
    [Key]
    public int SubjectId { get; set; }
    public string Title { get; set; }
    public int MaximumCapacity { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
}
