using Apricity_BackEnd.Models;
using Apricity_BackEnd.DTO_s;
namespace Apricity_BackEnd.DTO_s
{
    public class ArticleRequestDTO
    {

        public string? Title { get; set; }

        public string? Content { get; set; }

        public int? AuthorId { get; set; }

        public DateTime? CreatedAt { get; set; }


    }
}
