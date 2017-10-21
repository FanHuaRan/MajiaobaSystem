using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajiaobaGeoSystem.ViewObject
{
      /// <summary>
      /// 灾害点/隐患点视图模型
      /// 2017/10/21 fhr
      /// </summary>
    public class DisasterPointModel : ObservableObject
    {
        private int disasterPointId;
        private float longitude;
        private float latitude;
        private float elevation;
        private int isDisaster;
        private int disasterTypeId;
        private float incidence;
        private string description;
        private string imgUrl;
        /// <summary>
        /// 编号
        /// </summary>
        public int DisasterPointId
        {
            get
            {
                return disasterPointId;
            }
            set
            {
                if (value != disasterPointId)
                {
                    this.disasterPointId = value;
                    RaisePropertyChanged<int>(() => DisasterPointId);
                }
            }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public float Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                if (value != longitude)
                {
                    this.longitude = value;
                    RaisePropertyChanged<float>(() => Longitude);
                }
            }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public float Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                if (value != latitude)
                {
                    this.latitude = value;
                    RaisePropertyChanged<float>(() => Latitude);
                }
            }
        }
        /// <summary>
        /// 海拔
        /// </summary>
        public float Elevation
        {
            get
            {
                return elevation;
            }
            set
            {
                if (value != elevation)
                {
                    this.elevation = value;
                    RaisePropertyChanged<float>(() => Elevation);
                }
            }
        }
        /// <summary>
        /// 1为灾害点，0为隐患点
        /// </summary>
        public int IsDisaster
        {
            get
            {
                return isDisaster;
            }
            set
            {
                if (value != isDisaster)
                {
                    this.isDisaster = value;
                    RaisePropertyChanged<int>(() => IsDisaster);
                }
            }
        }
        /// <summary>
        /// 灾害类型
        /// </summary>
        public int DisasterTypeId
        {
            get
            {
                return disasterTypeId;
            }
            set
            {
                if (value != disasterTypeId)
                {
                    this.disasterTypeId = value;
                    RaisePropertyChanged<int>(() => DisasterTypeId);
                }
            }
        }
        /// <summary>
        /// 影响范围
        /// </summary>
        public float Incidence
        {
            get
            {
                return incidence;
            }
            set
            {
                if (value != incidence)
                {
                    this.incidence = value;
                    RaisePropertyChanged<float>(() => Incidence);
                }
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    this.description = value;
                    RaisePropertyChanged<string>(() => Description);
                }
            }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl
        {
            get
            {
                return imgUrl;
            }
            set
            {
                if (value != imgUrl)
                {
                    this.imgUrl = value;
                    RaisePropertyChanged<string>(() => ImgUrl);
                }
            }
        }
    }
}
