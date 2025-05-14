using AKMJ_TubesKPL.Repo;
using Auth.Login;
using Auth.Register;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Auth.Register.RegisterTest
{
    [TestClass]
    public class RegisterTest
    {
        [TestMethod]
        public void registerGagal()
        {

            //Arrange
            AuthRepository authrepo = new AuthRepository(new AppConfig());
            RegistrationModule register = new RegistrationModule(authrepo);

            //Act //Assert
            Assert.IsFalse(register.RegisterUser("Hakim", "isopad23", "Hakim180904"));
            //Assert.IsFalse(register.RegisterUser("Hakim", "isopad23", "Hakim180904"));

        }


        [TestMethod]
        public void AdaDuplikat()
        {

            //Arrange
            AuthRepository authrepo = new AuthRepository(new AppConfig());
            RegistrationModule register = new RegistrationModule(authrepo);

            //Act //Assert
            register.authRepository.LoadUsers();
            List<string> listUsername = authrepo.listRegisteredUser.Select(u => u.Username).ToList();

            Assert.IsTrue(LibraryRegister.HakimRegister.CheckForDuplicateUsername("isopad25",listUsername));
        }
    }
}
