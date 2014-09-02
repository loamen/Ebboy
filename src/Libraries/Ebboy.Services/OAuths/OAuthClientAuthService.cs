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
    /// 客服端认证信息token服务类
    /// </summary>
    public class OAuthClientAuthService : IOAuthClientAuthService
    {

        #region Fields
        private readonly IRepository<OAuthClientAuthorization> _oauthClientAuthRepository;
        #endregion

        #region Ctor
        public OAuthClientAuthService(
            IRepository<OAuthClientAuthorization> oauthClientAuthRepository)
           
        {
            _oauthClientAuthRepository = oauthClientAuthRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="oauthClientAuth"></param>
        /// 创 建 者：Loamen.com
        public virtual void Insert(OAuthClientAuthorization oauthClientAuth)
        {
            _oauthClientAuthRepository.Insert(oauthClientAuth);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="oauthClientAuth"></param>
        /// 创 建 者：Loamen.com
        public virtual void Update(OAuthClientAuthorization oauthClientAuth)
        {
            _oauthClientAuthRepository.Update(oauthClientAuth);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oauthClientAuth"></param>
        /// 创 建 者：Loamen.com
        public virtual void Delete(OAuthClientAuthorization oauthClientAuth)
        {
            _oauthClientAuthRepository.Delete(oauthClientAuth);
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="message"></param>
        /// 创 建 者：Loamen.com
        public virtual OAuthClientAuthorization GetById(int id)
        {
            return _oauthClientAuthRepository.GetById(id);
        }

        /// <summary>
        /// 根据Token获取实体
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual OAuthClientAuthorization GetByToken(string token)
        {
            return GetAllList().FirstOrDefault(c => c.Token == token);
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual IQueryable<OAuthClientAuthorization> GetAllList()
        {
            return _oauthClientAuthRepository.Table;
        }

        #endregion 
    }
}
