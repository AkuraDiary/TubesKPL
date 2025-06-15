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
    public partial class FormAdd: Form
    {
        TodoItem selectedItem = null;
        Navigator navigator;
        public FormAdd(Navigator navigator)
        {
            this.navigator = navigator;
            InitializeComponent();
            Reload();
            
        }

        public void Reload()
        {
            selectedItem = null;
            cbstatus.SelectedItem = Status.Belum.ToString();
            tbtitle.Text = "";
            tbDescription.Text = "";
            deadline.Value = DateTime.Now;
            label1.Text = "Tambahkan TODO";
        }

        public void SetTodo(TodoItem item)
        {
                this.selectedItem = item;
                tbtitle.Text = selectedItem.Title;
                tbDescription.Text = selectedItem.Description;
                deadline.Value = selectedItem.Deadline;
                cbstatus.SelectedItem = selectedItem.Status.ToString();

                label1.Text = "Update TODO";
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            String Title = tbtitle.Text;
            String Description = tbDescription.Text;


            Status selectedStatus;  
            
            if(cbstatus.SelectedItem == null)
            {
                MessageBox.Show("Pilih status yang baru !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Enum.TryParse(cbstatus.SelectedItem.ToString(), out selectedStatus);

            TodoItem item = new TodoItem();
            item.Title = Title;
            item.Description = Description;
            item.Status = selectedStatus;

            
            item.Deadline = deadline.Value;
            

            if (deadline.Value < DateTime.Today)
            {
                MessageBox.Show("Deadline tidak boleh dihari lalu");
                return;
            }

            if (selectedItem != null)
            {
                selectedItem.Title = Title;
                selectedItem.Description = Description;
                selectedItem.Status = selectedStatus;

                selectedItem.Deadline = deadline.Value;
                
                DI.todoRepo.Update(selectedItem);
            }
            else
            {
                DI.todoRepo.Add(item);

            }

            Reload();
            this.Hide();
            navigator.NavigateTo(Routes.MAIN);
           
        }


    }
}
