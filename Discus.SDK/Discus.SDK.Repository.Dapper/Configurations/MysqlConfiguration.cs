using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discus.SDK.Repository.Dapper.Configurations
{
    public class MysqlConfiguration
    {
        public string ConnectionString { get; set; }
        //public MySqlConnection mySqlConnection { get; set; }
    }
}
