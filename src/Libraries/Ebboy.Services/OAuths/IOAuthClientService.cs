using Ebboy.Core.Domain.OAuths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ebboy.Services.OAuths
{
    public partial interface IOAuthClientService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="client"></param>
        void Insert(OAuthClient client);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="client"></param>
        void Update(OAuthClient client);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="client"></param>
        void Delete(OAuthClient client);

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        OAuthClient GetById(int id);

        /// <summary>
        /// 根据APPGUID查询
        /// </summary>
        /// <param name="id"></param>
        OAuthClient GetByAppGuid(Guid appGuid);

        /// <summary>
        ///  获取所有房间列表
        /// </summary>
        /// <returns></returns>
        IQueryable<OAuthClient> GetAllList();
    }
}
