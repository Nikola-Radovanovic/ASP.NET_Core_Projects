using AutoDealerClassLibrary.DataAccess.Interfaces;
using AutoDealerClassLibrary.DbAccess;
using AutoDealerClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess
{
    public class FuelDataAccess : IFuelDataAccess
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionStringData;

        public FuelDataAccess(IDataAccess dataAccess, ConnectionStringData connectionStringData)
        {
            _dataAccess = dataAccess;
            _connectionStringData = connectionStringData;
        }

        public async Task<List<FuelModel>> GetFuels()
        {
            return await _dataAccess.LoadData<FuelModel, dynamic>("[dbo].[spFuels_GetFuels]",
                                                                  new { },
                                                                  _connectionStringData.SqlConnectionString);
        }
    }
}