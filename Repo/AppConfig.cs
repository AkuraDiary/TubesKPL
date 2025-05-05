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
        public string UserAccountConfigPath { get; set; }
        public string StoragePath { get; set; }

        public AppConfig(string userAccountConfigPath, string storagePath)
        {
            UserAccountConfigPath = userAccountConfigPath;
            StoragePath = storagePath;
        }
        public void InitConfig(string appConfigpath)
        {
            if (File.Exists(appConfigpath))
            {
                SaveToFile<string>(AppConstant.defaultAppConfig, appConfigpath);
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

        public void LoadAppConfig(string appConfigpath)
        {
            if (File.Exists(appConfigpath))
            {
                AppConfig config = ReadFile(appConfigpath);
                this.UserAccountConfigPath = config.UserAccountConfigPath;
                this.StoragePath = config.StoragePath;

            }
            else
            {

                Console.WriteLine($"Error : Config File Not Found");
            }
        }

        public AppConfig ReadFile(string filepath)
        {
            try
            {
                string jsonString = File.ReadAllText(filepath);
                var config = JsonSerializer.Deserialize<AppConfig>(jsonString);
                return config;
            }catch(Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
                return new AppConfig("", "");
            }
        }

        public void SaveToFile<T>(T data, string filepath)
        {

            try
            {
                var option = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(data, option);
                File.WriteAllText(filepath, json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
                return;
            }
         
        }
    }
}
