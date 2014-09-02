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
    /// 认证客户端的开放接口服务
    /// </summary>
    public partial class OAuthClientOpenApiService : IOAuthClientOpenApiService
    {
        #region Fields
        private readonly IRepository<OAuthClientOpenApi> _oauthClientOpenApiRepository;
        #endregion

        #region Ctor
        public OAuthClientOpenApiService(
            IRepository<OAuthClientOpenApi> oauthClientOpenApiRepository)
           
        {
            _oauthClientOpenApiRepository = oauthClientOpenApiRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="oauthClientOpenApi"></param>
        /// 创 建 者：Loamen.com
        public virtual void Insert(OAuthClientOpenApi oauthClientOpenApi)
        {
            _oauthClientOpenApiRepository.Insert(oauthClientOpenApi);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="oauthClientOpenApi"></param>
        /// 创 建 者：Loamen.com
        public virtual void Update(OAuthClientOpenApi oauthClientOpenApi)
        {
            _oauthClientOpenApiRepository.Update(oauthClientOpenApi);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oauthClientOpenApi"></param>
        /// 创 建 者：Loamen.com
        public virtual void Delete(OAuthClientOpenApi oauthClientOpenApi)
        {
            _oauthClientOpenApiRepository.Delete(oauthClientOpenApi);
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="message"></param>
        /// 创 建 者：Loamen.com
        public virtual OAuthClientOpenApi GetById(int id)
        {
            return _oauthClientOpenApiRepository.GetById(id);
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual IQueryable<OAuthClientOpenApi> GetAllList()
        {
            return _oauthClientOpenApiRepository.Table;
        }

        #endregion 
    }
}
