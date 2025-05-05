using AKMJ_TubesKPL.Repo.Interface;
using AKMJ_TubesKPL.Repo.Models;
using AKMJ_TubesKPL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Repo
{
    public class AppConfig : IAppFileInteractor<AppConfig>
    {
        string UserAccountConfigPath { get; set; }
        string StoragePath { get; set; }

        public AppConfig(string userAccountConfigPath, string storagePath)
        {
            UserAccountConfigPath = userAccountConfigPath;
            StoragePath = storagePath;
        }

        public void InitConfig(string appConfigpath)
        {
            if (File.Exists(appConfigpath))
            {
                var option = new JsonSerializerOptions() {
                WriteIndented = true};
             
                var updatedJson = JsonSerializer.Serialize(AppConstant.defaultAppConfig, option);
                File.WriteAllText(appConfigpath, updatedJson);
            }
            else
            {
                // create new file 
                using (File.Create(appConfigpath))
                {
                    InitConfig(appConfigpath);
                }
            }
}

        public void InsertToFile<T>(T data, string filepath)
        {
            throw new NotImplementedException();
        }        

        public void LoadAppConfig(string appConfigpath)
        {
            if (File.Exists(appConfigpath))
            {
              

            }
        }

        public AppConfig ReadFile(string filepath)
        {
            try
            {
                string jsonString = File.ReadAllText(filepath);
                var config = JsonSerializer.Deserialize<AppConfig>(jsonString);
                return new AppConfig();
            }catch(Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
                return new AppConfig("", "");
            }
        }

        public void SaveToFile<T>(T data, string filepath)
        {
            throw new NotImplementedException();
        }
    }
}
