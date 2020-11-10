using AutoDealerClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess.Interfaces
{
    public interface IAdDataAccess
    {
        Task<int> CreateAd(AdModel ad);
        Task<int> DeleteAd(int id);
        Task<AdModel> GetAdById(int id);
        Task<List<AdModel>> GetAds();
        Task<int> UpdateAd(int id, string title, string description, decimal price, string modelName,
                           string kilometers, string cubicCapacity, string horsePower, string kilowatts,
                           string clientName, string address, string city, string zip, string country,
                           string phone, int clientId, int brandId, int carBodyTypeId, int carConditionId,
                           int colorId, int fuelId, int productionYearId);
    }
}