using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? DoctorName { get; set; }

    public string? Specialization { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? University { get; set; }

    public string? Bio { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
