
using System;
using AKMJ_TubesKPL.Repo;
using Auth.Register;
using AKMJ_TubesKPL.Util;
using Auth.Login;
using AKMJ_TubesKPL.Data.Models;


namespace AKMJ_TubesKPL
{
    public class Program
    {

        static void Main(string[] args)
        {

            DI.init();

            TodoItem todo = new TodoItem()
            {
                Id = 1,
                Title = "Bebek",
                Description = "Bebek Goyeng"
            };

            Todos todos = new Todos();
            todos.todos.Add(todo);
            DI.todoDatasource.SaveToFile<Todos>(todos, "dummy.json");

            Todos readTodos = DI.todoDatasource.ReadFile("dummy.json");

            foreach (var item in readTodos.todos)
            {
                Console.WriteLine($"{item.Title} {item.Description}" );
            }
           

            //while (true)
            //{
               

            //    if (DI.authRepo.loggedInUser != null)
            //    {
            //        DI.menuView.showDashboard();
            //    }
            //    else
            //    {
            //        DI.authView.ShowAuthMenu();

            //    }
               
            //}
            
         
    }
    } 
}

