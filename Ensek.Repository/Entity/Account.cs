using System.ComponentModel.DataAnnotations;

namespace Ensek.Repository.Entity
{
    public class Account
    {
        public int AccountId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public List<MeterReading> MeterReadings { get; set; }
    }
}
