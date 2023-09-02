using Dapper;
using System.Data;

namespace Discus.SDK.Repository.Dapper.Repository
{
    /// <summary>
    /// DapperRepository数据库类型 
    /// </summary>
    public class DapperRepository : IDapperRepository
    {
        /// <summary>
        /// 连接对象
        /// </summary>
        IDbConnection _dbConnection;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dbConnection">连接对象</param>
        public DapperRepository(IDbConnection dbConnection)
        {

            switch (dbConnection.GetType().Name)
            {
                case "SqliteConnection":
                    DataBaseType = DataBaseType.Sqlite;
                    break;
                case "NpgsqlConnection":
                    DataBaseType = DataBaseType.Postgre;
                    break;
                case "SqlConnection":
                    DataBaseType = DataBaseType.SqlServer;
                    break;
                case "OracleConnection":
                    DataBaseType = DataBaseType.Oracle;
                    break;
                case "MySqlConnection":
                    DataBaseType = DataBaseType.MySql;
                    break;
            }
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dbConnection">连接对象</param>
        /// <param name="dataBaseMark">数据库标志</param>
        public DapperRepository(IDbConnection dbConnection, string dataBaseMark)
        {
            DataBaseMark = dataBaseMark;
            switch (dbConnection.GetType().Name)
            {
                case "SqliteConnection":
                    DataBaseType = DataBaseType.Sqlite;
                    break;
                case "NpgsqlConnection":
                    DataBaseType = DataBaseType.Postgre;
                    break;
                case "SqlClientConnection":
                    DataBaseType = DataBaseType.SqlServer;
                    break;
                case "OracleConnection":
                    DataBaseType = DataBaseType.Oracle;
                    break;
                case "MySqlConnection":
                    DataBaseType = DataBaseType.MySql;
                    break;
            }
            _dbConnection = dbConnection;
        }
        /// <summary>
        /// 数据库标志
        /// </summary>
        public string? DataBaseMark { get; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataBaseType DataBaseType { get; }
        /// <summary>
        /// 连接对象
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetConnection()
        {
            return _dbConnection;
        }
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <typeparam name="T">映射实体类</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数对象</param>
        /// <param name="transaction">事务</param>
        /// <param name="buffered">是否缓存结果</param>
        /// <param name="commandTimeout">command超时时间(秒)</param>
        /// <param name="commandType">command类型</param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object? param = null, IDbTransaction? transaction = null, bool buffered = false, int? commandTimeout = null, CommandType? commandType = null)
        {
            return _dbConnection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }
        /// <summary>
        /// 查询异步方法
        /// </summary>
        /// <typeparam name="T">映射实体类</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数对象</param>
        /// <param name="transaction">事务</param> 
        /// <param name="commandTimeout">command超时时间(秒)</param>
        /// <param name="commandType">command类型</param>
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _dbConnection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }
        /// <summary>
        /// 查询单个对象异步方法
        /// </summary>
        /// <typeparam name="T">映射实体类</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数对象</param>
        /// <param name="transaction">事务</param> 
        /// <param name="commandTimeout">command超时时间(秒)</param>
        /// <param name="commandType">command类型</param>
        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="sql">映射实体类</param>
        /// <param name="param">参数对象</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">command超时时间(秒)</param>
        /// <param name="commandType">command类型</param>
        /// <returns></returns>
        public int Execute(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return _dbConnection.Execute(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// <param name="sql">映射实体类</param>
        /// <param name="param">参数对象</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">command超时时间(秒)</param>
        /// <param name="commandType">command类型</param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _dbConnection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
        }
        /// <summary>
        /// 查询单值
        /// </summary>
        /// <typeparam name="T">映射实体类</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数对象</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">command超时时间(秒)</param>
        /// <param name="commandType">command类型</param>
        /// <returns></returns>
        public T ExecuteScalar<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return _dbConnection.ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// 异步查询单值
        /// </summary>
        /// <typeparam name="T">映射实体类</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数对象</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">command超时时间(秒)</param>
        /// <param name="commandType">command类型</param>
        /// <returns></returns>
        public async Task<T> ExecuteScalarAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _dbConnection.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public void Dispose()
        {
            if (_dbConnection != null)
            {
                _dbConnection.Dispose();
            }
        }
    }
}
