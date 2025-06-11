
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
using System.Windows.Forms;

namespace GuiModul
{
    // Dependency and Mediator Design Pattern
   public class DI
    {
        public static AppConfig appConfig;
        public static Data.TodoDataSource todoDatasource;
        public static Repo.AuthRepository authRepo; 
        public static Repo.TodoRepository todoRepo;
        public static RegistrationModule regis;
        public static LoginModule login;

        public static Navigator navigator;

        public static LoginView loginView;
        public static RegisterModul registerView;
        public static MenuView menuView;
        public static FormAdd formAdd;
        public static FormCrud formCrud;
        public static void init()
        {

            Console.WriteLine("Initializing");
            appConfig = AppConfig.getInstance();
            appConfig.InitConfig(AppConstant.defaultAppConfigPath);
            appConfig.LoadAppConfig(AppConstant.defaultAppConfigPath);

            todoDatasource = TodoDataSource.getInstance();
            authRepo = AuthRepository.getInstance(appConfig);
            todoRepo = TodoRepository.getInstance(todoDatasource);

            regis = new RegistrationModule(authRepo);
            login = new LoginModule(authRepo);

            navigator = Navigator.getInstance();

            loginView = new LoginView(navigator);
            registerView = new RegisterModul(navigator, regis);
            menuView =new MenuView(login, todoRepo, navigator);
            formAdd = new FormAdd(navigator);
            formCrud = new FormCrud(navigator);

            Console.WriteLine("Initialized");

        }
    }
}
