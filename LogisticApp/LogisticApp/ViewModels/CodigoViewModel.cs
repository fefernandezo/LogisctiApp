using GalaSoft.MvvmLight.Command;
using LogisticApp.Models;
using LogisticApp.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace LogisticApp.ViewModels
{
    public class CodigoViewModel : ProductResult
    {
        #region atributos
        private WSLservice wSLservice;
        private DialogService dialogService;
        private NavigationService navigationService;
        private DataService dataService;

        

        #endregion

        #region Propiedades
        public string Code { get; set; }
        public string Ruta { get; set; }
        public string DescripcionRuta { get; set; }
        public string IdAsignRuta { get; set; }
        public string Cant { get; set; }

        #endregion


        #region constructor
        public CodigoViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
            wSLservice = new WSLservice();
            dataService = new DataService();
            
        }
        #endregion


        #region Commands

       

        public ICommand BuscarCodigoCommand { get { return new RelayCommand(Buscarcod); } }

        public ICommand IngresarCommand { get { return new RelayCommand(IngresarInv); } }

        private async void IngresarInv()
        {
            
            LoginResult user = dataService.GetUser();
            var IngConfirm = await wSLservice.IngProdInvConfirm(IdAsignRuta, user.UserId.ToString(), Codigo, Cant, UnidadMed);
            if(IngConfirm.IsSuccess)
            {
                
            }
            else
            {
                await dialogService.Showmessage("Error", IngConfirm.Messagge);
            }
            TempInvent tempInvent = dataService.GetTempInvent();
            var codigoView = new CodigoViewModel
            {
                Codigo = "",
                Detalle = "",
                UnidadMed = "",
                Ruta = tempInvent.Ruta,
                DescripcionRuta = tempInvent.DescripcionRuta,
                IdAsignRuta = tempInvent.IdAsignRuta.ToString(),

            };
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.SetCurrentCode(codigoView);

            navigationService = new NavigationService();

            navigationService.Navigate("IngresoProducto");

        }

        public async void Scanner(string codigo)
        {
            Code = codigo;

            var Detailcod = await wSLservice.GetProdDetail(Code);

            if (Detailcod.IsSuccess)
            {
                TempInvent tempInvent = dataService.GetTempInvent();
                var codigoView = new CodigoViewModel
                {
                    Codigo = Detailcod.Codigo,
                    Detalle = Detailcod.Detalle,
                    UnidadMed = Detailcod.UnidadMed,
                    Ruta = tempInvent.Ruta,
                    DescripcionRuta = tempInvent.DescripcionRuta,
                    IdAsignRuta = tempInvent.IdAsignRuta.ToString(),

                };
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.SetCurrentCode(codigoView);
                navigationService = new NavigationService();

                navigationService.Navigate("IngProdInventario");
            }
            else
            {
                await dialogService.Showmessage("Error", Detailcod.Messagge);
            }



        }

        public async void Buscarcod()
        {
            
            var Detailcod = await wSLservice.GetProdDetail(Code);

            if (Detailcod.IsSuccess)
            {
                var codigoView = new CodigoViewModel
                {
                    Codigo = Detailcod.Codigo,
                    Detalle = Detailcod.Detalle,
                    UnidadMed = Detailcod.UnidadMed,
                    Ruta=Ruta,
                    DescripcionRuta=DescripcionRuta,
                    IdAsignRuta = IdAsignRuta,

                };
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.SetCurrentCode(codigoView);
                navigationService = new NavigationService();

                navigationService.Navigate("IngProdInventario");
            }
            else
            {
                await dialogService.Showmessage("Error", Detailcod.Messagge);
            }
        }

       
        #endregion
    }
}
