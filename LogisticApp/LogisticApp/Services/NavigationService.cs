using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LogisticApp.Models;
using LogisticApp.Pages;
using LogisticApp.ViewModels;

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

        public async Task Navigate(string pageName)
        {
           switch(pageName)
            {
                case "IngresoProducto":
                    await App.Navigator.PushAsync(new IngresoProducto());
                    break;
            }
        }
    }
}
