using System;
using System.Collections.Generic;
using System.Text;
using LogisticApp.Pages;

namespace LogisticApp.Services
{
    class NavigationService
    {

        internal void SetMainPage()
        {
            App.Current.MainPage = new MasterDetailPage1();
        }
    }
}
