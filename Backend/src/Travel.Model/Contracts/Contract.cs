namespace Travel.Model.Contracts
{
    public class Contract
    {
        public long Id { get; set; }

        public required long AgreementId { get; set; }

        public required int StaffUserId { get; set; }

        public decimal Price { get; set; }

        public DateTime? ContractDateTime { get; set; }

        public required DateTime EndDateTime { get; set; }
    }
}
