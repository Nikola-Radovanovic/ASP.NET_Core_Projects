using AutoDealerClassLibrary.DataAccess.Interfaces;
using AutoDealerClassLibrary.DbAccess;
using AutoDealerClassLibrary.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess
{
    public class ClientDataAccess : IClientDataAccess
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public ClientDataAccess(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<List<ClientModel>> GetClients()
        {
            return await _dataAccess.LoadData<ClientModel, dynamic>("[dbo].[spClients_GetClients]",
                                                                    new { },
                                                                    _connectionString.SqlConnectionString);
        }

        public async Task<ClientModel> GetClientById(int id)
        {
            var client = await _dataAccess.LoadData<ClientModel, dynamic>("[dbo].[spClients_GetClientById]",
                                                                          new { Id = id },
                                                                          _connectionString.SqlConnectionString);

            return client.FirstOrDefault();
        }

        public async Task<int> CreateClient(ClientModel client)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("ClientName", client.ClientName);
            parameters.Add("DateRegistered", client.DateRegistered);
            parameters.Add("Address", client.Address);
            parameters.Add("City", client.City);
            parameters.Add("ZIP", client.ZIP);
            parameters.Add("Country", client.Country);
            parameters.Add("Phone", client.Phone);
            parameters.Add("Id", SqlDbType.Int, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("[dbo].[spClients_CreateClient]",
                                       parameters,
                                       _connectionString.SqlConnectionString);

            return parameters.Get<int>("Id");
        }

        public async Task<int> UpdateClient(int id, string clientName, string address, string city, string zip, string country, string phone)
        {
            return await _dataAccess.SaveData("[dbo].[spClients_UpdateClient]",
                                              new
                                              {
                                                  Id = id,
                                                  ClientName = clientName,
                                                  Address = address,
                                                  City = city,
                                                  ZIP = zip,
                                                  Country = country,
                                                  Phone = phone
                                              },
                                              _connectionString.SqlConnectionString);
        }

        public async Task<int> DeleteClient(int id)
        {
            return await _dataAccess.SaveData("[dbo].[spClients_DeleteClient]",
                                              new { Id = id },
                                              _connectionString.SqlConnectionString);
        }
    }
}