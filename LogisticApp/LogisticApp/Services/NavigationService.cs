using System;
using System.Collections.Generic;
using System.Text;
using LogisticApp.Models;
using LogisticApp.Pages;

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
    }
}
