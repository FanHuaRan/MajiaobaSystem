/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MajiaobaGeoSystem.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MajiaobaGeoSystem.Service;
using MajiaobaGeoSystem.Repository;
using MajiaobaGeoSystem.DomainModel;
using MajiaobaGeoSystem.Converter;

namespace MajiaobaGeoSystem.ViewModel
{
      /// <summary>
      /// This class contains static references to all the view models in the
      /// application and provides an entry point for the bindings.
      /// <para>
      /// See http://www.mvvmlight.net
      /// </para>
      /// </summary>
      public class ViewModelLocator
      {
            /// <summary>
            /// ViewModelLocator初始化当中实现依赖注入
            /// </summary>
            static ViewModelLocator()
            {
                  ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                  //数据访问组件依赖
                  SimpleIoc.Default.Register<IRepository<DisasterPoint>, DisasterPointRepository>();
                  SimpleIoc.Default.Register<IRepository<DisasterType>, DisasterTypeRepository>();
                  //核心服务组件依赖
                  SimpleIoc.Default.Register<IDataService, DataService>();
                  SimpleIoc.Default.Register<IDisasterPointService, DisasterPointService>();
                  SimpleIoc.Default.Register<IDisasterTypeService, DisasterTypeService>();
                  //模型数据转换器依赖
                  SimpleIoc.Default.Register<DisasterPointModelConverter>();
                  SimpleIoc.Default.Register<DisasterTypeModelConverter>();
                  //viewmodel依赖
                  SimpleIoc.Default.Register<MainViewModel>();
                  SimpleIoc.Default.Register<AppearanceViewModel>();
                  SimpleIoc.Default.Register<MapPageViewModel>();
                  SimpleIoc.Default.Register<DisasterManageViewModel>();
            }

            /// <summary>
            /// Gets the Main property.
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                "CA1822:MarkMembersAsStatic",
                Justification = "This non-static member is needed for data binding purposes.")]
            public MainViewModel Main
            {
                  get
                  {
                        return ServiceLocator.Current.GetInstance<MainViewModel>();
                  }
            }

            /// <summary>
            /// Gets the Appearance property.
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                "CA1822:MarkMembersAsStatic",
                Justification = "This non-static member is needed for data binding purposes.")]
            public AppearanceViewModel Appearance
            {
                  get
                  {
                        return ServiceLocator.Current.GetInstance<AppearanceViewModel>();
                  }
            }
            /// <summary>
            /// Gets the Appearance property.
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                "CA1822:MarkMembersAsStatic",
                Justification = "This non-static member is needed for data binding purposes.")]
            public MapPageViewModel MapPage
            {
                get
                {
                    return ServiceLocator.Current.GetInstance<MapPageViewModel>();
                }
            }
            /// <summary>
            /// Gets the Appearance property.
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                "CA1822:MarkMembersAsStatic",
                Justification = "This non-static member is needed for data binding purposes.")]
            public DisasterManageViewModel DisasterManage
            {
                get
                {
                    return ServiceLocator.Current.GetInstance<DisasterManageViewModel>();
                }
            }

            /// <summary>
            /// Cleans up all the resources.
            /// </summary>
            public static void Cleanup()
            {
            }
      }
}