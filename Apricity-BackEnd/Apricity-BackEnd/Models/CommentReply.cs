using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class CommentReply
{
    public int ReplyId { get; set; }

    public int? CommentId { get; set; }

    public int? UserId { get; set; }

    public string? ReplyText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ArticleComment? Comment { get; set; }

    public virtual User? User { get; set; }
}
