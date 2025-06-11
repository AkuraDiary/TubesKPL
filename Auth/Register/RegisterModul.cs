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
        RegistrationModule registerModule;
        Navigator navigator;
        public RegisterModul(Navigator navigator, RegistrationModule registerModul)
        {
            InitializeComponent();
            this.navigator = navigator;
            this.registerModule = registerModul;
            tbPassword.PasswordChar = '*';
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
            navigator.NavigateTo(Routes.LOGIN);
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            navigator.NavigateTo(Routes.LOGIN);
        }
    }
}
