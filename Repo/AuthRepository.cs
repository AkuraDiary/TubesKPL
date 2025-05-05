using AKMJ_TubesKPL.Repo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Repo
{
    class AuthRepository
    {
       public List<User> listRegisteredUser { get; set; }

        private static string userFilePath = "user_config.json";
     
        public void RegisterUser(User newUser)
        {
            List<User> users;

            if (File.Exists(userFilePath))
            {
                var json = File.ReadAllText(userFilePath);
               
                users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();

                users.Add(newUser);
                var updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(userFilePath, updatedJson);
            }
            else
            {
                // create new file 
                using (File.Create(userFilePath)) {
                    RegisterUser(newUser);
                }
            }

            LoadUsers();
        }

        public void LoadUsers()
        {
            if (File.Exists(userFilePath))
            {
                var json = File.ReadAllText(userFilePath);

                listRegisteredUser = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();

            }
            else
            {
                listRegisteredUser = new List<User>();
            }
        }
    }
}
