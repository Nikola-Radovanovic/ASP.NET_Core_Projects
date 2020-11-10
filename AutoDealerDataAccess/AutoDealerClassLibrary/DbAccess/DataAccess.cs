using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Linq;

namespace AutoDealerClassLibrary.DbAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _configuration;

        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            var connectionString = _configuration.GetConnectionString(connectionStringName);

            using IDbConnection connection = new SqlConnection(connectionString);

            var rows = await connection.QueryAsync<T>(storedProcedure,
                                                      parameters,
                                                      commandType: CommandType.StoredProcedure);

            return rows.ToList();
        }

        public async Task<int> SaveData<U>(string storedProcedure, U parameters, string connectionStringName)
        {
            var connectionString = _configuration.GetConnectionString(connectionStringName);

            using IDbConnection connection = new SqlConnection(connectionString);

            return await connection.ExecuteAsync(storedProcedure,
                                                 parameters,
                                                 commandType: CommandType.StoredProcedure);
        }
    }
}