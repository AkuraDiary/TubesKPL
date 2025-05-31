using AKMJ_TubesKPL.Data.Models;
using AKMJ_TubesKPL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.View.Menu
{
     public class MenuView
    {
        private Dictionary<string, Action> crudMenu;
        
        //= new Dictionary<string, Action>()
        //{
        //    { "1", () => ShowToDos() },
        //    { "2", () => CreateToDo() },
        //    { "3", () => UpdateToDo() },
        //    { "4", () => DeleteToDo() },
        //};

        TodoRepository todoRepo { get; set; }
        AuthRepository authRepo { get; set; }
        public MenuView(TodoRepository todoRepo, AuthRepository authRepo)
        {
            this.todoRepo = todoRepo;
            this.authRepo = authRepo;

            crudMenu = new Dictionary<string, Action>()
        {
            { "1", () => ShowToDos() },
            { "2", () => CreateToDo() },
            { "3", () => UpdateToDo() },
            { "4", () => DeleteToDo() },
            { "5", () => Logout() },
        };
            this.authRepo = authRepo;
        }

        private void Logout()
        {
            authRepo.loggedInUser = null;
            authRepo.activeDirectory = "";
            todoRepo.ResetState();
        }

        public void showDashboard()
        {
            // Set Active TODO PATH HERE
            todoRepo.activeTodosPath = authRepo.activeDirectory;
            Console.Clear();
            Console.WriteLine($"=== APLIKASI TO DO LIST ===");
            Console.WriteLine($"Selamat Datang : {authRepo.loggedInUser.Nama}");
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

        private  void ShowToDos()
        {
            Console.WriteLine("\nDaftar ToDo: ");
            var todos = todoRepo.GetAll();

            foreach (var todo in todos) 
            {
                string status = todo.IsSelesai ? "Completed" : "Not Completed";
                Console.WriteLine($"| {todo.Id,-3} | {todo.Title,-15} | {todo.Description,-15} | {status,-15}");
            }
            Console.ReadKey();            
        }

        private  void CreateToDo()
        {
            Console.Write("\nJudul: ");
            string title = Console.ReadLine();
            Console.Write("Deskripsi: ");
            string desc = Console.ReadLine();
            //Console.Write("Status: ");
            //string stats = Console.ReadLine();

            TodoItem newTodo = new TodoItem();
            newTodo.Title = title;
            newTodo.Description = desc;
            newTodo.IsSelesai = false;
            todoRepo.Add(newTodo);
            Console.WriteLine("Todo berhasil ditambahkan!");
            Console.ReadKey();
        }

        private  void UpdateToDo()
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

            Console.Write("Sudah selesai? [y/n]: ");
            string newStatus = Console.ReadLine();
            TodoItem newTodo = new TodoItem();

            TodoItem oldTodo = todoRepo.GetById(id);
            string stats = string.IsNullOrEmpty(newStatus) ? "" : newStatus;

            bool isSelesai = stats.ToLower().Equals("y");



            newTodo.Id = id;
            newTodo.Title = string.IsNullOrEmpty(newTitle) ? oldTodo.Title : newTitle;
            newTodo.Description = string.IsNullOrEmpty(newDesc) ? oldTodo.Description : newDesc;
            newTodo.IsSelesai = isSelesai;

            todoRepo.Update(newTodo);

            bool success = todoRepo.returnedCode();

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

        private  void DeleteToDo()
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
               todoRepo.Delete(id);
                bool success = todoRepo.returnedCode();

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
