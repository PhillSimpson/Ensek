using Ensek.Domain.CsvParser;
using Ensek.Domain.FileReader;
using Ensek.Domain.Model;
using Ensek.Repository.Entity;
using Ensek.Repository.Repository;
using Microsoft.AspNetCore.Http;

namespace Ensek.Domain.Services
{
    public interface IMeterReadingService
    {
        public Task<UpdateMeterReadingResponse> UpdateMeterReadings(IFormFile file, CancellationToken cancellationToken);
    }


    public class MeterReadingService : IMeterReadingService
    {
        public readonly IAccountRepository _accountRepository;
        public readonly IMeterReadingRepository _meterReadingRepository;

        public MeterReadingService(IAccountRepository accountRepository, IMeterReadingRepository meterReadingRepository)
        {
            _accountRepository = accountRepository;
            _meterReadingRepository = meterReadingRepository;
        }

        public async Task<UpdateMeterReadingResponse> UpdateMeterReadings(IFormFile file, CancellationToken cancellationToken)
        {
            var response = new UpdateMeterReadingResponse();

            var fileRows = await TextFileReader.ConvertFileToStringList(file);
            var readings = MeterReadingParser.ParseMeterReadings(fileRows);

            InvalidateDuplicateIds(readings);
            InvalidateBadMeterReadValue(readings);

            var accountIds = readings.Where(x => x.Valid).Select(y => y.AccountId).ToList();
            var latestReadings = await _accountRepository.GetAccountsWithLatestReading(accountIds);
            InvalidateMissingAccount(readings, latestReadings.Select(x=>x.AccountId).ToList());
            IvalidateOldReadings(readings, latestReadings);

            foreach (var reading in readings.Where(x => x.Valid)) {
                var newReading = new MeterReading() { 
                    AccountId = reading.AccountId, 
                    MeterReadingDateTime = reading.MeterReadingDateTime, 
                    MeterReadValue = reading.MeterReadValue 
                };
                if(await _meterReadingRepository.Insert(newReading, cancellationToken))
                {
                    response.Updated++;
                }
            }
            response.Failed = readings.Count - response.Updated;
            return response;
        }

        public static void InvalidateDuplicateIds(List<ParsedMeterReadingResult> readings)
        {
            var dupes = readings.GroupBy(x=>x.AccountId)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            foreach (var row in readings)
            {
                if (dupes.Contains(row.AccountId))
                {
                    row.Valid = false;
                }
            }
        }

        public static void InvalidateBadMeterReadValue(List<ParsedMeterReadingResult> readings)
        {
            foreach (var row in readings)
            {
                if (row.MeterReadValue >= 0 && row.MeterReadValue < 100000)
                {
                    //valid meter reading are positive and upto 5 digits long
                }
                else
                {
                    row.Valid = false;
                }
            }
        }

        public static void InvalidateMissingAccount(List<ParsedMeterReadingResult> readings, List<int> accountIds)
        {
            foreach (var row in readings)
            {
                if (!accountIds.Contains(row.AccountId))
                {
                    row.Valid = false;
                }
            }
        }

        public static void IvalidateOldReadings(List<ParsedMeterReadingResult> readings, List<Account> accounts)
        {
            foreach (var row in readings.Where(x=>x.Valid))
            {
                foreach(var account in accounts)
                {
                    if (row.AccountId == account.AccountId)
                    {
                        if (account.MeterReadings.Any())
                        {
                            if (row.MeterReadingDateTime <= account.MeterReadings[0].MeterReadingDateTime)
                            {
                                row.Valid = false;
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}
