using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using MajiaobaGeoSystem.ViewModel;

namespace MajiaobaGeoSystem
{
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : ModernWindow
      {
            //      [ComVisible(true)]
            //      public delegate void EventHandler(object sender, EventArgs e);

            /// <summary>
            /// Initializes a new instance of the MainWindow class.
            /// </summary>
            public MainWindow()
            {
                  InitializeComponent();
                  //this.
                  //Closed += (sender,e) => ViewModelLocator.Cleanup();
            }
      }
}