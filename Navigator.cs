using GuiModul.Data.Models;
using LoginLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiModul
{
   public enum Routes
    {
        LOGIN,
        REGISTER,
        MAIN,
        DETAIL,
        ADD,
        UPDATE,
    }
    public class Navigator
    {
        public Routes activeRoute = Routes.LOGIN;


        public void NavigateTo(Routes route)
        {
            this.activeRoute = route;
            evaluateRoute();
        }

        TodoItem itemParam;
        public void NavigateToDetail(TodoItem item)
        {
            this.activeRoute = Routes.DETAIL;
            this.itemParam = item;
            evaluateRoute();
        }

        public void NavigateToUpdate(TodoItem item)
        {
            this.activeRoute = Routes.UPDATE;
            this.itemParam = item;
            evaluateRoute();

        }

        public Form InitialRoute()
        {
            return DI.loginView;
        }
        public void evaluateRoute()
        {
            switch (activeRoute)
            {
                case Routes.LOGIN:
                    DI.loginView.Show();
                    break;
                case Routes.REGISTER:
                    DI.registerView.Show();
                    break;
                case Routes.MAIN:
                    DI.menuView.Show();
                    DI.menuView.Reload();
                    break;
                case Routes.DETAIL:
                    if(itemParam == null)
                    {
                        break;
                    }
                    DI.formCrud.Show();
                    DI.formCrud.SetTodo(itemParam);
                   
                    break;
                case Routes.ADD:
                    DI.formAdd.Show();
                    DI.formAdd.Reload();
                    break;
                case Routes.UPDATE:
                    if (itemParam == null)
                    {
                        break;
                    }
                    DI.formAdd.Show();
                    DI.formAdd.SetTodo(itemParam);
                    break;

            }
        }

        private static Navigator instance; 
        public static Navigator getInstance()
        {
            if(instance == null)
            {
                instance = new Navigator();
            }
            return instance;
        }
    }
}
