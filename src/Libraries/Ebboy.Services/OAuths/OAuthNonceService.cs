using Ebboy.Core.Data;
using Ebboy.Core.Domain.OAuths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.OAuths
{
    /// <summary>
    /// OAuth 加密随机数
    /// </summary>
    public partial class OAuthNonceService : IOAuthNonceService
    {
        #region Fields
        private readonly IRepository<OAuthNonce> _oauthNonceRepository;
        #endregion

        #region Ctor
        public OAuthNonceService(
            IRepository<OAuthNonce> oauthNonceRepository)
           
        {
            _oauthNonceRepository = oauthNonceRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="nonce"></param>
        /// 创 建 者：Loamen.com
        public virtual void Insert(OAuthNonce nonce)
        {
            _oauthNonceRepository.Insert(nonce);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="nonce"></param>
        /// 创 建 者：Loamen.com
        public virtual void Update(OAuthNonce nonce)
        {
            _oauthNonceRepository.Update(nonce);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="nonce"></param>
        /// 创 建 者：Loamen.com
        public virtual void Delete(OAuthNonce nonce)
        {
            _oauthNonceRepository.Delete(nonce);
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="message"></param>
        /// 创 建 者：Loamen.com
        public virtual OAuthNonce GetById(int id)
        {
            return _oauthNonceRepository.GetById(id);
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual IQueryable<OAuthNonce> GetAllList()
        {
            return _oauthNonceRepository.Table;
        }

        #endregion 
    }
}
