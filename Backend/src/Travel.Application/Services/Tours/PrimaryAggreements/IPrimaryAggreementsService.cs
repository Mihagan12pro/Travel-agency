using Travel.Application.DTOs.Tours.Aggreement.BTC;
using Travel.Model;

namespace Travel.Application.Services.Tours.PrimaryAggreements
{
    public interface IPrimaryAggreementsService
    {
        Task<long> CreateBTCAsync(
            CreateBTCAggrementDto aggrement, 
            CancellationToken token);

        Task<Result<GetBTCAggreementDto>> GetBTCAsync(
            long id, 
            CancellationToken token);

        Task<IEnumerable<long>> GetAllBTCAsync(CancellationToken token);
    }
}
