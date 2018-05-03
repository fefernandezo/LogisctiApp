using System;
using System.Collections.Generic;
using System.Text;

namespace LogisticApp.ViewModels
{
    public class MainViewModel
    {
        #region Properties

        public LoginViewModel NewLogin { get; set; }

        #endregion

        #region Constructors
        public MainViewModel()
        {
            NewLogin = new LoginViewModel();
        }
        #endregion

    }
}
