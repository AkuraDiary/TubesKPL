using AKMJ_TubesKPL.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Repo.Models
{

    // NANCIL
    class TodoItem : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsSelesai { get; set; }
    }
}
