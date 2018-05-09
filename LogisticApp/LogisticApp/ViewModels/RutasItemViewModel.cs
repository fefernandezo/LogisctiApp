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
        public CodigoViewModel codigoViewModel;
        #endregion



        #region constructor
        public RutasItemViewModel()
        {
            navigationService = new NavigationService();
            
        } 
        #endregion


        #region Commands
        public ICommand RutaDetailCommand { get { return new RelayCommand(RutaDetail); } }

       

        private  void RutaDetail()
        {
            var rutaIntemViewModel = new RutasItemViewModel {
                Nombre = Nombre,
                IdRuta = IdRuta,
                Descripcion = Descripcion,
                CodBodega=CodBodega,

            };
            var codigoViewModel = new CodigoViewModel {
                Ruta = Nombre,
                DescripcionRuta=Descripcion,
                Code = "",
            };
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.SetCurrentCode(codigoViewModel);
            mainViewModel.SetCurrentRuta(rutaIntemViewModel);
             navigationService.Navigate("IngresoProducto");
        }
        #endregion

    }
}
