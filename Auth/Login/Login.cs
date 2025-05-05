using System;
using System.Collections.Generic;
using System.Linq;

namespace LoginApp
{
    // Model User
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    // (Table Driven)
    public static class UserData
    {
        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User { Username = "Admin", Password = "Admin345" },
                new User { Username = "user", Password = "User123" },
                
            };
        }
    }

   // (Reusable Library)
    public class Userservice
    {
        private readonly List<User> user;

        public Userservice(List<User> users)
        {
            user = users;
        }

        public bool Authenticate(string username, string password, out User loginUser)
        {
            loginUser = user.FirstOrDefault(u => u.Username.Equals(username) && u.Password == password);

            return loginUser != null;
        }
    }

   
    
}
