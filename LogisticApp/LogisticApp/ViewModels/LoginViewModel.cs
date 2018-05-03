using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LogisticApp.Services;



namespace LogisticApp.ViewModels
{
    public class LoginViewModel
    {
        #region atributos
        private NavigationService navigationService;
        private DialogService dialogService;
        #endregion

        #region Properties
        public string User { get; set; }

        public string Password { get; set; }

        public bool IsRemembered { get; set; }
        #endregion

        #region constructors
        public LoginViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
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
            navigationService.SetMainPage();
            }
        #endregion


    }
}
