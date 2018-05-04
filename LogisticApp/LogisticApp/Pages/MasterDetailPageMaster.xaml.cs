using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LogisticApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageMenuItem> MenuItems { get; set; }
            
            public MasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageMenuItem>(new[]
                {
                    new MasterDetailPageMenuItem { Id = 0,
                        Title = "Inicio",
                        Icon = "LogoGlasser.png",
                        TargetType = typeof(MasterDetailPageDetail)
                    },
                    new MasterDetailPageMenuItem { Id = 1,
                        Title = "Logística",
                        Icon = "logistic.png",
                        TargetType = typeof(MainLogistica)
                    },
                    new MasterDetailPageMenuItem { Id = 2,
                        Title = "Inventario",
                        Icon = "inventory.png",
                        TargetType = typeof(MainInventario)
                    },
                    new MasterDetailPageMenuItem { Id = 2,
                        Title = "Salir",
                        Icon = "cerrar.png",
                        TargetType = typeof(Salir)
                    },


                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}