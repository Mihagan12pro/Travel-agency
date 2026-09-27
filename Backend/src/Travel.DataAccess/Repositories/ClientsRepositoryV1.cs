using Microsoft.EntityFrameworkCore;
using Travel.Application.Services.Clients;
using Travel.Model;

namespace Travel.DataAccess.Repositories
{
    internal class ClientsRepositoryV1 : IClientsRepository
    {
        private readonly AppDbContext _dbContext;

        public async Task<ClientBTC> GetClientBTCAsync(long id, CancellationToken token)
        {
            var client = await _dbContext.BTCClients.FirstOrDefaultAsync(c => c.Id == id, token);

            return client;
        }

        public ClientsRepositoryV1(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
