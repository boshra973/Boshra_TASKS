using System;
using System.Collections.Generic;

namespace EF1.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string SfirstName { get; set; } = null!;

    public string SlastName { get; set; } = null!;

    public string? Adress { get; set; }

    public DateOnly? BirthDate { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
