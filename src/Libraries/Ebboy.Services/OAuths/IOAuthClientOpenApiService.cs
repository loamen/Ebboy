using Ebboy.Core.Domain.OAuths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.OAuths
{
    public partial interface IOAuthClientOpenApiService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="room"></param>
        void Insert(OAuthClientOpenApi oauthClientOpenApi);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="room"></param>
        void Update(OAuthClientOpenApi oauthClientOpenApi);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="room"></param>
        void Delete(OAuthClientOpenApi oauthClientOpenApi);

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        OAuthClientOpenApi GetById(int id);

        /// <summary>
        ///  获取所有房间列表
        /// </summary>
        /// <returns></returns>
        IQueryable<OAuthClientOpenApi> GetAllList();
    }
}
