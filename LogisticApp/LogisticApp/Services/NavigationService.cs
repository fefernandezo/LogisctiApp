using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LogisticApp.Models;
using LogisticApp.Pages;
using LogisticApp.ViewModels;
using Xamarin.Forms;

namespace LogisticApp.Services
{
    public class NavigationService
    {
        private DataService dataService;


        public NavigationService()
        {
            dataService = new DataService();
        }

        internal void SetMainPage(LoginResult response)
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.LoadUser(response);
            mainViewModel.Loadrutas(response);
            App.CurrentUser = response;
            App.Current.MainPage = new MasterDetailPage1();
            
        }

        public void Logout()
        {
            App.CurrentUser.IsRemember = false;
            dataService.UpdateUser(App.CurrentUser);
            App.Current.MainPage = new Login();


        }

        public LoginResult GetCurrentUser()
        {
            return App.CurrentUser;
        }

        public void Navigate(string pageName)
        {
            App.Master.IsPresented = false;

           switch (pageName)
            {
                case "IngresoProducto":
                    var page = (Page)Activator.CreateInstance(typeof(IngresoProducto));
                    App.Master.Detail = new NavigationPage(page);
                    break;
                case "CodigoManual":
                    var page2 = (Page)Activator.CreateInstance(typeof(CodigoManual));
                    App.Master.Detail = new NavigationPage(page2);
                    break;
                case "IngProdInventario":
                    var page3 = (Page)Activator.CreateInstance(typeof(IngProdInventario));
                    App.Master.Detail = new NavigationPage(page3);
                    break;
                    
                default:
                    break;
            }

        }
    }
}
