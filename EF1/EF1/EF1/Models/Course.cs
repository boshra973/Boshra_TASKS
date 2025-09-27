using System;
using System.Collections.Generic;

namespace EF1.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CName { get; set; } = null!;

    public int Credits { get; set; }

    public int? ProfessorId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Professor? Professor { get; set; }
}
