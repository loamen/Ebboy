using Ebboy.Core.Data;
using Ebboy.Core.Domain.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebboy.Data.Extensions;
using Ebboy.Core;
using Ebboy.Core.PagedList;
using Ebboy.Core.Domain.Users;

namespace Ebboy.Services.Logs
{
    public partial class Logger : ILogger
    {
        #region Fileds
        private readonly IRepository<Log> _logRepository;
        private readonly IWebHelper _webHelper;
        #endregion

        #region Cotr
        public Logger(IRepository<Log> logRepository,
            IWebHelper webHelper)
        {
            _logRepository = logRepository;
            _webHelper = webHelper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="log"></param>
        /// 创 建 者：Loamen.com
        public virtual void Insert(Log log)
        {
            log.CreatedOnUtc = DateTime.UtcNow;
            _logRepository.Insert(log);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="log"></param>
        /// 创 建 者：Loamen.com
        public virtual void Update(Log log)
        {
            _logRepository.Update(log);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="log"></param>
        /// 创 建 者：Loamen.com
        public virtual void Delete(Log log)
        {
            _logRepository.Delete(log);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual Log GetById(int id)
        {
            return _logRepository.GetById(id);
        }

        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual IQueryable<Log> GetAllList()
        {
           return  _logRepository.Table;
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// 创 建 者：Loamen.com
        public virtual void ClearLog()
        {
            GetAllList().Deletes();
        }

        /// <summary>
        /// 是否允许记录日志
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual bool IsEnabled(EnumLogLevel level)
        {
            switch (level)
            {
                case EnumLogLevel.Debug:
                    return false;
                default:
                    return true;
            }
        }

        /// <summary>
        /// 获取日志分页列表
        /// </summary>
        /// <param name="fromUtc">开始时间</param>
        /// <param name="toUtc">结束时间</param>
        /// <param name="message">内容</param>
        /// <param name="logLevel">日志等级</param>
        /// <param name="pageOption">分页参数</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual IPagedList<Log> GetLogList(DateTime? fromUtc, DateTime? toUtc,
            string message, EnumLogLevel? logLevel, PageOption pageOption = null)
        {
            var query = _logRepository.Table;
            if (fromUtc.HasValue)
                query = query.Where(l => fromUtc.Value <= l.CreatedOnUtc);
            if (toUtc.HasValue)
                query = query.Where(l => toUtc.Value >= l.CreatedOnUtc);
            if (logLevel.HasValue)
            {
                query = query.Where(l => logLevel == l.LogLevelId);
            }
            if (!String.IsNullOrEmpty(message))
                query = query.Where(l => l.ShortMessage.Contains(message) || l.FullMessage.Contains(message));
            query = query.OrderByDescending(l => l.CreatedOnUtc);

            var log = new PagedList<Log>(query, pageOption.PageIndex, pageOption.PageSize);
            return log;
        }

        /// <summary>
        /// 插入日志
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="shortMessage">简单描述</param>
        /// <param name="fullMessage">详细描述</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual Log InsertLog(EnumLogLevel logLevel, string shortMessage, string fullMessage = "")
        {
            return InsertLog(logLevel, shortMessage, fullMessage = "", null);
        }

        /// <summary>
        /// 插入日志
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="shortMessage">简单描述</param>
        /// <param name="user">用户编号</param>
        /// <param name="fullMessage">详细描述</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual Log InsertLog(EnumLogLevel logLevel, string shortMessage, string fullMessage = "", Member user = null)
        {
            if (!IsEnabled(logLevel))
                return null;

            var log = new Log()
            {
                LogLevelId = logLevel,
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                IpAddress = _webHelper.GetCurrentIpAddress(),
                PageUrl = _webHelper.GetThisPageUrl(true),
                ReferrerUrl = _webHelper.GetUrlReferrer(),
                CreatedOnUtc = DateTime.UtcNow
            };
            if (user != null)
            {
                log.UserGuid = user.UserGuid;
            }

            Insert(log);

            return log;
        }
        #endregion
    }
}
