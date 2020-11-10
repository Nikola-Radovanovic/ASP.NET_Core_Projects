using AutoDealerClassLibrary.DataAccess.Interfaces;
using AutoDealerClassLibrary.DbAccess;
using AutoDealerClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess
{
    public class ColorDataAccess : IColorDataAccess
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionStringData;

        public ColorDataAccess(IDataAccess dataAccess, ConnectionStringData connectionStringData)
        {
            _dataAccess = dataAccess;
            _connectionStringData = connectionStringData;
        }

        public async Task<List<ColorModel>> GetColors()
        {
            return await _dataAccess.LoadData<ColorModel, dynamic>("[dbo].[spColors_GetColors]",
                                                                   new { },
                                                                   _connectionStringData.SqlConnectionString);
        }
    }
}