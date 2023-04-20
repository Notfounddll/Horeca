using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.DataAcces
{
    public class SqlDataAcces : ISqlDataAcces
    {
        private readonly IConfiguration _config;
        public SqlDataAcces(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return (await connection.QueryAsync<T>(sql)).ToList();
            }
        }
        public async Task<T> LoadDataSingle<T, U>(string sql, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName); using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return (await connection.QueryAsync<T>(sql)).FirstOrDefault();
            }
        }
        public async Task SaveData<T>(string sql, T parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName); using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql,
                commandType: CommandType.Text);
            }
        }
    }
}
