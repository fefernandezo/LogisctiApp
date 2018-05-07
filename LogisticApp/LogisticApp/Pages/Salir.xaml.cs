using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LogisticApp.Services;

namespace LogisticApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Salir : ContentPage
	{
		

		

		public Salir ()
		{
			
			InitializeComponent ();

            

			


		}

        private void ButtonClicked(object sender, EventArgs e)
        {
            DataService dataService = new DataService();
            App.CurrentUser.IsRemember = false;
            App.CurrentUser.Password = "";
            dataService.UpdateUser(App.CurrentUser);
            App.Current.MainPage = new Login();
        }

    }
}