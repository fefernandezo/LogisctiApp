using LogisticApp.Services;
using LogisticApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace LogisticApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IngresoProducto : ContentPage
	{
		NavigationService navigationService;
        CodigoViewModel codigoViewModel;
		public IngresoProducto ()
		{
			InitializeComponent ();
		}

		private void BtnManual_clicked(object sender, EventArgs e)
		{
			navigationService = new NavigationService();

			navigationService.Navigate("CodigoManual");
            
			
		}

       

        private async void BtnScanner_clicked(object sender, EventArgs e)
        {
            codigoViewModel = new CodigoViewModel();

            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                //stop scanning
                scanPage.IsScanning = false;

                //pop the page and show result
                Device.BeginInvokeOnMainThread(async() =>
                {
                    
                    codigoViewModel.Scanner(result.Text);
                    await Navigation.PopModalAsync();

                });
            };

            //navega hacia la scannerpage
            await Navigation.PushModalAsync(scanPage);
        }
    }
}