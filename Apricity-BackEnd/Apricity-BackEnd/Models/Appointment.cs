using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? UserId { get; set; }

    public int? DoctorId { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public string? Status { get; set; }

    public string? Comment { get; set; }

    public string? Feedback { get; set; }

    public string? MeetingLink { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual User? User { get; set; }
}
