using Travel.Model;

namespace Travel.Application.Services.Clients
{
    public interface IClientsRepository
    {
        Task<ClientBTC> GetClientBTCAsync(
            long id, 
            CancellationToken token);
    }
}
