using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MajiaobaGeoSystem.Pages
{
    /// <summary>
    /// MapPage.xaml 的交互逻辑
    /// </summary>
    public partial class MapPage : UserControl
    {
        public MapPage()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           await LoadShapefile("shp\\公路网.shp");
        }
        private async Task LoadShapefile(string path)
        {
            try
            {
                // open shapefile table
                var shapefile = await ShapefileTable.OpenAsync(path);
                // create feature layer based on the shapefile
                var flayer = new FeatureLayer(shapefile)
                {
                    ID = shapefile.Name,
                    DisplayName = path,
                };
                // Add the feature layer to the map
                mainMap.Map.Layers.Add(flayer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating feature layer: " + ex.Message, "Sample Error");
            }
        }
    }
}
