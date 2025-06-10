
using GuiModul.Data.Models;
using GuiModul.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GuiModul.Repo
{
    public class AuthRepository
    {
       public List<User> listRegisteredUser { get; set; }
        public User loggedInUser { get; set; }
        
        AppConfig appConfig { get; set; }

        public AuthRepository(AppConfig appConfig)
        {
            this.appConfig = appConfig;
        }
        
        public string activeDirectory { get; set; }  = "";

        public void SaveSession(User loginUser)
        {
            this.loggedInUser = loginUser;
            this.activeDirectory =  appConfig.StoragePath + loginUser.Username + "_" + AppConstant.userTodoListSuffix;
            DI.todoRepo.activeTodosPath = activeDirectory;
            //Console.WriteLine(this.activeDirectory);
        }

        // HAKIM - menyimpan register user ke dalam file external (runtime config)
        public void RegisterUser(User newUser)
        {

            List<User> users;

            if (File.Exists(AppConstant.userFilePath))
            {
                var json = File.ReadAllText(AppConstant.userFilePath);
               
                users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();

                users.Add(newUser);
                var updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(AppConstant.userFilePath, updatedJson);

                // creating new todolist config for registered user
                if (!Directory.Exists(appConfig.StoragePath))
                {
                    Directory.CreateDirectory(appConfig.StoragePath);
                }


                File.Create(appConfig.StoragePath + newUser.Username + "_" + AppConstant.userTodoListSuffix).Dispose();
            }
            else
            {
                // create new file 
                File.Create(AppConstant.userFilePath).Dispose();
                RegisterUser(newUser);
               
            }

            LoadUsers();
        }

        public void LoadUsers()
        {
            if (File.Exists(AppConstant.userFilePath))
            {
                var json = File.ReadAllText(AppConstant.userFilePath);

                listRegisteredUser = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();

            }
            else
            {
                listRegisteredUser = new List<User>();
            }
        }
    }
}
