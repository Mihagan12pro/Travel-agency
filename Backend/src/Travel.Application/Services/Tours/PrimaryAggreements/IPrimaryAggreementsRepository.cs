using Travel.Application.DTOs.Tours.Aggreement.BTC;
using Travel.Model.Contracts;

namespace Travel.Application.Services.Tours.PrimaryAggreements
{
    public interface IPrimaryAggreementsRepository
    {
        Task<long> AddBTCAsync(
            int userId,
            CreateBTCAggrementDto aggrement,
            CancellationToken token);

        Task<IEnumerable<PrimaryAgreement>> GetAllBTCAsync(CancellationToken token);

        Task<PrimaryAgreement> GetBTCAsync(
            long id,
            CancellationToken token);
    }
}
