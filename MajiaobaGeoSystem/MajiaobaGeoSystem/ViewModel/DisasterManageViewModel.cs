using GalaSoft.MvvmLight;
using MajiaobaGeoSystem.Converter;
using MajiaobaGeoSystem.Service;
using MajiaobaGeoSystem.ViewObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MajiaobaGeoSystem.ViewModel
{
    /// <summary>
    /// 灾害数据管理ViewModel
    /// 2017/10/21 fhr
    /// </summary>
    public class DisasterManageViewModel : ViewModelBase
    {
        private readonly IDisasterPointService disasterPointService;
        private readonly IDisasterTypeService disasterTypeService;
        private readonly DisasterPointModelConverter disasterPointModelConverter;
        private readonly DisasterTypeModelConverter disasterTypeModelConverter;

        private ObservableCollection<DisasterPointModel> disasterPointModels;

        private ObservableCollection<DisasterTypeModel> disasterTypeModels;

        private DisasterPointModel selectDisasterTypeModel;

        public DisasterPointModel SelectDisasterTypeModel
        {

            get
            {
                return selectDisasterTypeModel;
            }
            set
            {
                Set(ref selectDisasterTypeModel, value);
            }
        }

        public ObservableCollection<DisasterPointModel> DisasterPointModels
        {
            get
            {
                return disasterPointModels;
            }
            set
            {
                Set(ref disasterPointModels, value);
            }
        }

        public ObservableCollection<DisasterTypeModel> DisasterTypeModels
        {
            get
            {
                return disasterTypeModels;
            }
            set
            {
                Set(ref disasterTypeModels, value);
            }
        }


        public DisasterManageViewModel(IDisasterPointService disasterPointService,
                                       IDisasterTypeService disasterTypeService,
                                       DisasterPointModelConverter disasterPointModelConverter,
                                       DisasterTypeModelConverter disasterTypeModelConverter)
        {
            this.disasterPointService = disasterPointService;
            this.disasterTypeService = disasterTypeService;
            this.disasterPointModelConverter = disasterPointModelConverter;
            this.disasterTypeModelConverter = disasterTypeModelConverter;
            disasterTypeService.FindAll((objs, err) =>
            {
                //if (err != null)
                //{
                //    MessageBox.Show("数据库连接出错");
                //}
                //else
                //{
                    DisasterTypeModels = new ObservableCollection<DisasterTypeModel>();
                    foreach (var obj in objs)
                    {
                        DisasterTypeModels.Add(disasterTypeModelConverter.convert(obj));
                    }
                //}
            });

            disasterPointService.FindAll((objs, err) =>
            {
                //if (err != null)
                //{
                //    MessageBox.Show("数据库连接出错");
                //}
                //else
                //{
                    DisasterPointModels = new ObservableCollection<DisasterPointModel>();
                    foreach (var obj in objs)
                    {
                        disasterPointModels.Add(disasterPointModelConverter.convert(obj));
                    }
                //}
            });
        }
    }
}
