using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.View.AuthView
{
    public class UserService
    {
        private static readonly Dictionary<string, Action> MenuOptions = new Dictionary<string, Action>
        {
            { "1", () => ShowLoginForm() },
            { "2", () => ShowRegisterForm() },
            { "x", () => ExitApplication() }
        };
        public static (string username, string password) GetLoginCredentials()
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN ===");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = GetMaskedPassword();

            return (username, password);
        }
        public static void ShowLoginSuccess(string username)
        {
            Console.WriteLine($"\nLogin berhasil! Selamat datang, {username}!");
            Console.ReadKey();
        }

        public static void ShowLoginError(string message)
        {
            Console.WriteLine($"\nError: {message}");
            Console.ReadKey();
        }
        public static (string nama, string username, string password) GetRegisterCredentials()
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

        public static void ShowRegisterSuccess(string username)
        {
            Console.WriteLine($"\nRegistrasi berhasil! Akun {username} telah dibuat.");
            Console.WriteLine("Silakan login menggunakan akun Anda.");
            Console.ReadKey();
        }

        public static void ShowRegisterError(string message)
        {
            Console.WriteLine($"\nError registrasi: {message}");
            Console.ReadKey();
        }

        private static string GetMaskedPassword()
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
        public static void ShowAuthMenu()
        {
            string input;
            do
            {
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

            } while (input != "x");
        }

        private static void ShowLoginForm()
        {
            var (username, password) = GetLoginCredentials();
            
        }

        private static void ShowRegisterForm()
        {
            var (nama, username, password) = GetRegisterCredentials();
        }

        private static void ExitApplication()
        {
            Console.WriteLine("\nKeluar aplikasi...");
            Environment.Exit(0);
        }
    }
}