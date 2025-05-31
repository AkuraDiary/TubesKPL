using GuiModul.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiModul
{
    public partial class TodoCardItem : UserControl
    {
        TodoItem item;
        public TodoCardItem(TodoItem todoItem)
        {
            item = todoItem;
            InitializeComponent();

            lblTitle.Text = todoItem.Title;
            deskripsi.Text = todoItem.Description;
            
        }

    }
}
