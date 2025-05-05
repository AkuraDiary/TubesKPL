
﻿using System;
﻿using LoginApp;
﻿using AKMJ_TubesKPL.Repo;
using Auth.Register;


namespace AKMJ_TubesKPL
{
    public class Program
    {

        static void Main(string[] args)
        {
            var users = UserData.GetUsers();
            var authService = new Userservice(users);

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (authService.Authenticate(username, password, out User user))
            {
                Console.WriteLine($"Login berhasil {user.Username}!");
            }
            else
            {
                Console.WriteLine("Login gagal password/username salah");

            }
        }
    } 
}
            //    var repository = new TodoRepository();
            //    var service = new TodoService(repository);

            //    bool exit = false;
            //    while (!exit)
            //    {
            //        Console.Clear();
            //        Console.WriteLine("=== Selamat datang pada To-Do List ===");
            //        Console.WriteLine("1. Lihat Daftar To-Do");
            //        Console.WriteLine("2. Tambah To-Do Baru");
            //        Console.WriteLine("3. Edit To-Do");
            //        Console.WriteLine("4. Hapus To-Do");
            //        Console.WriteLine("5. Tandai Selesai");
            //        Console.WriteLine("6. Keluar");
            //        Console.Write("Pilih menu: ");



            //        var choice = Console.ReadLine();
            //        switch (choice)
            //        {
            //            case "1":
            //                service.ViewAll();
            //                break;
            //            case "2":
            //                service.AddNew();
            //                break;
            //            case "3":
            //                service.Edit();
            //                break;
            //            case "4":
            //                service.Delete();
            //                break;
            //            case "5":
            //                service.ToggleComplete();
            //                break;
            //            case "6":
            //                exit = true;
            //                break;
            //            default:
            //                Console.WriteLine("Pilihan tidak valid!");
            //                Console.ReadKey();
            //                break;
            //        }
            //    }
        //public static void Main(string[] args)
        //{
        //    AuthRepository authRepo = new AuthRepository();
        //    authRepo.LoadUsers();
        //    RegistrationModule regis = new RegistrationModule(
        //    authRepo
        //        );

        //    regis.RegisterUser("hakim", "hakim", "hakim");

