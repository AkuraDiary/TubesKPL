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
            if (todoItem.TodoStatus == Status.Belum)
            {
                lblStatus.Text = "Belum";
                lblStatus.BackColor = Color.Gold;
            }
            else if (todoItem.TodoStatus == Status.Tenggat)
            {
                lblStatus.Text = "Tenggat";
                lblStatus.BackColor = Color.Red;
                lblStatus.ForeColor = Color.White;
            }
            else if (todoItem.TodoStatus == Status.Selesai)
            {
                lblStatus.Text = "Selesai";
                lblStatus.BackColor = Color.Green;
                lblStatus.ForeColor = Color.White;
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            FormCrud formCrud = new FormCrud();
            formCrud.Show();
            this.Hide();
        }
    }
}
