using Ensek.Domain.Model;
using Ensek.Domain.Services;
using Ensek.Repository.Entity;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Ensek.Domain.Test.ServicesTests
{
    public class MeterReadingServiceValidationTests
    {
        [Test]
        public void InvalidateDuplicateIds()
        {
            var readings = new List<ParsedMeterReadingResult>()
            {
                new ParsedMeterReadingResult() {AccountId = 1},
                new ParsedMeterReadingResult() {AccountId = 2},
                new ParsedMeterReadingResult() {AccountId = 3},
                new ParsedMeterReadingResult() {AccountId = 1},
                new ParsedMeterReadingResult() {AccountId = 3},
                new ParsedMeterReadingResult() {AccountId = 1}
            };

            MeterReadingService.InvalidateDuplicateIds(readings);
            foreach (var reading in readings)
            {
                switch (reading.AccountId)
                {
                    case 1:
                    case 3:
                        {
                            Assert.That(reading.Valid, Is.False);
                        }
                        break;
                    case 2:
                        {
                            Assert.That(reading.Valid, Is.True);
                        }
                        break;
                    default:
                        {
                            Assert.Fail();
                        }
                        break;
                }
            }
        }

        [TestCase(0,true)]
        [TestCase(10, true)]
        [TestCase(100, true)]
        [TestCase(1000, true)]
        [TestCase(99999, true)]
        [TestCase(-1, false)]
        [TestCase(100000, false)]
        public void InvalidateBadMeterReadValue(int value, bool shouldBeValid)
        {
            var readings = new List<ParsedMeterReadingResult>()
            {
                new ParsedMeterReadingResult() {AccountId = 1, MeterReadValue = value}
            };

            MeterReadingService.InvalidateBadMeterReadValue(readings);
            Assert.That(readings[0].Valid == shouldBeValid);
        }

        [TestCase(1, true)]
        [TestCase(2, false)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(5, true)]
        public void InvalidateMissingAccount(int accountId, bool shouldBeValid)
        {
            var readings = new List<ParsedMeterReadingResult>()
            {
                new ParsedMeterReadingResult() {AccountId = accountId }
            };

            MeterReadingService.InvalidateMissingAccount(readings, [1, 3, 5]);
            Assert.That(readings[0].Valid == shouldBeValid);
        }

        [TestCase("2024-05-01", true)]
        [TestCase("2024-01-01", false)]
        [TestCase("2024-02-02 3:3:2", false)]
        [TestCase("2024-02-02 3:3:4", true)]
        public void IvalidatInvalidateOldReadingseOldReadings(string date, bool shouldBeValid)
        {
            var readings = new List<ParsedMeterReadingResult>()
            {
                new ParsedMeterReadingResult() {AccountId = 1, 
                    MeterReadingDateTime = Convert.ToDateTime(date) }
            };

            var accounts = new List<Account>()
            {
                new Account() {
                    AccountId = 1,
                    MeterReadings = new List<MeterReading>()
                    {
                        new MeterReading()
                        {
                            AccountId = 1,
                            MeterReadingDateTime = new DateTime(2024,2,2,3,3,3)
                        }
                    }
                }
            };

            MeterReadingService.InvalidateOldReadings(readings, accounts);
            Assert.That(readings[0].Valid == shouldBeValid);
        }
    }
}
