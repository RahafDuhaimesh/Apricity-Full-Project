using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class UserRole
{
    public int UserId { get; set; }

    public string Role { get; set; } = null!;
}
