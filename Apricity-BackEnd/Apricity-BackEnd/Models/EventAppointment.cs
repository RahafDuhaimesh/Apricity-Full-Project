using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class EventAppointment
{
    public int AppointmentId { get; set; }

    public int? EventId { get; set; }

    public int? UserId { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public string? Status { get; set; }

    public string? ChildName { get; set; }

    public int? ChildAge { get; set; }

    public string? Comment { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? User { get; set; }
}
