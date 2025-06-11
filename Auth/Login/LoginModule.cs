using GuiModul.Data.Models;
using GuiModul.Repo;
using GuiModul.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuiModul.Auth.Login
{
    
     public class LoginModule{
        public LoginModule(AuthRepository authRepository)
        {
            this.authRepository = authRepository;
            this.authRepository.LoadUsers();
        }
        public AuthRepository authRepository { get; set; }

        // (Table Driven)


        // (Reusable Library)
            public bool Authenticate(string username, string password, out User loginUser)
            {
            authRepository.LoadUsers();
                loginUser = authRepository.listRegisteredUser.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(LoginLibrary.EnkripsiPian.HashPassword(password)));
        
            return loginUser != null;
            }

        public void saveSession(User loginUser)
        {
            authRepository.SaveSession(loginUser);
          
        }
        public void Deauthenticate()
        {
            authRepository.loggedInUser = null;
        }
       
    }
   

   
    
}
