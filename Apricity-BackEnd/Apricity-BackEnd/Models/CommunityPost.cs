using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class CommunityPost
{
    public int PostId { get; set; }

    public int? UserId { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CommunityComment> CommunityComments { get; set; } = new List<CommunityComment>();

    public virtual ICollection<CommunityLike> CommunityLikes { get; set; } = new List<CommunityLike>();

    public virtual User? User { get; set; }
}
