﻿
using GuiModul.Data;
using GuiModul.Data.Models;
using GuiModul.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiModul.Repo
{

    // NANCIL
    public class TodoRepository : IRepository<TodoItem>
    {
        public List<TodoItem> todos = new List<TodoItem>();
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
            if(todos.Count != 0)
            {
                nextId = todos.Count;
            }
            // update status where todo is deadline
            todos.ForEach(item => { 
                if(item.Deadline.Day <= DateTime.Now.Day)
                {
                    item.Status = Status.Tenggat;
                }
            });

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
                existing.Status = item.Status;
                existing.IsSelesai = item.IsSelesai;

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


        // Singleton
        private static TodoRepository instance;

        public static TodoRepository getInstance(TodoDataSource datasource)
        {
            if(instance == null)
            {
                instance = new TodoRepository(datasource);
            }
            return instance;
        }
    }

}
