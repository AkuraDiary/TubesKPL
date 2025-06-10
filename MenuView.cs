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
        LoginModule login = DI.login;
        TodoRepository _todoRepo = DI.todoRepo;
        public MenuView()
        {
            InitializeComponent();
            label1.Text = login.authRepository.loggedInUser.Nama;
            //var dataSource = new TodoDataSource();
            //_todoRepo = new TodoRepository(dataSource);
            //string username = login.authRepository.loggedInUser.Username;
            //_todoRepo.activeTodosPath = $"storage/{username}_todolist.json";
            populatePenampungList();

        }
        
        public void populatePenampungList()
        {
            _todoRepo.GetAll();
            var todos = _todoRepo.todos;
            //if (todos.Count == 0)
            //{
            //    TodoItem item1 = new TodoItem();
            //    item1.Title = "Biji";
            //    item1.Description = "Description : dakon";
            //    item1.TodoStatus = Status.Belum;


            //    TodoItem item2 = new TodoItem();
            //    item2.Title = "Biji-biji";
            //    item2.Description = "Description : Konz";
            //    item2.TodoStatus = Status.Selesai;

            //    TodoItem item3 = new TodoItem();
            //    item3.Title = "Biji-biji";
            //    item3.Description = "Description : Konz";
            //    item3.TodoStatus = Status.Tenggat;

            //    _todoRepo.Add(item1);
            //    _todoRepo.Add(item2);
            //    _todoRepo.Add(item3);
            //}


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
                LoginView loginForm = new LoginView();
                loginForm.Show();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            this.Hide();
            formAdd.Show();
        }

    }
}
