namespace Travel.Model.Contracts
{
    public class PrimaryAgreement
    {
        public long Id { get; set; }

        public required string Description { get; set; }

        public required long ClientId { get; set; }

        public required int StaffUserId { get;set;  }

        public bool IsArchieved { get; set; }
    }
}
