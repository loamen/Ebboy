using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Web.Framework.Models.Companies
{
    public enum EnumEmplyeeRole
    {
        /// <summary>
        /// 普通员工权限
        /// </summary>
        /// 创 建 者：Loamen.com
        [Description("普通员工权限")]
        General = 0,
        /// <summary>
        /// 管理员权限
        /// </summary>
        [Description("管理员权限")]
        Admin =1
    }
}
