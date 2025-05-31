using AKMJ_TubesKPL.Data;
using AKMJ_TubesKPL.Repo;
using AKMJ_TubesKPL.Util;
using AKMJ_TubesKPL.View.AuthView;
using AKMJ_TubesKPL.View.Menu;
using Auth.Login;
using Auth.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL
{
   public class DI
    {
        public static AppConfig appConfig;
        public static TodoDataSource todoDatasource;
        public static AuthRepository authRepo; 
        public static TodoRepository todoRepo;
        public static RegistrationModule regis;
        public static LoginModule login;
        public static AuthView authView;
        public static MenuView menuView;

        public static String bebek = "Bebek";
        public static void init()
        {

            Console.WriteLine("Initializing");
            bebek = "Ayam";
            appConfig = new AppConfig();
            appConfig.InitConfig(AppConstant.defaultAppConfigPath);
            appConfig.LoadAppConfig(AppConstant.defaultAppConfigPath);

             todoDatasource = new TodoDataSource();

             authRepo = new AuthRepository(appConfig);
             todoRepo = new TodoRepository(todoDatasource);

             regis = new RegistrationModule(authRepo);
             login = new LoginModule(authRepo);

            menuView = new MenuView(todoRepo, authRepo);
            authView = new AuthView(login, regis);

            Console.WriteLine("Initializing");

        }
    }
}
