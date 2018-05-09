using LogisticApp.Services;
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
	public partial class CodigoManual : ContentPage
	{
        
        public CodigoManual ()
		{
			InitializeComponent ();
		}
        private void EntrycodeChanged(object sender, EventArgs e)
        {
            
            var codigo = Entrycodigo.Text.ToUpper();
            Entrycodigo.Text = codigo;

        }

        
        
    }
}