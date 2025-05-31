using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GuiModul.LoginView;
using GuiModul;

namespace GuiModul.Auth.Register
{
    public partial class RegisterModul: Form
    {
        RegistrationModule registerModule = DI.regis;
        public RegisterModul()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '*';
        }

        private void lbRegister_Click(object sender, EventArgs e)
        {

        }

        private void lbName_Click(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
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
            String name = tbName.Text;
            String username = tbUsername.Text;
            String password = tbPassword.Text;

            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Semua field harus di isi.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (registerModule.RegisterUser(name, username, password))
            {
                Console.WriteLine();
                Console.WriteLine("Pendaftaran berhasil!");
            }

            MessageBox.Show("Registrasi berhasil! Silakan login.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            LoginView loginForm = new LoginView();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
