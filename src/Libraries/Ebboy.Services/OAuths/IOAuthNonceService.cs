using Ebboy.Core.Domain.OAuths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.OAuths
{
    public partial interface IOAuthNonceService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="nonce"></param>
        void Insert(OAuthNonce nonce);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="nonce"></param>
        void Update(OAuthNonce nonce);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="nonce"></param>
        void Delete(OAuthNonce nonce);

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        OAuthNonce GetById(int id);

        /// <summary>
        ///  获取所有房间列表
        /// </summary>
        /// <returns></returns>
        IQueryable<OAuthNonce> GetAllList();
    }
}
