using System;
using System.Collections.Generic;

namespace Apricity_BackEnd.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string? AuthorName { get; set; }

    public string? AuthorBio { get; set; }
}
