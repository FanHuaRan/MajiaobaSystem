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
    /// DisasterType域模型和DisasterType视图模型转换器
    /// 2017/10/21 fhr
    /// </summary>
    public class DisasterTypeModelConverter
    {
        public DisasterType convert(DisasterTypeModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new DisasterType()
            {
                DisasterTypeId = model.DisasterTypeId,
                TypeName = model.TypeName
            };
        }
        public DisasterTypeModel convert(DisasterType model)
        {
            if (model == null)
            {
                return null;
            }
            return new DisasterTypeModel()
            {
                DisasterTypeId = model.DisasterTypeId,
                TypeName = model.TypeName
            };
        }
    }
}
