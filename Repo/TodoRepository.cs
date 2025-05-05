using AKMJ_TubesKPL.Repo.Interface;
using AKMJ_TubesKPL.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Repo
{

    // NANCIL
    class TodoRepository : IRepository<TodoItem>
    {
        private List<TodoItem> todos = new List<TodoItem>();
        private int nextId = 1;

        public void Add(TodoItem item)
        {
            item.Id = nextId++;
            todos.Add(item);
        }

        public IEnumerable<TodoItem> GetAll()
        {
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
            }
        }

        public void Delete(int id)
        {
            todos.RemoveAll(t => t.Id == id);
        }
    }

}
