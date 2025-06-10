using GuiModul.Interface;
using System;

namespace GuiModul.Data.Models
{

    public enum Status
    {
        Belum,
        Tenggat,
        Selesai
    }

    // NANCIL
    public class TodoItem : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsSelesai { get; set; }
        public Status Status { get; set; } = Status.Belum;

        public DateTime Deadline { get; set; } //Deadline


    }
}
