using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? TeacherName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Specialization { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
