using System.Threading.Tasks;
using System.Collections.Generic;
using ClientApi.Models;
namespace ClientApi.Queries.Interfaces
{
    public interface IClientQueries
    {
        Task<Client> GetClientAsync(int id);
        Task<Client> GetClientAsync(string clientNo);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<bool> InsertClientAsync(Client client);
        Task<bool> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(int clientId);
        Task<bool> DeleteClientByNoAsync(string clientNo);
    }
}