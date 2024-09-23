using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class ArticleComment
{
    public int CommentId { get; set; }

    public int? ArticleId { get; set; }

    public int? UserId { get; set; }

    public string? CommentText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Article? Article { get; set; }

    public virtual ICollection<CommentReply> CommentReplies { get; set; } = new List<CommentReply>();

    public virtual User? User { get; set; }
}
