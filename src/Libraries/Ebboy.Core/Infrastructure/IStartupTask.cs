namespace Ebboy.Core.Infrastructure
{
    /// <summary>
    /// 执行启动任务
    /// </summary>
    public interface IStartupTask 
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        void Execute();

        /// <summary>
        /// Order
        /// </summary>
        int Order { get; }
    }
}
