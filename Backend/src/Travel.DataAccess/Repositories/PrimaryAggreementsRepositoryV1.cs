using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Travel.Application.DTOs.Tours.Aggreement.BTC;
using Travel.Application.Services.Tours.PrimaryAggreements;
using Travel.Model;
using Travel.Model.Contracts;

namespace Travel.DataAccess.Repositories
{
    internal class PrimaryAggreementsRepositoryV1 : IPrimaryAggreementsRepository
    {
        private readonly AppDbContext _dbContext;

        public async Task<long> AddBTCAsync(int userId, CreateBTCAggrementDto aggrement, CancellationToken token)
        {
            var client = await _dbContext.BTCClients.FirstOrDefaultAsync(c => c.HashedPassport == aggrement.ClientPassport, token);

            if (client == null)
            {
                client = new ClientBTC 
                {
                    FullName = aggrement.FullName,
                    
                    HashedPassport = aggrement.ClientPassport
                };

                await _dbContext.BTCClients.AddAsync(client, token);

                await _dbContext.SaveChangesAsync(token);
            }

            client.FullName = aggrement.FullName;

            PrimaryAgreement agreement = new PrimaryAgreement
            {
                ClientId = client.Id,

                Description = aggrement.Description,

                StaffUserId = userId,
            };

            await _dbContext.PrimaryAgreements.AddAsync(agreement, token);

            await _dbContext.SaveChangesAsync(token);

            return agreement.Id;
        }

        public async Task<IEnumerable<PrimaryAgreement>> GetAllBTCAsync(CancellationToken token)
            => _dbContext.PrimaryAgreements.Where(a => !a.IsArchieved);

        public async Task<PrimaryAgreement> GetBTCAsync(
            long id, 
            CancellationToken token)
        {
            var aggreement = await _dbContext.PrimaryAgreements.FirstOrDefaultAsync(
                pa => !pa.IsArchieved && pa.Id == id, token);

            return aggreement;
        }

        public PrimaryAggreementsRepositoryV1(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
