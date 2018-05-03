using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogisticApp.Pages;
using Xamarin.Forms;
using LogisticApp.Infraestructure;

namespace LogisticApp
{
	public partial class App : Application
	{
		#region Propiedaeds
		public static NavigationPage Navigator { get; internal set; }
		#endregion
		public App ()
		{
			InitializeComponent();

            MainPage = new Login();
		}

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
