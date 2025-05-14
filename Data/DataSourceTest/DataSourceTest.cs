using AKMJ_TubesKPL.Data.Models;
using AKMJ_TubesKPL.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Data.DataSourceTest
{
  
    [TestClass]
    public class DataSourceTest
    {

        private string testFilePath;
        List<TodoItem> Items { get; set; } = new List<TodoItem>();
        [TestInitialize]
        public void Setup()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "TodoTest");
            Directory.CreateDirectory(tempDir);
            testFilePath = Path.Combine(tempDir, "todos.json");
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [TestMethod]
        public void TestTodoKosong()
        {
            File.WriteAllText(testFilePath, "");

            var dataSource = new TodoDataSource();
            var todos = dataSource.ReadFile(testFilePath);

            Assert.IsNotNull(todos);
            Assert.AreEqual(0, todos.todos.Count);
        }

        [TestMethod]
        public void TestCreateNewTodo()
        {
            var dataSource = new TodoDataSource();
            var todosToSave = new Todos()
            {
                todos = new List<TodoItem>
            {
                new TodoItem {  Title="Bebek", Description = "Goyeng"  }
            }
            };

            dataSource.SaveToFile(todosToSave, testFilePath);
            Assert.AreEqual(1, dataSource.returnCode);

            var loadedTodos = dataSource.ReadFile(testFilePath);
            Assert.IsNotNull(loadedTodos);
            Assert.AreEqual(1, loadedTodos.todos.Count);
            Assert.AreEqual("Goyeng", loadedTodos.todos[0].Description);
        }

        [TestMethod]
        public void TestReadFileFromJsonString()
        {
            
            string jsonString = @"
    {
        ""todos"": [
            {
                ""Id"": 1,
                ""Title"": ""Goyeng Bebek"",
                ""Description"": ""Bebek Goyeng"",
                ""CreatedDate"": ""2024-05-01T10:00:00"",
                ""IsSelesai"": true
            }
        ]
    }";

            File.WriteAllText(testFilePath, jsonString);

            var dataSource = new TodoDataSource();
            var todos = dataSource.ReadFile(testFilePath);

            Assert.IsNotNull(todos);
            
            Assert.IsInstanceOfType(todos, typeof(Todos));

            Assert.AreEqual(1, todos.todos.Count);
            Assert.AreEqual("Goyeng Bebek", todos.todos[0].Title);
            Assert.IsTrue(todos.todos[0].IsSelesai);
        }
    }
}
