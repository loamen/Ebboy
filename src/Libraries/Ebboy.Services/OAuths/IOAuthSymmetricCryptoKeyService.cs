using Ebboy.Core.Domain.OAuths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.OAuths
{
    public partial interface IOAuthSymmetricCryptoKeyService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="oauthSymmetricCryptoKey"></param>
        void Insert(OAuthSymmetricCryptoKey oauthSymmetricCryptoKey);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="oauthSymmetricCryptoKey"></param>
        void Update(OAuthSymmetricCryptoKey oauthSymmetricCryptoKey);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oauthSymmetricCryptoKey"></param>
        void Delete(OAuthSymmetricCryptoKey oauthSymmetricCryptoKey);

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        OAuthSymmetricCryptoKey GetById(int id);

        /// <summary>
        ///  获取所有房间列表
        /// </summary>
        /// <returns></returns>
        IQueryable<OAuthSymmetricCryptoKey> GetAllList();
    }
}
