using LogisticApp.Models;
using LogisticApp.Services;
using System.Collections.ObjectModel;

namespace LogisticApp.ViewModels
{
    public class MainViewModel
    {
        #region Atributos

        private DataService dataService;

        private WSLservice wSLservice;

        private DialogService dialogService;

        #endregion

        #region Properties
        public UserViewModel UserLoged { get; set; }

        public ObservableCollection<RutasItemViewModel> Rutas { get; set; }


        public LoginViewModel NewLogin { get; set; }

        


        #endregion

        #region Constructors
        public MainViewModel()
        {
            //Singleton
            instance = this;


            //creacion de observable collection
            Rutas = new ObservableCollection<RutasItemViewModel>();

            //creacion de vistas
            NewLogin = new LoginViewModel();
            dialogService = new DialogService();

            

            //Instance services
            wSLservice = new WSLservice();
            dataService = new DataService();

            UserLoged = new UserViewModel();


           
            
            

        }


        #endregion

        #region Metodos

        public void LoadUser(LoginResult User)
        {

            UserLoged.Fullname = User.Nombre;
        }

        public async void Loadrutas(LoginResult User)
        {

            
            var rutas = await wSLservice.GetRutas(User.UserId);

            Rutas.Clear();


            if (rutas != null)
            {
                foreach (var ruta in rutas)
                {
                    Rutas.Add(new RutasItemViewModel
                    {
                        Nombre = ruta.Nombre,
                        IdRuta = ruta.IdRuta,
                        Descripcion = ruta.Descripcion,
                        CodBodega = ruta.CodBodega,
                    });
                }
            }
            else
            {
                await dialogService.Showmessage("Error", "No hay");
            }



        }

        #endregion

        #region Singleton

        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }
        #endregion

    }
}
