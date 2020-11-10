using AutoDealerClassLibrary.DataAccess.Interfaces;
using AutoDealerClassLibrary.DbAccess;
using AutoDealerClassLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess
{
    public class ProductionYearDataAccess : IProductionYearDataAccess
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionStringData;

        public ProductionYearDataAccess(IDataAccess dataAccess, ConnectionStringData connectionStringData)
        {
            _dataAccess = dataAccess;
            _connectionStringData = connectionStringData;
        }

        public async Task<List<ProductionYearModel>> GetYears()
        {
            return await _dataAccess.LoadData<ProductionYearModel, dynamic>("[dbo].[spProductionYears_GetYears]",
                                                                            new { },
                                                                            _connectionStringData.SqlConnectionString);
        }
    }
}