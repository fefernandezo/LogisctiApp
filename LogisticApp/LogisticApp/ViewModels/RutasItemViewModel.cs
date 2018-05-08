using GalaSoft.MvvmLight.Command;
using LogisticApp.Services;
using System;
using System.Windows.Input;

namespace LogisticApp.ViewModels
{
    public class RutasItemViewModel
    {
        #region atributos
        public string Nombre { get; set; }
        public int IdRuta { get; set; }
        public string Descripcion { get; set; }
        public string CodBodega { get; set; }
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
