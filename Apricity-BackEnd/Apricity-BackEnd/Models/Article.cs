using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class Article
{
    public int ArticleId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public int? AuthorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Topic { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<ArticleComment> ArticleComments { get; set; } = new List<ArticleComment>();

    public virtual User? Author { get; set; }
}
