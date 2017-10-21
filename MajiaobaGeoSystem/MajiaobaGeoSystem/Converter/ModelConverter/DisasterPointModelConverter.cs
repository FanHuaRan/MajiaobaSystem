using MajiaobaGeoSystem.DomainModel;
using MajiaobaGeoSystem.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajiaobaGeoSystem.Converter
{
    /// <summary>
    /// DisasterPoint域模型和DisasterPoint视图模型转换器
    /// 2017/10/21 fhr
    /// </summary>
    public class DisasterPointModelConverter
    {
        public DisasterPoint convert(DisasterPointModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new DisasterPoint()
            {
                DisasterPointId = model.DisasterPointId,
                Longitude = model.Longitude,
                Latitude = model.Latitude,
                Elevation = model.Elevation,
                IsDisaster = model.IsDisaster,
                DisasterTypeId = model.DisasterTypeId,
                Incidence = model.Incidence,
                Description = model.Description,
                ImgUrl = model.ImgUrl
            };
        }
        public DisasterPointModel convert(DisasterPoint model)
        {
            if (model == null)
            {
                return null;
            }
            return new DisasterPointModel()
            {
                DisasterPointId = model.DisasterPointId,
                Longitude = model.Longitude,
                Latitude = model.Latitude,
                Elevation = model.Elevation,
                IsDisaster = model.IsDisaster,
                DisasterTypeId = model.DisasterTypeId,
                Incidence = model.Incidence,
                Description = model.Description,
                ImgUrl = model.ImgUrl
            };
        }
    }
}
