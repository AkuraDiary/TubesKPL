﻿using System;
using AKMJ_TubesKPL.Data.Models;
using AKMJ_TubesKPL.Repo;
using AKMJ_TubesKPL.Util;


//HAKIM
namespace Auth.Register
{
    public class RegistrationModule
    {
        public AuthRepository authRepository { get; set; }

      public RegistrationModule(AuthRepository authRepository)
        {
            this.authRepository = authRepository;

            this.authRepository.LoadUsers();
        }

        public bool RegisterUser(string nama, string username, string password)
        {
            authRepository.activeDirectory = "";
            authRepository.loggedInUser = null;
            // Validasi username
            if (!AuthUtilities.CheckForDuplicateUsername(username, authRepository.listRegisteredUser))
            {
                Console.WriteLine("Username sudah digunakan.");
                return false;
            }

            // Buat user baru
            User newUser = new User
            {
                Id = AuthUtilities.GenerateUserId(authRepository.listRegisteredUser),
                Nama = nama,
                Username = username,
                Password = AuthUtilities.HashPassword(password)
            };

            // Simpan ke file
            try
            {
                authRepository.RegisterUser(newUser);
               
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