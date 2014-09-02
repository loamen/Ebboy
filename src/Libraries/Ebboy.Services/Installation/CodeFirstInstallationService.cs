using Ebboy.Core.Data;
using Ebboy.Core.Domain.Users;
using Ebboy.Services.Users;
using System;

namespace Ebboy.Services.Installation
{
    /// <summary>
    /// Code First 初始化数据类
    /// </summary>
    /// 创 建 者：Loamen.com
    
    public partial class CodeFirstInstallationService : IInstallationService
    {
        #region Fields
        private readonly IRepository<Member> _userRepository;
        private readonly IMemberService _userService;

        private readonly Guid AdminGuid = new Guid("25126848-FE01-44F4-A0E0-4D82066F25B7");
        #endregion

        #region Ctor
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="systemUserService"></param>
        /// <param name="userRepository"></param>
        /// 创 建 者：Loamen.com
        public CodeFirstInstallationService(
            IMemberService systemUserService,
            IRepository<Member> userRepository)
        {
            this._userService = systemUserService;

            this._userRepository = userRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="defaultUserEmail"></param>
        /// <param name="defaultUserPassword"></param>
        /// <param name="installSampleData"></param>
        /// 创 建 者：Loamen.com
        public virtual void InstallData(string defaultUserEmail,
             string defaultUserPassword, bool installSampleData = true)
        {
            InstallSystemUsers(defaultUserEmail, defaultUserPassword);
        }

       
        #endregion

        #region Utilities
        /// <summary>
        /// 初始化超级管理员
        /// </summary>
        /// <param name="defaultUserEmail"></param>
        /// <param name="defaultUserPassword"></param>
        /// 创 建 者：Loamen.com
        private void InstallSystemUsers(string defaultUserEmail, string defaultUserPassword)
        {
            var user = new Member();
            user.Active = true;
            user.AdminComment = "超级管理员";
            user.CreatedOnUtc = DateTime.UtcNow;
            user.Email = "admin@lottak.com";
            user.IsSystemAccount = true;
            user.LastActivityDateUtc = DateTime.UtcNow;
            user.NickName = "超级管理员";
            user.Username = "admin";
            user.Password = "30pT2RVomoXWTtLebWUAAFYzuXmC+Um/";
            user.UserGuid = AdminGuid;
            user.PasswordFormatId = 2;
            user.UserNo = 10001;

            if (_userService.GetUserByGuid(user.UserGuid) == null)
                _userRepository.Insert(user);
        }
        #endregion
    }
}
