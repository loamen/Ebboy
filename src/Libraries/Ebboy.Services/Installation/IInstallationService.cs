using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.Installation
{
    /// <summary>
    /// 安装服务接口
    /// </summary>
    public partial interface IInstallationService
    {
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="defaultUserEmail"></param>
        /// <param name="defaultUserPassword"></param>
        /// <param name="installSampleData"></param>
        void InstallData(string defaultUserEmail, string defaultUserPassword, bool installSampleData = true);
    }
}
