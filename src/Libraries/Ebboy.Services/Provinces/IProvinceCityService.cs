using Ebboy.Core.Domain.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.Regions
{
    public partial interface IProvinceCityService
    {
        /// <summary>
        /// 根据区域编号获取其所有子级区域列表
        /// </summary>
        /// <param name="parentId">区域父级编号</param>
        /// <returns></returns>
        List<ProvinceCity> GetRegionListByParentId(Guid? parentId);

         /// <summary>
        /// 根据地区编号获取层级地区列表
        /// </summary>
        /// <param name="guid">地区编号</param>
        /// <returns>层级地区列表</returns>
        List<ProvinceCity> GetRegionLayerListByRegionId(Guid guid);
    }
}
