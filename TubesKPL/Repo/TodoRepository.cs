using AKMJ_TubesKPL.Data;
using AKMJ_TubesKPL.Data.Models;
using AKMJ_TubesKPL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Repo
{

    // NANCIL
    public class TodoRepository : IRepository<TodoItem>
    {
        private List<TodoItem> todos = new List<TodoItem>();
        public string activeTodosPath { get; set; } = ""; // storage/username_todolist.json

        private int nextId = 1;

        TodoDataSource dataSource { get; set; }
        public void ResetState()
        {
            todos = new List<TodoItem>();
            activeTodosPath = "";
            nextId = 1;
        }
        public TodoRepository(TodoDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Add(TodoItem item)
        {
            item.Id = nextId++;
            todos.Add(item);
            CommitChanges();
        }

        public IEnumerable<TodoItem> GetAll()
        {
            todos = dataSource.ReadFile(activeTodosPath).todos;
            nextId = todos.Count;
            return todos;
        }

        public TodoItem GetById(int id)
        {
            return todos.Find(t => t.Id == id);
        }

        public void Update(TodoItem item)
        {
            var existing = GetById(item.Id);
            if (existing != null)
            {
                existing.Title = item.Title;
                existing.Description = item.Description;
                existing.IsSelesai = item.IsSelesai;

                //int index = todos.IndexOf(existing);
                //todos.Insert(index, existing);
                CommitChanges();
            }
        }

        public void Delete(int id)
        {
            todos.RemoveAll(t => t.Id == id);
            CommitChanges();
        }

        private void CommitChanges()
        {
            Todos data = new Todos();
            data.todos = this.todos;
            dataSource.SaveToFile<Todos>(data, activeTodosPath);
        }

        internal bool returnedCode()
        {
            return dataSource.returnCode == 1;
        }
    }

}
