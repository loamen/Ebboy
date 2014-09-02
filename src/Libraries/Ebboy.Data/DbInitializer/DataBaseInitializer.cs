using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Ebboy.Data.DbInitializer
{
    public class DataBaseInitializer : IDatabaseInitializer<DataContext>
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        /// <param name="context"></param>
        // 创 建 者：Loamen.com
        public void InitializeDatabase(DataContext context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
