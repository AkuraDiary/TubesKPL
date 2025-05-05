<<<<<<< HEAD
﻿using LoginApp;
=======
﻿using AKMJ_TubesKPL.Repo;
using Auth.Register;

namespace AKMJ_TubesKPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AuthRepository authRepo = new AuthRepository();
            authRepo.LoadUsers();
            RegistrationModule regis = new RegistrationModule(
            authRepo
                );

            regis.RegisterUser("hakim", "hakim", "hakim");

>>>>>>> 4c16f146dcb60c7a79e152c12905a3443ec16ab5

class Program
{
    static void Main()
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