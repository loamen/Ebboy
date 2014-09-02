using Ebboy.Core.Domain.OAuths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.OAuths
{
    public partial interface IOAuthClientAuthService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="room"></param>
        void Insert(OAuthClientAuthorization oauthClientAuth);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="room"></param>
        void Update(OAuthClientAuthorization oauthClientAuth);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="room"></param>
        void Delete(OAuthClientAuthorization oauthClientAuth);

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        OAuthClientAuthorization GetById(int id);

        /// <summary>
        /// 根据Token获取实体
        /// </summary>
        /// <param name="id"></param>
        OAuthClientAuthorization GetByToken(string token);

        /// <summary>
        ///  获取所有房间列表
        /// </summary>
        /// <returns></returns>
        IQueryable<OAuthClientAuthorization> GetAllList();
    }
}
