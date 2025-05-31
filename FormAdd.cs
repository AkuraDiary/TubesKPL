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
        public FormAdd()
        {
            InitializeComponent();
            //String Title = tbtitle;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Title = tbtitle.Text;
            String Description = tbDescription.Text;
            
            //untuk status melalui enum
            cbstatus.DataSource = Enum.GetValues(typeof(Status));

            Status selectedStatus = (Status)cbstatus.SelectedItem;

            TodoItem item = new TodoItem();
            item.TodoStatus = selectedStatus;

            cbstatus.SelectedItem = item.TodoStatus;

            //untuk deadline
            deadline.Value = item.Deadline;

            if (deadline.Value < DateTime.Today)
            {
                MessageBox.Show("Deadline tidak boleh dihari lalu");
                return;
            }

            DI.todoRepo.Add(item);

            InitializeComponent();

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
