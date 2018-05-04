using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApp.Services
{
    public class DialogService
    {
        public async Task Showmessage(string Title, string Message)
        {
            await App.Current.MainPage.DisplayAlert(Title, Message, "Aceptar");
        }
    }
}
