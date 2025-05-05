using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AuthLibrary
{
    public static class AuthUtilities
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static bool ValidateUsername(string username, string filePath)
        {
            if (!File.Exists(filePath)) return true;

            var lockObj = new object();
            lock (lockObj)
            {
                var json = File.ReadAllText(filePath);
                var users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
                return !users.Exists(u => u.Username == username);
            }
        }

        public static void WriteUserConfig(User user, string filePath)
        {
            var lockObj = new object();
            lock (lockObj)
            {
                List<User> users = new List<User>();

                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
                }

                users.Add(user);
                var updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
        }
    }

    public class User
    {
        public string Nama { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}