using System.Windows;
using GalaSoft.MvvmLight.Threading;
using MajiaobaGeoSystem.Util;
using MajiaobaGeoSystem.DomainModel;
using System;

namespace MajiaobaGeoSystem
{
      /// <summary>
      /// Interaction logic for App.xaml
      /// </summary>
      public partial class App : Application
      {
            static App()
            {
                  DispatcherHelper.Initialize();
            }
            protected override void OnStartup(StartupEventArgs e)
            {
                
            }
      }
}
