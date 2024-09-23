﻿using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string? Email { get; set; }

    public string? Message { get; set; }

    public string? Subject { get; set; }

    public DateTime? CreatedAt { get; set; }
}
