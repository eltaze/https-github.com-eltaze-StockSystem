using Caliburn.Micro;
using StockUI.WPFCore.ViewModels;
using StockUI.WPFCore.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.WPFCore
{
  public  class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            this.DisplayRootViewForAsync(typeof(ShellViewModel), null);
        }
    }
}
