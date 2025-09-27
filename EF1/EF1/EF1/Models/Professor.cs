using System;
using System.Collections.Generic;

namespace EF1.Models;

public partial class Professor
{
    public int ProfessorId { get; set; }

    public string? PfirstName { get; set; }

    public string? PlastName { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
