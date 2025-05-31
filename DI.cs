
using GuiModul.Auth.Login;
using GuiModul.Auth.Register;
using GuiModul.Data;
using GuiModul.Repo;
using GuiModul.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiModul
{
   public class DI
    {
        public static AppConfig appConfig;
        public static Data.TodoDataSource todoDatasource;
        public static Repo.AuthRepository authRepo; 
        public static Repo.TodoRepository todoRepo;
        public static RegistrationModule regis;
        public static LoginModule login;
        //public static AuthView authView;
        //public static MenuView menuView;

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

            //menuView = new MenuView(todoRepo, authRepo);
            //authView = new AuthView(login, regis);

            Console.WriteLine("Initializing");

        }
    }
}
