using Apricity_BackEnd.Models;

namespace Apricity_BackEnd.DTO_s
{
    public class CommentOnArticleRequestDTO
    {
        public int ArticleId { get; set; } // يجب أن يكون موجود
        public int UserId { get; set; } // يجب أن يكون موجود
        public string CommentText { get; set; } // يجب أن يكون موجود
    }

}
