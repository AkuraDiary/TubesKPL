using LoginApp;

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