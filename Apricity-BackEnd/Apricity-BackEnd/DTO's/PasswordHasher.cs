using System.Text;

namespace Apricity_BackEnd.DTO_s
{
    public class PasswordHasher
    {
        public static void createPasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt) //out : variables that will be returned, but here we want to return 2 vars, so we use "out", if we want one only we can put return 
        {
            using (var h = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = h.Key; // come from method sha512
                PasswordHash = h.ComputeHash(Encoding.UTF8.GetBytes(password)); //password => hashing
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }
        }
    }
}
