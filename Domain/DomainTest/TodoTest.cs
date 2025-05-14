using AKMJ_TubesKPL.Data.Models;
using AKMJ_TubesKPL.Interface;
using AKMJ_TubesKPL.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Domain.DomainTest
{
    [TestClass]
    public class TodoTest
    {
        
        [TestMethod]
        public void TestAddTodo()
        {
            IRepository<TodoItem> repo = new TodoRepository(new Data.TodoDataSource());

            var newItem = new TodoItem
            {
                Title = "Matematika matkul suangar cak",
                Description = "Saya suka banget matematika anjay tapi bohong",
                IsSelesai = false
            };

            repo.Add(newItem);

            // untuk menambah dan data akan tersimpan
            var saved = repo.GetById(1);
            Assert.IsNotNull(saved, "Item tidak ditemukan setelah Add()");
            Assert.AreEqual(1, saved.Id);
            Assert.AreEqual("Matematika matkul suangar cak", saved.Title);
            Assert.AreEqual("Saya suka banget matematika anjay tapi bohong", saved.Description);
            Assert.IsFalse(saved.IsSelesai);
        }

        [TestMethod]
        public void TestReadTodoById()
        {
            IRepository<TodoItem> repo = new TodoRepository(new Data.TodoDataSource());

            
            repo.Add(new TodoItem { Title = "Membaca buku avatar", Description = "Buku Avatar ANG EPISODE1", IsSelesai = false });

            //untuk membaca via ID yang sudah tersimpan
            var item = repo.GetById(1);
            Assert.IsNotNull(item, "GetById(1) harus mengembalikan objek");
            Assert.AreEqual(1, item.Id);
            Assert.AreEqual("Membaca buku avatar", item.Title);
        }

        [TestMethod]
        public void TestUpdateTodo()
        {
            IRepository<TodoItem> repo = new TodoRepository(new Data.TodoDataSource());

           
            repo.Add(new TodoItem { Title = "Buku Terbaru 2025", Description = "Bukuku sangat terbaru ter dar der dor", IsSelesai = false });

            // untuk update yang ada pada todo
            var toUpdate = new TodoItem
            {
                Id = 1,
                Title = "Buku Terbaru 2025",
                Description = "Bukuku sangat terbaru dar der dor",
                IsSelesai = true
            };
            repo.Update(toUpdate);

            // untuk menverifikasi apakah sudah masuk
            var updated = repo.GetById(1);
            Assert.IsNotNull(updated);
            Assert.AreEqual("Buku Terbaru 2025", updated.Title);
            Assert.AreEqual("Bukuku sangat terbaru dar der dor", updated.Description);
            Assert.IsTrue(updated.IsSelesai);
        }

        [TestMethod]
        public void TestDeleteTodo()
        {
            IRepository<TodoItem> repo = new TodoRepository(new Data.TodoDataSource());

            
            repo.Add(new TodoItem { Title = "Buku A" });
            repo.Add(new TodoItem { Title = "Buku B" });

            // hapus pertama
            repo.Delete(1);

            // uuntuk verifikasi apakah data tersebut sudah berhasil ke hapus
            Assert.IsNull(repo.GetById(1), "Buku dengan Id=1 harus dihapus");
            Assert.IsNotNull(repo.GetById(2), "Buku dengan Id=2 seharusnya masih ada");
        }
    }
}
