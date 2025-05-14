using AKMJ_TubesKPL.Data.Models;
using AKMJ_TubesKPL.Repo;
using Auth.Login;
using Auth.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.View.AuthView
{
     class AuthView
    {
        private readonly Dictionary<string, Action> MenuOptions;
        

    
        LoginModule loginModule { get; set; }
        RegistrationModule registerModule { get; set; }
        public AuthView(LoginModule loginM, RegistrationModule registerM)
        {
            this.loginModule = loginM;
            this.registerModule = registerM;
           
            MenuOptions = new Dictionary<string, Action>
        {
            { "1", () => ShowLoginForm() },
            { "2", () => ShowRegisterForm() },
            { "x", () => ExitApplication() }
        };
        }
        public  (string username, string password) GetLoginCredentials()
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN ===");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = GetMaskedPassword();

            return (username, password);
        }
        public  void ShowLoginSuccess(string username)
        {
            Console.WriteLine($"\nLogin berhasil! Selamat datang, {username}!");
            Console.ReadKey();
        }

        public  void ShowLoginError(string message)
        {
            Console.WriteLine($"\nError: {message}");
            Console.ReadKey();
        }
        public  (string nama, string username, string password) GetRegisterCredentials()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTER ===");

            Console.Write("Nama: ");
            string nama = Console.ReadLine();

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = GetMaskedPassword();

            return (nama, username, password);
        }

        public  void ShowRegisterSuccess(string username)
        {
            Console.WriteLine($"\nRegistrasi berhasil! Akun {username} telah dibuat.");
            Console.WriteLine("Silakan login menggunakan akun Anda.");
            Console.ReadKey();
        }

        public  void ShowRegisterError(string message)
        {
            Console.WriteLine($"\nError registrasi: {message}");
            Console.ReadKey();
        }

        private  string GetMaskedPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            return password;
        }
        public  void ShowAuthMenu()
        {
            string input;
            //do
            //{
                Console.Clear();
            Console.WriteLine("=== AUTH MENU ===");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("x. Exit");
                Console.Write("Pilihan: ");

                input = Console.ReadLine();
                if (MenuOptions.ContainsKey(input))
                {
                    MenuOptions[input].Invoke();
                }

            //} while (input != "x");
        }

        private  void ShowLoginForm()
        {
            var (username, password) = GetLoginCredentials();
            if (loginModule.Authenticate(username, password, out User user))
            {
                loginModule.saveSession(user);

            }
           
        }

        private  void ShowRegisterForm()
        {
            var (nama, username, password) = GetRegisterCredentials();
            if(registerModule.RegisterUser(nama, username, password)){
                Console.WriteLine();
                Console.WriteLine("Pendaftaran berhasil!");
            }

        }

        private  void ExitApplication()
        {
            loginModule.Deauthenticate();
            Console.WriteLine("\nKeluar aplikasi...");
            Environment.Exit(0);
        }
    }
}