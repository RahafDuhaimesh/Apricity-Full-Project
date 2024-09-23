using Apricity_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Apricity_BackEnd.DTO_s;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Apricity_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly MyDbContext _db;
        public ArticlesController(MyDbContext db)
        {
            _db = db;
        }
        /////////////////////////////////////////////////////////////////////////////////

        [HttpGet("GetAllArticles")]
        public IActionResult GetAllArticles()
        {
            var Aricles = _db.Articles.ToList();
            if (Aricles == null) { return NotFound("There is no articles."); }
            return Ok(Aricles);
        }

        /////////////////////////////////////////////////////////////////////////////////

        [HttpGet("GetArticlesByAuthorID")]
        public IActionResult GetArticlesByAuthorID(int id)
        {
            if (id <= 0) { return BadRequest(); }
            var Aricles = _db.Articles.Where(x => x.AuthorId == id).ToList();
            if (Aricles == null) { return NotFound("There is no articles."); }
            return Ok(Aricles);
        }

        /////////////////////////////////////////////////////////////////////////////////

        [HttpGet("GetByAuthorByArticleID")]
        public IActionResult GetByAuthorByArticleID(int id)
        {
            if (id <= 0) { return BadRequest(); }
            var Aricles = _db.Authors.Where(x => x.AuthorId == id).ToList();
            if (Aricles == null) { return NotFound("There is no articles."); }
            return Ok(Aricles);
        }

        /////////////////////////////////////////////////////////////////////////////////
        [HttpGet("GetArticlesByID")]
        public IActionResult GetArticlesByID(int id)
        {
            if (id <= 0) { return BadRequest(); }
            var Aricles = _db.Articles.Where(x => x.ArticleId == id).ToList();
            if (Aricles == null) { return NotFound("There is no articles."); }
            return Ok(Aricles);
        }

        /////////////////////////////////////////////////////////////////////////////////
        [HttpGet("GetArticlesByTopic")]
        public IActionResult GetArticlesByTopic(string topic)
        {
            if (string.IsNullOrEmpty(topic)) { return BadRequest(); }

            var articles = _db.Articles.Where(x => x.Topic == topic).ToList();
            if (articles == null || articles.Count == 0) { return NotFound("لا توجد مقالات لهذا الموضوع."); }

            return Ok(articles);
        }

        /////////////////////////////////////////////////////////////////////////////////
        [HttpGet("GetCommentsByArticle")]
        public IActionResult GetCommentsByArticle(int id)
        {
            if (id <= 0) { return BadRequest(); }
            var Aricles = _db.ArticleComments.Where(x => x.ArticleId == id).ToList();
            if (Aricles == null) { return NotFound("There is no articles."); }
            return Ok(Aricles);
        }

        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost("AddNewArticle")]
        public IActionResult AddNewArticle([FromForm] ArticleRequestDTO articleRequestDTO)
        {
            var NewArticle = new Article
            {
                Title = articleRequestDTO.Title,
                AuthorId = articleRequestDTO.AuthorId,
                Content = articleRequestDTO.Content,
                CreatedAt = articleRequestDTO.CreatedAt
            };
            _db.Articles.Add(NewArticle);
            _db.SaveChanges();
            return Ok(new { message = "Article added successfully!" });
        }

        /////////////////////////////////////////////////////////////////////////////////

        [HttpPut]
        public IActionResult EditArticle(int id, [FromForm] ArticleRequestDTO articleRequestDTO)
        {
            if (id <= 0) { return BadRequest(); }
            var Article = _db.Articles.FirstOrDefault(x => x.ArticleId == id);
            if (Article == null) { return NotFound(); }

            Article.AuthorId = articleRequestDTO.AuthorId ?? Article.AuthorId;
            Article.Content = articleRequestDTO.Content ?? Article.Content;
            Article.CreatedAt = articleRequestDTO.CreatedAt ?? Article.CreatedAt;
            Article.Title = articleRequestDTO.Title ?? Article.Title;

            _db.Articles.Update(Article);
            _db.SaveChanges();
            return Ok(new { message = "Article edited successfully!" });
        }

        /////////////////////////////////////////////////////////////////////////////////
        [HttpGet("GetCommentAuthorName")]
        public IActionResult GetCommentAuthorName(int userId)
        {
            var user = _db.Users.FirstOrDefault(x => x.UserId == userId);
            if (user == null)
            {
                return NotFound(new { message = "User not found!" });
            }

            string fullName = $"{user.FirstName} {user.LastName}";

            return Ok(new { authorName = fullName });
        }

        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost("AddNewCommentOnArticle")]
        public IActionResult AddNewCommentOnArticle([FromForm] CommentOnArticleRequestDTO commentOnArticleRequestDTO)
        {
            if (commentOnArticleRequestDTO.ArticleId <= 0)
            {
                return BadRequest("Invalid article ID.");
            }

            var article = _db.Articles.FirstOrDefault(a => a.ArticleId == commentOnArticleRequestDTO.ArticleId);
            if (article == null)
            {
                return NotFound("Article not found.");
            }

            var newComment = new ArticleComment
            {
                ArticleId = commentOnArticleRequestDTO.ArticleId,
                UserId = commentOnArticleRequestDTO.UserId, // تأكد من وجود UserId في DTO
                CommentText = commentOnArticleRequestDTO.CommentText,
                CreatedAt = DateTime.UtcNow // أو استخدم DateTime.Now حسب الحاجة
            };

            _db.ArticleComments.Add(newComment);
            _db.SaveChanges();
            return Ok(new { message = "Comment added successfully!" });
        }

        /////////////////////////////////////////////////////////////////////////////////

        [HttpPut("{CommentOnAricle}")]
        public IActionResult EditCommentOnAricle(int id, [FromForm] CommentOnArticleRequestDTO commentOnArticleRequestDTO)
        {
            if (id <= 0) { return BadRequest(); }
            var Comment = _db.ArticleComments.FirstOrDefault(x => x.CommentId == id);
            if (Comment == null) { return NotFound(); }

            Comment.CommentText = commentOnArticleRequestDTO.CommentText ?? Comment.CommentText;
            _db.ArticleComments.Update(Comment);
            _db.SaveChanges();
            return Ok(new { message = "Comment edited successfully!" });
        }

        /////////////////////////////////////////////////////////////////////////////////
        [HttpDelete("{CommentOnAricle}")]
        public ActionResult DeleteCommentOnAricle([FromQuery] int id)
        {
            if (id <= 0) { return BadRequest(); }

            var x = _db.ArticleComments.FirstOrDefault(f => f.CommentId == id);
            if (x == null)
            {
                return NotFound();
            }
            _db.ArticleComments.Remove(x);
            _db.SaveChanges();

            return Ok();
        }

        /////////////////////////////////////////////////////////////////////////////////
        [HttpDelete("{Aricle}")]
        public ActionResult DeleteAricle([FromQuery] int id)
        {
            if (id <= 0) { return BadRequest(); }

            var x = _db.Articles.FirstOrDefault(f => f.ArticleId == id);
            if (x == null)
            {
                return NotFound();
            }
            _db.Articles.Remove(x);
            _db.SaveChanges();

            return Ok();
        }

        //[HttpPost("calc")]
        //public IActionResult calc([FromBody] int[] array) 
        //{
        //    int temp = 0;

        //    for (int i = 0; i < array.Length - 1; i++) 
        //    {
        //        for (int j = i + 1; j < array.Length; j++)
        //        {
        //            if (array[i] > array[j])
        //            {
        //                temp = array[i];
        //                array[i] = array[j];
        //                array[j] = temp;
        //            }
        //        }

        //    }
        //    int answer =array[array.Length - 2];
        //    return Ok(answer);
        //}
        // Find the second largest number in an array
        //static int FindSecondLargest(int[] numbers)
        //{
        //    if (numbers.Length < 2)
        //    {
        //        return numbers[0];
        //    }
        //    var largest = numbers[0];
        //    var secondLargest = numbers[0];

        //    for (var i = 1; i < numbers.Length; i++)
        //    {
        //        if (numbers[i] > largest)
        //        {
        //            secondLargest = largest;
        //            largest = numbers[i];
        //        }
        //        else if (numbers[i] > secondLargest)
        //        {
        //            secondLargest = numbers[i];
        //        }
        //    }
        //    return secondLargest;
        //}

        //Console.WriteLine(FindSecondLargest([1, 2, 3, 4, 5, 6, 7, 8, 30, 10]));
        [HttpPost("hello")]
        public IActionResult returnc(int[] array)
        {
            var newarray = array;
            for (int i = array.Length; i < array.Length -1; i--)
            {
                newarray = [array[i]];
            }
            return Ok(newarray);
        }
    }
}
