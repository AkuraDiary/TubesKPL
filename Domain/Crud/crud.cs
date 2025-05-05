using System;
using System.Collections.Generic;

interface IRepository<T> where T : IEntity
{
    void Add(T item);
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Update(T item);
    void Delete(int id);
}

interface IEntity
{
    int Id { get; set; }
}

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

class TodoItem : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public bool IsSelesai { get; set; }
}

class TodoService
{
    private readonly IRepository<TodoItem> repository;

    public TodoService(IRepository<TodoItem> repo)
    {
        repository = repo;
    }

    public void ViewAll()
    {
        Console.Clear();
        Console.WriteLine("=== Daftar To-Do List Yang sudah ===");

        var todos = repository.GetAll();
        if (!todos.Any())
        {
            Console.WriteLine("Tidak ada to-do item.");
        }
        else
        {
            foreach (var item in todos)
            {
                Console.WriteLine($"{item.Id}. [{(item.IsSelesai ? "X" : " ")}] {item.Title}");
                Console.WriteLine($"   Deskripsi: {item.Description}");
                Console.WriteLine($"   Dibuat: {item.CreatedDate}");
                Console.WriteLine();
            }
        }

        Console.WriteLine("\nTekan Enter untuk Kembali Ke halaman utama...");
        Console.ReadKey();
    }

    public void AddNew()
    {
        Console.Clear();
        Console.WriteLine("=== Tambah To-Do Baru ===");

        Console.Write("Judul: ");
        var title = Console.ReadLine();

        Console.Write("Deskripsi: ");
        var description = Console.ReadLine();

        repository.Add(new TodoItem
        {
            Title = title,
            Description = description
        });

        Console.WriteLine("\nTo-Do berhasil ditambahkan!");
        Console.ReadKey();
    }

    public void Edit()
    {
        Console.Clear();
        Console.WriteLine("=== Edit To-Do ===");

        var id = GetIdFromUser();
        if (id == null) return;

        var item = repository.GetById(id.Value);
        if (item == null)
        {
            Console.WriteLine("To-Do tidak ditemukan!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Judul saat ini: {item.Title}");
        Console.Write("Judul baru (kosongkan jika tidak ingin mengubah): ");
        var newTitle = Console.ReadLine();

        Console.WriteLine($"Deskripsi saat ini: {item.Description}");
        Console.Write("Deskripsi baru (kosongkan jika tidak ingin mengubah): ");
        var newDescription = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newTitle))
            item.Title = newTitle;

        if (!string.IsNullOrWhiteSpace(newDescription))
            item.Description = newDescription;

        repository.Update(item);
        Console.WriteLine("\nTo-Do berhasil diperbarui!");
        Console.ReadKey();
    }

    public void Delete()
    {
        Console.Clear();
        Console.WriteLine("=== Hapus To-Do ===");

        var id = GetIdFromUser();
        if (id == null) return;

        var item = repository.GetById(id.Value);
        if (item == null)
        {
            Console.WriteLine("To-Do tidak ditemukan!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Apakah Anda yakin ingin menghapus: {item.Title}? (Y/N)");
        var confirm = Console.ReadLine().ToUpper();

        if (confirm == "Y")
        {
            repository.Delete(id.Value);
            Console.WriteLine("To-Do berhasil dihapus!");
        }
        else
        {
            Console.WriteLine("Penghapusan dibatalkan.");
        }

        Console.ReadKey();
    }

    public void ToggleSelesai()
    {
        Console.Clear();
        Console.WriteLine("=== Tandai Selesai/Belum Selesai ===");

        var id = GetIdFromUser();
        if (id == null) return;

        var item = repository.GetById(id.Value);
        if (item == null)
        {
            Console.WriteLine("To-Do tidak ditemukan!");
            Console.ReadKey();
            return;
        }

        item.IsSelesai = !item.IsSelesai;
        repository.Update(item);

        Console.WriteLine($"To-Do '{item.Title}' telah ditandai sebagai {(item.IsSelesai ? "Selesai" : "Belum Selesai")}");
        Console.ReadKey();
    }

    private int? GetIdFromUser()
    {
        Console.Write("Masukkan ID To-Do: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID tidak valid!");
            Console.ReadKey();
            return null;
        }
        return id;
    }
}
