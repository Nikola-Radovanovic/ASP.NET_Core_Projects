using AutoDealerClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess.Interfaces
{
    public interface IClientDataAccess
    {
        Task<int> CreateClient(ClientModel client);
        Task<int> DeleteClient(int id);
        Task<ClientModel> GetClientById(int id);
        Task<List<ClientModel>> GetClients();
        Task<int> UpdateClient(int id, string clientName, string address, string city, string zip, string country, string phone);
    }
}