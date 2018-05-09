using GalaSoft.MvvmLight.Command;
using LogisticApp.Models;
using LogisticApp.Services;
using System;
using System.Windows.Input;

namespace LogisticApp.ViewModels
{
    public class RutasItemViewModel : RutasResult
    {
        #region atributos
        
        private NavigationService navigationService; 
        #endregion



        #region constructor
        public RutasItemViewModel()
        {
            navigationService = new NavigationService();
        } 
        #endregion


        #region Commands
        public ICommand RutaDetailCommand { get { return new RelayCommand(RutaDetail); } }

        private async void RutaDetail()
        {
            var rutaIntemViewModel = new RutasItemViewModel {
                Nombre = Nombre,
                IdRuta = IdRuta,
                Descripcion = Descripcion,
                CodBodega=CodBodega,

            };

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.SetCurrentRuta(rutaIntemViewModel);
            await navigationService.Navigate("IngresoProducto");
        }
        #endregion

    }
}
