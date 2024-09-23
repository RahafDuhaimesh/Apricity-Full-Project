using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class CommunityComment
{
    public int CommentId { get; set; }

    public int? PostId { get; set; }

    public int? UserId { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual CommunityPost? Post { get; set; }

    public virtual User? User { get; set; }
}
