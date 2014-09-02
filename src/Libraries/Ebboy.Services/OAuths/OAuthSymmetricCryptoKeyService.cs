using Ebboy.Core.Data;
using Ebboy.Core.Domain.OAuths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.OAuths
{
    public partial class OAuthSymmetricCryptoKeyService : IOAuthSymmetricCryptoKeyService
    {
        #region Fields
        private readonly IRepository<OAuthSymmetricCryptoKey> _oauthSymmetricCryptoKeyRepository;
        #endregion

        #region Ctor
        public OAuthSymmetricCryptoKeyService(
            IRepository<OAuthSymmetricCryptoKey> oauthSymmetricCryptoKeyRepository)
           
        {
            _oauthSymmetricCryptoKeyRepository = oauthSymmetricCryptoKeyRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="oauthSymmetricCryptoKey"></param>
        /// 创 建 者：Loamen.com
        public virtual void Insert(OAuthSymmetricCryptoKey oauthSymmetricCryptoKey)
        {
            _oauthSymmetricCryptoKeyRepository.Insert(oauthSymmetricCryptoKey);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="oauthSymmetricCryptoKey"></param>
        /// 创 建 者：Loamen.com
        public virtual void Update(OAuthSymmetricCryptoKey oauthSymmetricCryptoKey)
        {
            _oauthSymmetricCryptoKeyRepository.Update(oauthSymmetricCryptoKey);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oauthSymmetricCryptoKey"></param>
        /// 创 建 者：Loamen.com
        public virtual void Delete(OAuthSymmetricCryptoKey oauthSymmetricCryptoKey)
        {
            _oauthSymmetricCryptoKeyRepository.Delete(oauthSymmetricCryptoKey);
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="message"></param>
        /// 创 建 者：Loamen.com
        public virtual OAuthSymmetricCryptoKey GetById(int id)
        {
            return _oauthSymmetricCryptoKeyRepository.GetById(id);
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual IQueryable<OAuthSymmetricCryptoKey> GetAllList()
        {
            return _oauthSymmetricCryptoKeyRepository.Table;
        }

        #endregion 
    }
}
