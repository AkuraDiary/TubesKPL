using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GuiModul
{
    public partial class LoginView: Form
    {
        public LoginView()
        {
          InitializeComponent();
            
            
           
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void lbUsername_Click(object sender, EventArgs e)
        {

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbPassword_Click(object sender, EventArgs e)
        {

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = '*';

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            String username = tbUsername.Text;
            String password = tbPassword.Text;

            if(username == "admin" && password == "admin123")
            {
                MessageBox.Show("Login berhasil!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Username atau password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }
    }
}
