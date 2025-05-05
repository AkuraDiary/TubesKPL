using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.View.Menu
{
    public class MenuView
    {
        private static Dictionary<string, Action> crudMenu = new Dictionary<string, Action>()
        {
            { "1", () => ShowToDos() },
            { "2", () => CreateToDo() },
            { "3", () => UpdateToDo() },
            { "4", () => DeleteToDo() },
            {"0", () => Program.CurrentUser = null}
        };

        public static void showDashboard()
        {
            Console.Clear();
            Console.WriteLine($"=== APLIKASI TO DO LIST UNTUK ({Program.CurrentUser}) ===");
            Console.WriteLine("1. Lihat To Do");
            Console.WriteLine("2. Tambah To Do");
            Console.WriteLine("3. Update To Do");
            Console.WriteLine("4. Delete To Do");
            Console.WriteLine("5. Logout");
            Console.WriteLine("Pilihan: ");

            var choice = Console.ReadLine();
            if (crudMenu.ContainsKey(choice)) 
            {
                crudMenu[choice]();
            }
        }

        private static void ShowToDos()
        {
            Console.WriteLine("\nDaftar ToDo: ");
            var todos = TodoController.GetTodos(Program.CurrentUser);

            for each (var todo in todos) 
            {
                Console.WriteLine($"| {todo.Id,-3} | {todo.Title,-15} | {todo.Description,-15} | {todo.Status,-15}");
            }
            Console.ReadKey();            
        }

        private static void CreateToDo()
        {
            Console.Write("\nJudul: ");
            string title = Console.ReadLine();
            Console.Write("Deskripsi: ");
            string desc = Console.ReadLine();
            Console.Write("Status: ");
            string stats = Console.ReadLine();

            TodoController.AddTodo(Program.CurrentUser, title, desc);
            Console.WriteLine("Todo berhasil ditambahkan!");
            Console.ReadKey();
        }

        private static void UpdateToDo()
        {
            ShowToDos();

            Console.Write("\nMasukkan ID ToDo yang akan diupdate: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID tidak valid!");
                Console.ReadKey();
                return;
            }

            Console.Write("Judul Baru (kosongkan jika tidak ingin diubah): ");
            string newTitle = Console.ReadLine();

            Console.Write("Deskripsi Baru (kosongkan jika tidak ingin diubah): ");
            string newDesc = Console.ReadLine();

            Console.Write("Status Baru (kosongkan jika tidak ingin diubah): ");
            string newStatus = Console.ReadLine();

            bool success = TodoController.UpdateTodo(id, Program.CurrentUser,
                string.IsNullOrEmpty(newTitle) ? null : newTitle,
                string.IsNullOrEmpty(newDesc) ? null : newDesc,
                string.IsNullOrEmpty(newStatus) ? null : newStatus);

            if (success)
            {
                Console.WriteLine("ToDo berhasil diupdate!");
            }
            else
            {
                Console.WriteLine("Gagal update! ToDo tidak ditemukan.");
            }
            Console.ReadKey();
        }

        private static void DeleteToDo()
        {
            ShowToDos();

            Console.Write("\nMasukkan ID ToDo yang akan dihapus: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID tidak valid!");
                Console.ReadKey();
                return;
            }

            Console.Write("Yakin ingin menghapus? (y/n): ");
            string confirm = Console.ReadLine().ToLower();

            if (confirm == "y")
            {
                bool success = TodoController.DeleteTodo(id, Program.CurrentUser);

                if (success)
                {
                    Console.WriteLine("ToDo berhasil dihapus!");
                }
                else
                {
                    Console.WriteLine("Gagal menghapus! ToDo tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("Penghapusan dibatalkan.");
            }
            Console.ReadKey();
        }
    }
}
