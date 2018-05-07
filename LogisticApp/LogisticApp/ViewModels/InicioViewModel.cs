using LogisticApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LogisticApp.ViewModels
{
    public class InicioViewModel
    {
        #region Atributos

        private DataService dataService;

        private WSLservice wSLservice;

        #endregion

        #region Propiedades
        public UserViewModel UserLoged { get; set; }

        public ObservableCollection<RutasItemViewModel> Rutas { get; set; }


        #endregion

        #region Constructor
        public InicioViewModel()
        {
            //creacion de observable collection
            Rutas = new ObservableCollection<RutasItemViewModel>();

            //Instance services
            wSLservice = new WSLservice();
            dataService = new DataService();

            UserLoged = new UserViewModel();


            //cargar datos
            LoadUser();
            Loadrutas();
        }
        #endregion

        #region Metodos
        public void LoadUser()
        {
            
            UserLoged.Fullname = App.CurrentUser.Nombre;
        }

        public async void Loadrutas()
        {
            //var user = dataService.GetUser();
            var rutas = await wSLservice.GetRutas(App.CurrentUser.UserId);

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



        }
        #endregion
    }
}
