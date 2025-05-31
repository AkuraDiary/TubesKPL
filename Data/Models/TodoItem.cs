using GuiModul.Interface;
using System;

namespace GuiModul.Data.Models
{

    public enum Status
    {
        Selesai,
        Belum,
        Tenggat
    }

    // NANCIL
    public class TodoItem : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsSelesai { get; set; }
        public Status TodoStatus { get; set; } = Status.Belum;

        public DateTime Deadline { get; set; } //Deadline


    }
}
