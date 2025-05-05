using AKMJ_TubesKPL.Repo;
using AKMJ_TubesKPL.Repo.Models;
using AKMJ_TubesKPL.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Login
{
    
     class LoginModule{
        public LoginModule(AuthRepository authRepository)
        {
            this.authRepository = authRepository;
            this.authRepository.LoadUsers();
        }
        public AuthRepository authRepository { get; set; }

        public User loggedInUser { get; set; }
        // (Table Driven)


        // (Reusable Library)
            public bool Authenticate(string username, string password, out User loginUser)
            {
                loginUser = authRepository.listRegisteredUser.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(AuthUtilities.HashPassword(password)));
            loggedInUser = loginUser;   
            return loginUser != null;
            }

        public void Deauthenticate()
        {
            loggedInUser = null;
        }
       
    }
   

   
    
}
