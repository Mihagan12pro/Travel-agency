using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Model
{
    public class ClientBTC
    {
        [Key]
        public long Id { get; set; }

        [Column("Passport")]
        public required string HashedPassport { get; set; }

        [MinLength(6)]
        public required string FullName { get; set; }
    }
}
