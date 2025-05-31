
using GuiModul.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GuiModul
{
    public class AppConfig : Interface.IAppFileInteractor<AppConfig>
    {
        public string UserAccountConfigPath { get; set; }
        public string StoragePath { get; set; }

        public AppConfig(string userAccountConfigPath, string storagePath)
        {
            UserAccountConfigPath = userAccountConfigPath;
            StoragePath = storagePath;
        }

        public AppConfig()
        {
           
        }
        public void InitConfig(string appConfigpath)
        {
            if (File.Exists(appConfigpath))
            {
                var config = ReadFile(appConfigpath);
                if (!config.StoragePath.Equals("") && !config.UserAccountConfigPath.Equals(""))
                {
                    Console.WriteLine("Config File Found - Skipping Initialization");
                    return;
                }
                else
                {
                    Console.WriteLine("Initializing Default Config ");
                    SaveToFile(new AppConfig(AppConstant.userFilePath, "storage\\"), appConfigpath);
                }
              
            }
            else
            {
                // create new file 
                Console.WriteLine("File Config not found, creating new one in " + appConfigpath);
                File.Create(appConfigpath).Dispose();
                
                    Console.WriteLine("Config File Created In " + appConfigpath);

                InitConfig(appConfigpath);
            }
        }  

        public void LoadAppConfig(string appConfigpath)
        {
            if (File.Exists(appConfigpath))
            {
                AppConfig config = ReadFile(appConfigpath);
                UserAccountConfigPath = config.UserAccountConfigPath;
                StoragePath = config.StoragePath;

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
                Console.WriteLine($"Error Reading File : {e.Message}");
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
                Console.WriteLine($"Successfully Updated AppConfig");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Save To File : {e.Message}");
                return;
            }
         
        }
    }
}
