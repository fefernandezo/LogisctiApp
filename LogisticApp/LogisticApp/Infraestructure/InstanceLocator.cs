
using LogisticApp.ViewModels;

namespace LogisticApp.Infraestructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

       
        

        public InstanceLocator()
        {
            Main = new MainViewModel();

            

           
        }
    }
}
