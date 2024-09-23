using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? EventDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? MinChildAge { get; set; }

    public int? MaxChildAge { get; set; }

    public int? Capacity { get; set; }

    public double? Price { get; set; }

    public int? TeacherId { get; set; }

    public virtual ICollection<EventAppointment> EventAppointments { get; set; } = new List<EventAppointment>();

    public virtual Teacher? Teacher { get; set; }
}
