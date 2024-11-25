using Ensek.Domain.CsvParser;
using Ensek.Domain.FileReader;
using Ensek.Domain.Model;
using Microsoft.AspNetCore.Http;

namespace Ensek.Domain.Services
{
    public interface IMeterReadingService
    {
        public Task<UpdateMeterReadingResponse> UpdateMeterReadings(IFormFile file);
    }


    public class MeterReadingService : IMeterReadingService
    {
        public async Task<UpdateMeterReadingResponse> UpdateMeterReadings(IFormFile file)
        {
            var response = new UpdateMeterReadingResponse();
            var meterReadings = new List<ParsedMeterReadingResult>();

            var fileRows = await TextFileReader.ConvertFileToStringList(file);
            var readings = MeterReadingParser.ParseMeterReadings(fileRows);

            InvalidateDuplicateIds(readings);
            InvalidateBadMeterReadValue(readings);

            var accountIds = readings.Where(x => x.Valid).Select(y => y.AccountId).ToList();

            //has account
                //get accounts based off current valid import with Date
                //
            //date isnt older

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

    }
}
