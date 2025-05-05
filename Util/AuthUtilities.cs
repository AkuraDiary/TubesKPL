using AKMJ_TubesKPL.Repo.Models;
using System.Security.Cryptography;
using System.Text;

namespace AKMJ_TubesKPL.Util
{
    class AuthUtilities
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static bool CheckForDuplicateUsername(string username, List<User> listUser)
        {
            return !listUser.Exists(u => u.Username == username);
        }

        public static int GenerateUserId(List<User> users)
        {
            return users.Count + 1;
        }
    }
}
