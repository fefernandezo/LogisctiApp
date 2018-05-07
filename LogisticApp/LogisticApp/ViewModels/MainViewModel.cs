using LogisticApp.Services;
using System.Collections.ObjectModel;

namespace LogisticApp.ViewModels
{
    public class MainViewModel
    {
        #region Atributos
        
       
        #endregion

        #region Properties

        

        public LoginViewModel NewLogin { get; set; }

        


        #endregion

        #region Constructors
        public MainViewModel()
        {
         
            //creacion de vistas
            NewLogin = new LoginViewModel();
            
 
        }


        #endregion

        #region Metodos
        

       
        #endregion

    }
}
