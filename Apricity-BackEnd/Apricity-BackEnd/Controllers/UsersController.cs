using Apricity_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Apricity_BackEnd.DTO_s;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cors;


namespace Apricity_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _db;
        private readonly TokenGenerator _tokenGenerator;
        public UsersController(MyDbContext db, TokenGenerator tokenGenerator)
        {
            _db = db;
            _tokenGenerator = tokenGenerator;

        }
        ////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserRequestDTO model)
        {
            byte[] passwordHash, passwordSalt;
            if (ModelState.IsValid)
            {
                PasswordHasher.createPasswordHash(model.Password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    PhoneNumber = model.PhoneNumber,
                    Role = model.Role,
                    Password = model.Password
                };
                _db.Users.Add(user);
                _db.SaveChanges();
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }
        ////////////////////////////////////////////////////////////////////
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _db.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user == null || !PasswordHasher.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("البريد الإلكتروني أو الرمز السري غير صحيح.");
            }

            var roles = _db.UserRoles.Where(r => r.UserId == user.UserId).Select(r => r.Role).ToList();
            var token = _tokenGenerator.GenerateToken(user.FirstName, roles);

            return Ok(new { Token = token, Email = user.Email });
        }



        ////////////////////////////////////////////////////////////////////
        [HttpGet("CheckEmailExists")]
        public IActionResult CheckEmailExists(string email)
        {
            var exists = _db.Users.Any(u => u.Email == email);
            return Ok(new { exists });
        }
        ////////////////////////////////////////////////////////////////////
    }
}
