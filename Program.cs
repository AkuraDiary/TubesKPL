using AKMJ_TubesKPL.Repo;
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


        }
    }
}