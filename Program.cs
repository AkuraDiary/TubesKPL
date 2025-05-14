
using System;
using AKMJ_TubesKPL.Repo;
using Auth.Register;
using AKMJ_TubesKPL.Util;
using Auth.Login;
using AKMJ_TubesKPL.Data.Models;


namespace AKMJ_TubesKPL
{
    public class Program
    {

        static void Main(string[] args)
        {

            DI.init();

            //while (true)
            //{


            //    if (DI.authRepo.loggedInUser != null)
            //    {
            //        DI.menuView.showDashboard();
            //    }
            //    else
            //    {
            //        DI.authView.ShowAuthMenu();

            //    }

            //}

            // insert dummy User
            User usr = new User();
            usr.Username = "pian";
            usr.Password= LoginLibrary.EnkripsiPian.HashPassword("pian");

            DI.login.authRepository.listRegisteredUser.Add(usr);
            
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (DI.login.Authenticate(username, password, out User user))
            {
                DI.login.saveSession(user);
                Console.WriteLine($"Login berhasil {user.Username}!");
            }
            else
            {
                Console.WriteLine("Login gagal password/username salah");
            }
        }
    } 
}

