using Ebboy.Core.Data;
using Ebboy.Core.Domain.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.Regions
{
    public partial class ProvinceCityService : IProvinceCityService
    {
        #region Fileds
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IRepository<ProvinceCity> _regionRepository;
        #endregion

        public ProvinceCityService(IRepository<ProvinceCity> regionRepository)
        {
            _regionRepository = regionRepository;
        }

        /// <summary>
        /// 根据区域编号获取其所有子级区域列表
        /// </summary>
        /// <param name="parentId">区域父级编号</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual List<ProvinceCity> GetRegionListByParentId(Guid? parentId)
        {
            return _regionRepository.Table.Where(r => r.ParentId == parentId).OrderBy(r => r.Sort).ToList();
        }

        /// <summary>
        /// 根据地区编号获取层级地区列表
        /// </summary>
        /// <param name="guid">地区编号</param>
        /// <returns>层级地区列表</returns>
        /// 创 建 者：Loamen.com
        public List<ProvinceCity> GetRegionLayerListByRegionId(Guid guid)
        {
            var region = _regionRepository.Table;
            //构造查询条件
            var q = region.Where(m => m.RegionId == guid);

            string layer = q.Select(r=>r.Layer).FirstOrDefault();

            List<Guid> ids = layer.Split(',').Select(m => new Guid(m)).ToList();

            var query = region.Where(m => (ids.Contains(m.ParentId ?? Guid.Empty) || m.ParentId == null));
            query = query.OrderBy(r => r.Sort);

            return query.ToList();
        }
    }
}
