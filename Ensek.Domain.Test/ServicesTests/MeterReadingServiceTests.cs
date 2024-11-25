using Ensek.Domain.Model;
using Ensek.Domain.Services;
using Ensek.Repository.Entity;
using Ensek.Repository.Repository;
using Moq;

namespace Ensek.Domain.Test.ServicesTests
{
    public class MeterReadingServiceTests
    {
        public MeterReadingService _meterReadingService;
        public Mock<IAccountRepository> _accountRepository;
        public Mock<IMeterReadingRepository> _meterReadingRepository;

        [SetUp]
        public void Setup()
        {
            _accountRepository = new Mock<IAccountRepository>();
            _accountRepository.Setup(x => x.GetAccountsWithLatestReading(It.IsAny<List<int>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Account>() {
                    new Account() {
                        AccountId = 1,
                        MeterReadings = new List<MeterReading>() {
                            new MeterReading() {
                                AccountId = 1,
                                MeterReadingDateTime = new DateTime(2024,2,2)
                            }
                        }
                    },
                    new Account() {
                        AccountId = 2,
                        MeterReadings = new List<MeterReading>() {
                            new MeterReading() {
                                AccountId = 2,
                                MeterReadingDateTime = new DateTime(2024,4,4)
                            }
                        }
                    },
                    new Account() {
                        AccountId = 3,
                        MeterReadings = new List<MeterReading>() {
                            new MeterReading() {
                                AccountId = 3,
                                MeterReadingDateTime = new DateTime(2024,2,2)
                            }
                        }
                    }
                });

            _meterReadingRepository = new Mock<IMeterReadingRepository>();
            _meterReadingRepository.Setup(x => x.Insert(It.IsAny<MeterReading>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            _meterReadingService = new MeterReadingService(
                _accountRepository.Object, 
                _meterReadingRepository.Object);
        }

        [Test]
        public void UpdateMeterReadings()
        {
            var readings = new List<ParsedMeterReadingResult>()
            {
                new ParsedMeterReadingResult() { AccountId = 1, MeterReadValue = 10, MeterReadingDateTime = new DateTime(2024,3,3) },
                new ParsedMeterReadingResult() { AccountId = 2, MeterReadValue = 20, MeterReadingDateTime = new DateTime(2024,3,3) },
                new ParsedMeterReadingResult() { AccountId = 3, MeterReadValue = 30, MeterReadingDateTime = new DateTime(2024,3,3) }
            };

            var result = _meterReadingService.UpdateMeterReadings(readings, new CancellationToken());
            Assert.That(result.Result.Updated == 2);
            Assert.That(result.Result.Failed == 1);
        }
    }


    //ParseMeterReadings

}
