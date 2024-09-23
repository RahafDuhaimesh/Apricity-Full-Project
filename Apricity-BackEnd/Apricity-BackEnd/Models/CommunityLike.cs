using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class CommunityLike
{
    public int LikeId { get; set; }

    public int? PostId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual CommunityPost? Post { get; set; }

    public virtual User? User { get; set; }
}
