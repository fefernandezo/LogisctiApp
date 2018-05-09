﻿using LogisticApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LogisticApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IngresoProducto : ContentPage
	{
		NavigationService navigationService;
		public IngresoProducto ()
		{
			InitializeComponent ();
		}

		private void BtnManual_clicked(object sender, EventArgs e)
		{
			navigationService = new NavigationService();

			navigationService.Navigate("CodigoManual");
			
		}
	}
}