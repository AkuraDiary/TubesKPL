using AKMJ_TubesKPL.Data.Models;
using AKMJ_TubesKPL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Data
{
    class TodoDataSource : IAppFileInteractor<Todos>
    {
        public Todos ReadFile(string filepath)
        {
            try
            {
                string jsonString = File.ReadAllText(filepath);
                var todos = JsonSerializer.Deserialize<Todos>(jsonString);
                return todos;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Reading File : {e.Message}");
                Todos todos = new Todos();
                todos.todos = new List<TodoItem>();
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
            }

        }
    }
}
