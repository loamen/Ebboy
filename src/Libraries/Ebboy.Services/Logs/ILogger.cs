using Ebboy.Core;
using Ebboy.Core.Domain.Logs;
using Ebboy.Core.Domain.Users;
using Ebboy.Core.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.Logs
{
    public partial interface ILogger
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="log"></param>
        void Insert(Log log);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="log"></param>
        void Update(Log log);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="log"></param>
        void Delete(Log log);

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Log GetById(int id);

        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <returns></returns>
        IQueryable<Log> GetAllList();

        /// <summary>
        /// 清空日志
        /// </summary>
        void ClearLog();

        /// <summary>
        /// 是否允许记录日志
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnabled(EnumLogLevel level);

        /// <summary>
        /// 获取日志分页列表
        /// </summary>
        /// <param name="fromUtc">开始时间</param>
        /// <param name="toUtc">结束时间</param>
        /// <param name="message">内容</param>
        /// <param name="logLevel">日志等级</param>
        /// <param name="pageOption">分页参数</param>
        /// <returns></returns>
        IPagedList<Log> GetLogList(DateTime? fromUtc, DateTime? toUtc,
            string message, EnumLogLevel? logLevel, PageOption pageOption = null);

        /// <summary>
        /// 插入日志
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="shortMessage">简单描述</param>
        /// <param name="fullMessage">详细描述</param>
        /// <returns></returns>
        Log InsertLog(EnumLogLevel logLevel, string shortMessage, string fullMessage = "");

        /// <summary>
        /// 插入日志
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="shortMessage">简单描述</param>
        /// <param name="userGuid">用户编号</param>
        /// <param name="fullMessage">详细描述</param>
        /// <returns></returns>
        Log InsertLog(EnumLogLevel logLevel, string shortMessage, string fullMessage = "", Member user = null);
    }
}
