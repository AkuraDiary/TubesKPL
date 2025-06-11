using GuiModul.Auth.Login;
using GuiModul.Data;
using GuiModul.Data.Models;
using GuiModul.Interface;
using GuiModul.Repo;
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
        LoginModule login; 
        TodoRepository _todoRepo;
        Navigator navigator;
        public MenuView(LoginModule login, TodoRepository todo, Navigator navigator)
        {
            this.login = login;
            this._todoRepo = todo;
            this.navigator = navigator;
            InitializeComponent();
            Reload();

        }

        public void Reload()
        {
            if (login.authRepository.loggedInUser != null)
            {
                label1.Text = login.authRepository.loggedInUser.Nama;
            }
          
            populatePenampungList();
        }
        
        public void populatePenampungList()
        {
            _todoRepo.GetAll();
            var todos = _todoRepo.todos;


            PenampungList.Controls.Clear();
            foreach (TodoItem item in todos)
            {
                PenampungList.Controls.Add(new TodoCardItem(item));
                
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah kamu yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DI.login.Deauthenticate();
                this.Hide();
                navigator.NavigateTo(Routes.LOGIN);
                //LoginView loginForm = new LoginView();
                //loginForm.Show();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            //login.Deauthenticate();
            navigator.NavigateTo(Routes.ADD);
            //FormAdd formAdd = new FormAdd();
            //this.Hide();
            //formAdd.Show();
        }

    }
}
