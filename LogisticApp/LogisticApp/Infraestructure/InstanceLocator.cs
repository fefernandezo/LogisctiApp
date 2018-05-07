
using LogisticApp.ViewModels;

namespace LogisticApp.Infraestructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InicioViewModel Inicio { get; set; }
        

        public InstanceLocator()
        {
            Main = new MainViewModel();

            Inicio = new InicioViewModel();

           
        }
    }
}
