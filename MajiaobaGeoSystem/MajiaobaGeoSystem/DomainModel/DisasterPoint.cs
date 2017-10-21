using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajiaobaGeoSystem.DomainModel
{
      /// <summary>
      /// 灾害点/隐患点
      /// 2017/10/20 fhr
      /// </summary>
      public class DisasterPoint
      {
            /// <summary>
            /// 编号
            /// </summary>
            public int DisasterPointId { get; set; }
            /// <summary>
            /// 经度
            /// </summary>
            public float Longitude { get; set; }
            /// <summary>
            /// 纬度
            /// </summary>
            public float Latitude { get; set; }
            /// <summary>
            /// 海拔
            /// </summary>
            public float Elevation { get; set; }
            /// <summary>
            /// 1为灾害点，0为隐患点
            /// </summary>
            public int IsDisaster { get; set; }
            /// <summary>
            /// 灾害类型
            /// </summary>
            public int DisasterTypeId { get; set; }
            /// <summary>
            /// 影响范围
            /// </summary>
            public float Incidence { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// 图片地址
            /// </summary>
            public string ImgUrl { get; set; }

      }
}
