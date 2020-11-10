using AutoDealerClassLibrary.DataAccess.Interfaces;
using AutoDealerClassLibrary.DbAccess;
using AutoDealerClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess
{
    public class CarConditionDataAccess : ICarConditionDataAccess
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionStringData;

        public CarConditionDataAccess(IDataAccess dataAccess, ConnectionStringData connectionStringData)
        {
            _dataAccess = dataAccess;
            _connectionStringData = connectionStringData;
        }

        public async Task<List<CarConditionModel>> GetCarConditions()
        {
            return await _dataAccess.LoadData<CarConditionModel, dynamic>("[dbo].[spCarConditions_GetCarConditions]",
                                                                          new { },
                                                                          _connectionStringData.SqlConnectionString);
        }
    }
}