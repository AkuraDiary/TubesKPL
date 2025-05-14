using AKMJ_TubesKPL.Data.Models;
using AKMJ_TubesKPL.Repo;
using Auth.Login;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Auth.Login.LoginTest
{
    [TestClass]
    public class LoginTest
    {
        // Test Enkripsi Password
        [TestMethod]
        public void TestEnkripsi()
        {
            string passwordPlain = "AKMJ";
            string encrypted = LoginLibrary.EnkripsiPian.HashPassword(passwordPlain);

            Assert.IsInstanceOfType<string>(encrypted);
            Assert.AreNotEqual(passwordPlain, encrypted);
        }


        // Test Validasi Password
        [TestMethod]
        public void TestValidasiPassword()
        {
            string passwordPlain = "AKMJ";
            string encrypted = LoginLibrary.EnkripsiPian.HashPassword(passwordPlain);

            Assert.IsTrue(LoginLibrary.EnkripsiPian.CheckPassword(passwordPlain, encrypted));
        }

        // Test Login benar
        [TestMethod]
        public void TestLoginnBenar()
        {
            // Arrange
            AuthRepository repoAuth = new AuthRepository(new AppConfig());
            LoginModule loginModule = new LoginModule(repoAuth);

            User usr = new User();
            usr.Username = "admin";
            usr.Password = LoginLibrary.EnkripsiPian.HashPassword("admin123");
            loginModule.authRepository.listRegisteredUser.Add(usr);


            //ACT & Assert
            Assert.IsTrue(loginModule.Authenticate("admin", "admin123", out User authResult));
         
        }

        // Test Login Salah
        [TestMethod]
        public void TestLoginnSalah()
        {
            // Arrange
            AuthRepository repoAuth = new AuthRepository(new AppConfig());
            LoginModule loginModule = new LoginModule(repoAuth);

            User usr = new User();
            usr.Username = "admin";
            usr.Password = LoginLibrary.EnkripsiPian.HashPassword("admin123");
            loginModule.authRepository.listRegisteredUser.Add(usr);


            //ACT & Assert
            Assert.IsFalse(loginModule.Authenticate("admin", "admin", out User authResult));
        }


        // Test Session Tersimpan
        [TestMethod]
        public void TestSessionTersimpan()
        {
            // Arrange
            AuthRepository repoAuth = new AuthRepository(new AppConfig());
            LoginModule loginModule = new LoginModule(repoAuth);

            User usr = new User();
            usr.Username = "admin";
            usr.Password = LoginLibrary.EnkripsiPian.HashPassword("admin123");
            loginModule.authRepository.listRegisteredUser.Add(usr);


            //ACT & Assert
            Assert.IsTrue(loginModule.Authenticate("admin", "admin123", out User authResult));
            loginModule.saveSession(authResult);
            Assert.IsNotNull(loginModule.authRepository.loggedInUser);
            Assert.AreEqual(loginModule.authRepository.loggedInUser.Username, usr.Username);
        }
    }
}
