using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LogisticApp.Services;
using System.Net.Http;
using System.Xml.Linq;
using System.Linq;
using System.ComponentModel;

namespace LogisticApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region atributos
        private NavigationService navigationService;
        private DialogService dialogService;
        private WSLservice wSLservice;
        private bool isrunning;


        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public string User { get; set; }

        public string Password { get; set; }

        public bool IsRemembered { get; set; }

        public bool IsRunning {
            set
            {
                if(isrunning != value)
                {
                    isrunning= value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRunning"));
                }
            }
            get
            {
                return isrunning;
            }
        }

        public string Nombre { get; set; }

        public string Correo { get; set; }
        #endregion

        #region constructors
        public LoginViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
            wSLservice = new WSLservice();
        } 
        #endregion

        #region Comandos
        public ICommand LoginCommand { get { return new RelayCommand(Login); } }

            public async void Login()
            {
                    if(string.IsNullOrEmpty(User))
                    {
                        await dialogService.Showmessage("Error", "Debe ingresar usuario");
                        return;
                    }
                    if (string.IsNullOrEmpty(Password))
                    {
                        await dialogService.Showmessage("Error", "Debe ingresar una contraseña");
                        return;
                    }
            IsRunning = true;
            var response = await wSLservice.Login(User, Password);
            IsRunning = false;

            if(!response.IsSuccess)
            {
                await dialogService.Showmessage("Error", response.Messagge);
                return;
            }

            navigationService.SetMainPage();

            
            
            }
        #endregion

    }
}
