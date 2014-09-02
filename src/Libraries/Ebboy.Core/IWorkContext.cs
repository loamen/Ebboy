using Ebboy.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core
{
    public partial interface IWorkContext
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        Member CurrentUser { get; set; }


        /// <summary>
        /// 清除用户COOKIE  
        /// </summary>
        /// <param name="userGuid"></param>
        void ClearUserCookie();

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        bool IsSysAdmin { get; set; }
    }
}
