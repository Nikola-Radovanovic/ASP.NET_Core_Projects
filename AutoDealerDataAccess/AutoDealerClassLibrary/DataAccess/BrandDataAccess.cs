using AutoDealerClassLibrary.DataAccess.Interfaces;
using AutoDealerClassLibrary.DbAccess;
using AutoDealerClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess
{
    public class BrandDataAccess : IBrandDataAccess
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionStringData;

        public BrandDataAccess(IDataAccess dataAccess, ConnectionStringData connectionStringData)
        {
            _dataAccess = dataAccess;
            _connectionStringData = connectionStringData;
        }

        public async Task<List<BrandModel>> GetBrands()
        {
            return await _dataAccess.LoadData<BrandModel, dynamic>("[dbo].[spBrands_GetBrands]",
                                                                   new { },
                                                                   _connectionStringData.SqlConnectionString);
        }
    }
}