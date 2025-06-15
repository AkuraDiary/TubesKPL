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
            if (todoItem.Status == Status.Belum)
            {
                lblStatus.Text = "Belum";
                lblStatus.BackColor = Color.Gold;
            }
            else if (todoItem.Status == Status.Tenggat)
            {
                lblStatus.Text = "Tenggat";
                lblStatus.BackColor = Color.Red;
                lblStatus.ForeColor = Color.White;
            }
            else if (todoItem.Status == Status.Selesai)
            {
                lblStatus.Text = "Selesai";
                lblStatus.BackColor = Color.Green;
                lblStatus.ForeColor = Color.White;
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            DI.navigator.NavigateToDetail (item);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            DI.navigator.NavigateToDetail(item);
        }
    }
}
