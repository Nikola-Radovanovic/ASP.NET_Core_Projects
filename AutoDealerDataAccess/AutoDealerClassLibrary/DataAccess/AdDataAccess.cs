using AutoDealerClassLibrary.DataAccess.Interfaces;
using AutoDealerClassLibrary.DbAccess;
using AutoDealerClassLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess
{
    public class AdDataAccess : IAdDataAccess
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public AdDataAccess(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<List<AdModel>> GetAds()
        {
            return await _dataAccess.LoadData<AdModel, dynamic>("[dbo].[spAds_GetAds]",
                                                                new { },
                                                                _connectionString.SqlConnectionString);
        }

        public async Task<AdModel> GetAdById(int id)
        {
            var ad = await _dataAccess.LoadData<AdModel, dynamic>("[dbo].[spAds_GetAdById]",
                                                                  new { Id = id },
                                                                  _connectionString.SqlConnectionString);

            return ad.FirstOrDefault();
        }

        public async Task<int> CreateAd(AdModel ad)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Title", ad.Title);
            parameters.Add("DatePosted", ad.DatePosted);
            parameters.Add("Description", ad.Description);
            parameters.Add("Price", ad.Price);
            parameters.Add("ModelName", ad.ModelName);
            parameters.Add("Kilometers", ad.Kilometers);
            parameters.Add("CubicCapacity", ad.CubicCapacity);
            parameters.Add("HorsePower", ad.HorsePower);
            parameters.Add("Kilowatts", ad.Kilowatts);
            parameters.Add("ClientName", ad.ClientName);
            parameters.Add("Address", ad.Address);
            parameters.Add("City", ad.City);
            parameters.Add("ZIP", ad.ZIP);
            parameters.Add("Country", ad.Country);
            parameters.Add("Phone", ad.Phone);
            parameters.Add("ClientId", ad.ClientId);
            parameters.Add("BrandId", ad.BrandId);
            parameters.Add("CarBodyTypeId", ad.CarBodyTypeId);
            parameters.Add("CarConditionId", ad.CarConditionId);
            parameters.Add("ColorId", ad.ColorId);
            parameters.Add("FuelId", ad.FuelId);
            parameters.Add("ProductionYearId", ad.ProductionYearId);
            
            parameters.Add("Id", SqlDbType.Int, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("[dbo].[spAds_CreateAd]",
                                       parameters,
                                       _connectionString.SqlConnectionString);

            return parameters.Get<int>("Id");
        }

        public async Task<int> UpdateAd(int id, string title, string description, decimal price, string modelName, 
                                        string kilometers, string cubicCapacity, string horsePower, string kilowatts,
                                        string clientName, string address, string city, string zip, string country, 
                                        string phone, int clientId, int brandId, int carBodyTypeId, int carConditionId, 
                                        int colorId, int fuelId, int productionYearId)
        {
            return await _dataAccess.SaveData("[dbo].[spAds_UpdateAd]",
                                              new
                                              {
                                                  Id = id,
                                                  Title = title,
                                                  Description = description,
                                                  Price = price,
                                                  ModelName = modelName,
                                                  Kilometers = kilometers,
                                                  CubicCapacity = cubicCapacity,
                                                  HorsePower = horsePower,
                                                  Kilowatts = kilowatts,
                                                  ClientName = clientName,
                                                  Address = address,
                                                  City = city,
                                                  ZIP = zip,
                                                  Country = country,
                                                  Phone = phone,
                                                  ClientId = clientId,
                                                  BrandId = brandId,
                                                  CarBodyTypeId = carBodyTypeId,
                                                  CarConditionId = carConditionId,
                                                  ColorId = colorId,
                                                  FuelId = fuelId,
                                                  ProductionYearId = productionYearId
                                              },
                                              _connectionString.SqlConnectionString);
        }

        public async Task<int> DeleteAd(int id)
        {
            return await _dataAccess.SaveData("[dbo].[spAds_DeleteAd]",
                                              new { Id = id },
                                              _connectionString.SqlConnectionString);
        }
    }
}