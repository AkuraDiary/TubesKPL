
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

            while (true)
            {
               

                if (DI.authRepo.loggedInUser != null)
                {
                    DI.menuView.showDashboard();
                }
                else
                {
                    DI.authView.ShowAuthMenu();

                }
               
            }
            
            //Console.Write("Username: ");
            //string username = Console.ReadLine();

            //Console.Write("Password: ");
            //string password = Console.ReadLine();

            //if (login.Authenticate(username, password, out User user))
            //{
            //    login.loggedInUser = user;
            //    Console.WriteLine($"Login berhasil {user.Username}!");
            //}
            //else
            //{
            //    Console.WriteLine("Login gagal password/username salah");
            //}
    }
    } 
}

