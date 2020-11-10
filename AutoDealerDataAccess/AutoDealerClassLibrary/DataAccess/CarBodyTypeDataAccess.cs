using AutoDealerClassLibrary.DataAccess.Interfaces;
using AutoDealerClassLibrary.DbAccess;
using AutoDealerClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess
{
    public class CarBodyTypeDataAccess : ICarBodyTypeDataAccess
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionStringData;

        public CarBodyTypeDataAccess(IDataAccess dataAccess, ConnectionStringData connectionStringData)
        {
            _dataAccess = dataAccess;
            _connectionStringData = connectionStringData;
        }

        public async Task<List<CarBodyTypeModel>> GetBodyTypes()
        {
            return await _dataAccess.LoadData<CarBodyTypeModel, dynamic>("[dbo].[spCarBodyTypes_GetBodyTypes]",
                                                                         new { },
                                                                         _connectionStringData.SqlConnectionString);
        }
    }
}