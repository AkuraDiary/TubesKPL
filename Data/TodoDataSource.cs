using GuiModul.Data.Models;
using GuiModul.Interface;
using System;
using System.IO;
using System.Text.Json;

namespace GuiModul.Data
{
    public class TodoDataSource : IAppFileInteractor<Todos>
    {
        private const string separator = "\\";
        internal int returnCode = 0;

        public Todos ReadFile(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string jsonString = File.ReadAllText(filepath);
                    if (jsonString.Equals(""))
                    {
                        Console.WriteLine($"Todo masih kosong");
                        return new Todos();
                    }
                    var todos = JsonSerializer.Deserialize<Todos>(jsonString);
                    return todos;

                }
                else
                {
                    Console.WriteLine("File Not Found, Creating File " + filepath);
                    // create new file

                    string dirPath = filepath.Split("\\".ToCharArray())[0];
                    Directory.CreateDirectory(dirPath);
                    File.Create(filepath).Dispose();
                    Console.WriteLine("File Created In " + filepath);
                    Todos todos = new Todos();
                    //return todos;
                    return ReadFile(filepath);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Reading File : {e.Message}");
                Todos todos = new Todos();
                return todos;
            }
        }

        public void SaveToFile<T>(T data, string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {

                    var option = new JsonSerializerOptions()
                    {
                        WriteIndented = true
                    };

                    var json = JsonSerializer.Serialize(data, option);
                    File.WriteAllText(filepath, json);
                    Console.WriteLine($"Successfully Updated Todos");
                    returnCode = 1;
                }
                else
                {
                    Console.WriteLine("File Not Found, Creating File " + filepath);
                    // create new file
                    File.Create(filepath).Dispose();
                    Console.WriteLine("File Created In " + filepath);
                    SaveToFile(data, filepath);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Saving File : {e.Message}");
                returnCode = -1;
            }

        }
    }
}