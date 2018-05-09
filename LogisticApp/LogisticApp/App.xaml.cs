using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogisticApp.Pages;
using Xamarin.Forms;
using LogisticApp.Infraestructure;
using LogisticApp.Services;
using LogisticApp.Models;
using LogisticApp.ViewModels;

namespace LogisticApp
{
	public partial class App : Application
	{
		#region Propiedades
		public static NavigationPage Navigator { get; internal set; }
        public static MasterDetailPage1 Master { get; internal set; }
        public static LoginResult CurrentUser { get; internal set; }
        
        
        #endregion

        #region atributos

        private DataService dataService;
        #endregion

        #region Constructor
        public App()
        {
            InitializeComponent();


            dataService = new DataService();
            var User = dataService.GetUser();

            if(User != null && User.IsRemember)
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.LoadUser(User);
                mainViewModel.Loadrutas(User);
                App.CurrentUser = User;
                MainPage = new MasterDetailPage1();
            }
            else
            {
                MainPage = new Login();
            }


            
        }
        #endregion


        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
