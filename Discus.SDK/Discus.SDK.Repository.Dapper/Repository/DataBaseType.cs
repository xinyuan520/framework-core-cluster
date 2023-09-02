using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discus.SDK.Repository.Dapper.Repository
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DataBaseType
    {
        None,
        Sqlite,
        Postgre,
        SqlServer,
        Oracle,
        MySql
    }
}
