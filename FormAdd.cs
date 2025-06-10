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
        public FormAdd(TodoItem item = null)
        {
            InitializeComponent();
            if (item != null)
            {
                this.selectedItem = item;
                tbtitle.Text = item.Title;
                tbDescription.Text = item.Description;
                deadline.Value = item.Deadline;
                cbstatus.SelectedItem = item.Status;

                label1.Text = "Update TODO";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Title = tbtitle.Text;
            String Description = tbDescription.Text;

            //untuk status melalui enum
            //cbstatus.DataSource = Enum.GetValues(typeof(Status));

            Status selectedStatus;  
            Enum.TryParse(cbstatus.SelectedItem.ToString(), out selectedStatus);

            TodoItem item = new TodoItem();
            item.Title = Title;
            item.Description = Description;
            item.Status = selectedStatus;

            //cbstatus.SelectedItem = item.Status;
            item.Deadline = deadline.Value;
            //untuk deadline
            //deadline.Value = item.Deadline;

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

                //cbstatus.SelectedItem = item.Status;
                selectedItem.Deadline = deadline.Value;
                //untuk deadline
                //deadline.Value = item.Deadline;
                DI.todoRepo.Update(selectedItem);
            }
            else
            {
                DI.todoRepo.Add(item);

            }


            //InitializeComponent();
            this.Hide();
            MenuView menuview = new MenuView();
            menuview.Show();
        }

        private void tbtitle_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
