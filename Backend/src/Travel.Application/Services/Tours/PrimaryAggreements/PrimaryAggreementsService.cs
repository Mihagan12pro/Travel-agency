using Travel.Application.DTOs.Clients.BTC;
using Travel.Application.DTOs.Tours.Aggreement.BTC;
using Travel.Application.Services.Clients;
using Travel.Application.Services.Security;
using Travel.Application.Services.Users;
using Travel.Model;

namespace Travel.Application.Services.Tours.PrimaryAggreements
{
    internal class PrimaryAggreementsService : IPrimaryAggreementsService
    {
        private readonly IPrimaryAggreementsRepository _primaryAggreementsRepository;
        private readonly ISecurityService _securityService;
        private readonly IUsersRepository _usersRepository;
        private readonly IClientsRepository _clientsRepository;

        public async Task<long> CreateBTCAsync(CreateBTCAggrementDto aggrement, CancellationToken token)
        {
            aggrement = aggrement with
            {
                ClientPassport = _securityService.HashSha256(aggrement.ClientPassport)
            };

            long id = await _primaryAggreementsRepository.AddBTCAsync(
                int.Parse(_securityService.JwtClaimExtractor("sub")), 
                aggrement,
                token
            );

            return id;
        }

        public async Task<IEnumerable<long>> GetAllBTCAsync(CancellationToken token)
        {
            var aggreements = await _primaryAggreementsRepository.GetAllBTCAsync(token);

            return aggreements.Select(a => a.Id);
        }

        public async Task<Result<GetBTCAggreementDto>> GetBTCAsync(
            long id, 
            CancellationToken token)
        {
            var aggreement = await _primaryAggreementsRepository.GetBTCAsync(id, token);
            if (aggreement == null)
                return new Result<GetBTCAggreementDto>(false, null, "Соглашение не найдено!");

            var employee = await _usersRepository.ExtractEmployeeAsync(aggreement.StaffUserId, token);
            var client = await _clientsRepository.GetClientBTCAsync(aggreement.ClientId, token);

            if (employee == null || client == null)
                return new Result<GetBTCAggreementDto>(false, null, "Соглашение битое!");

            GetBTCAggreementDto aggreementDto = new GetBTCAggreementDto(
                aggreement.Id,
                aggreement.Description,
                new GetClientBTCDto(client.FullName),
                new DTOs.Employee.GetEmployeeDto(
                    employee.Name, 
                    employee.SurName,
                    employee.Patronymic,
                    employee.Role)
            );

            return new Result<GetBTCAggreementDto>(true, aggreementDto);
        }


        public PrimaryAggreementsService(
            IPrimaryAggreementsRepository primaryAggreementsRepository,
            ISecurityService securityService,
            IUsersRepository usersRepository,
            IClientsRepository clientsRepository)
        {
            _primaryAggreementsRepository = primaryAggreementsRepository;

            _securityService = securityService;

            _usersRepository = usersRepository;

            _clientsRepository = clientsRepository;
        }
    }
}
