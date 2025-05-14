using AKMJ_TubesKPL.Data.Models;
using AKMJ_TubesKPL.Repo;
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

        // (Table Driven)


        // (Reusable Library)
            public bool Authenticate(string username, string password, out User loginUser)
            {
            //authRepository.LoadUsers();
            loginUser = authRepository.listRegisteredUser.FirstOrDefault(
                  u => u.Username.Equals(username) &&
                  LoginLibrary.EnkripsiPian.CheckPassword(
                      password, u.Password
                  )
              
              );
        
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
