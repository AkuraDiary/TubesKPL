using Microsoft.Win32;
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
using GuiModul.Auth.Register;
using GuiModul.Auth.Login;
using static GuiModul.LoginView;
using GuiModul.Data.Models;


namespace GuiModul
{
    public partial class LoginView: Form
    {
        LoginModule loginModule = DI.login;
        Navigator navigator;
        public LoginView(Navigator navigator)
        {
            this.navigator = navigator;
          InitializeComponent();     
       
        }


        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = '*';

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            String username = tbUsername.Text;
            String password = tbPassword.Text;
         
            if (loginModule.Authenticate(username, password, out User user))
            {
                loginModule.saveSession(user);
                // pindah ke halaman utama

                MessageBox.Show("Login Berhasil!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                navigator.NavigateTo(Routes.MAIN);
                
            }

            else
            {
                MessageBox.Show("Username atau password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            navigator.NavigateTo(Routes.MAIN);
        }
    }
}
