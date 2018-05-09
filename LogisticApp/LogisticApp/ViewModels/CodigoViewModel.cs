using GalaSoft.MvvmLight.Command;
using LogisticApp.Models;
using LogisticApp.Services;
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
        

        #endregion

        #region Propiedades
        public string Code { get; set; }
        public string Ruta { get; set; }
        public string DescripcionRuta { get; set; }

        #endregion


        #region constructor
        public CodigoViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
            wSLservice = new WSLservice();
            
        }
        #endregion


        #region Commands

       

        public ICommand BuscarCodigoCommand { get { return new RelayCommand(Buscarcod); } }

       

        public async void Scanner(string codigo)
        {
            Code = codigo;

            var Detailcod = await wSLservice.GetProdDetail(Code);

            if (Detailcod.IsSuccess)
            {
                var codigoView = new CodigoViewModel
                {
                    Codigo = Detailcod.Codigo,
                    Detalle = Detailcod.Detalle,
                    UnidadMed = Detailcod.UnidadMed,
                    Ruta = Ruta,
                    DescripcionRuta = DescripcionRuta,

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
