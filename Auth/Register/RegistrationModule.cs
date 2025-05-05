using System;
using AuthLibrary;

namespace Auth.Register
{
    public class RegistrationModule
    {
        private const string UserConfigPath = "user_config.json";

        public bool RegisterUser(string nama, string username, string password)
        {
            // Validasi username
            if (!AuthUtilities.ValidateUsername(username, UserConfigPath))
            {
                Console.WriteLine("Username sudah digunakan.");
                return false;
            }

            // Buat user baru
            User newUser = new User
            {
                Nama = nama,
                Username = username,
                Password = AuthUtilities.HashPassword(password)
            };

            // Simpan ke file
            try
            {
                AuthUtilities.WriteUserConfig(newUser, UserConfigPath);
                Console.WriteLine("Pendaftaran berhasil!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}