using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiModul.Data.Models
{
   public class Todos
    {
        public List<TodoItem> todos { get; set; } = new List<TodoItem>();
    }
}
