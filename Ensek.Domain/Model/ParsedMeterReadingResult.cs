namespace Ensek.Domain.Model
{
    public class ParsedMeterReadingResult
    {
        public int AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public int MeterReadValue { get; set; }

        public DateTime LastUpdated { get; set; }
        public bool Valid { get; set; }

        public ParsedMeterReadingResult() {
            LastUpdated = DateTime.MinValue;
            Valid = true;
        }
    }
}
