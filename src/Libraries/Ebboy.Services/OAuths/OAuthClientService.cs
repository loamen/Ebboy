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
    /// 认证客户端信息服务类
    /// </summary>
    public partial class OAuthClientService : IOAuthClientService
    {
        #region Fields
        private readonly IRepository<OAuthClient> _oauthClientRepository;
        #endregion

        #region Ctor
        public OAuthClientService(
            IRepository<OAuthClient> oauthClientRepository)
           
        {
            _oauthClientRepository = oauthClientRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="client"></param>
        /// 创 建 者：Loamen.com
        public virtual void Insert(OAuthClient client)
        {
            _oauthClientRepository.Insert(client);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="client"></param>
        /// 创 建 者：Loamen.com
        public virtual void Update(OAuthClient client)
        {
            _oauthClientRepository.Update(client);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="client"></param>
        /// 创 建 者：Loamen.com
        public virtual void Delete(OAuthClient client)
        {
            _oauthClientRepository.Delete(client);
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="message"></param>
        /// 创 建 者：Loamen.com
        public virtual OAuthClient GetById(int id)
        {
            return _oauthClientRepository.GetById(id);
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual IQueryable<OAuthClient> GetAllList()
        {
            return _oauthClientRepository.Table;
        }

        /// <summary>
        /// 根据APPGUID查询
        /// </summary>
        /// <param name="appGuid"></param>
        /// <returns></returns>
        public virtual OAuthClient GetByAppGuid(Guid appGuid)
        {
            return GetAllList().Where(c => c.AppGuid == appGuid).FirstOrDefault();
        }
        #endregion 
    }
}
