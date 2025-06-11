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
    public partial class FormCrud: Form
    {
        TodoItem item;
        Navigator navigator;

        public FormCrud(Navigator navigator)
        {
            this.navigator = navigator;
            InitializeComponent();
        }

        public void SetTodo(TodoItem item)
        {
           this.item = item;

            lb1.Text = item.Title;
            label5.Text = item.Description;

            label7.Text = item.Status.ToString();
            if (item.Status == Status.Belum)
            {
                label7.Text = "Belum";
                label7.BackColor = Color.Gold;
            }
            else if (item.Status == Status.Tenggat)
            {
                label7.Text = "Tenggat";
                label7.BackColor = Color.Red;
                label7.ForeColor = Color.White;
            }
            else if (item.Status == Status.Selesai)
            {
                label7.Text = "Selesai";
                label7.BackColor = Color.Green;
                label7.ForeColor = Color.White;
            }
        }



        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuView menuView = new MenuView();
            menuView.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kuning_Click(object sender, EventArgs e)
        {
          

            //MessageBox.Show("Berhasil diupdate!");
            //this.Hide();
           
            FormAdd formAdd = new FormAdd(item);
            formAdd.Show();

            this.Hide(); 
        }

        private void btcs_Click(object sender, EventArgs e)
        {
            
            DI.todoRepo.Update(item);

            MessageBox.Show("Status berhasil diubah menjadi: " + item.Status.ToString());

        
            this.Close();
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var repo = DI.todoRepo;
                repo.Delete(item.Id);
                MessageBox.Show("Item dihapus");

                this.Hide();
                MenuView menuView = new MenuView();
                menuView.Show();
            }
        }
    }
}
