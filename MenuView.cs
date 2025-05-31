using GuiModul.Data.Models;
using System;
using System.Collections;
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
    public partial class MenuView : Form
    {
        public MenuView()
        {
            InitializeComponent();
            populatePenampungList();
        }

        public void populatePenampungList()
        {
            List<TodoItem> listTodo =  new List<TodoItem>();

            TodoItem item1 = new TodoItem();
            item1.Title = "Biji";
            item1.Description = "Description : dakon";
          

            TodoItem item2 = new TodoItem();
            item2.Title = "Biji-biji";
            item2.Description = "Description : Konz";

            listTodo.Add(item1);
            listTodo.Add(item2);

            PenampungList.Controls.Clear();
            foreach (TodoItem item in listTodo)
            {
                PenampungList.Controls.Add(new TodoCardItem(item));
                
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah kamu yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginView loginForm = new LoginView();
                loginForm.Show();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

        }
    }
}
