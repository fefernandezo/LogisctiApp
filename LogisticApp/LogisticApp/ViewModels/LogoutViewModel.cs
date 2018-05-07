using LogisticApp.Pages;
using LogisticApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogisticApp.ViewModels
{
    public class LogoutViewModel
    {
        private DataService dataService;

        public LogoutViewModel()
        {
            dataService = new DataService();

            App.CurrentUser.IsRemember = false;
            dataService.UpdateUser(App.CurrentUser);
            App.Current.MainPage = new Login();

        }
    }
}
