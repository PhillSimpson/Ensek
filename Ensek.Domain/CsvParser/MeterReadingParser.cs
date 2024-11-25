using Ensek.Domain.Model;

namespace Ensek.Domain.CsvParser
{
    public static class MeterReadingParser
    {
        public static List<ParsedMeterReadingResult> ParseMeterReadings(List<string> fileRows)
        {
            var data = new List<ParsedMeterReadingResult>();
            for (var i = 1; i < fileRows.Count; i++)
            {
                string[] values = fileRows[i].Split(',');
                var result = new ParsedMeterReadingResult(i+1);

                if (int.TryParse(values[0], out int accountId))
                {
                    result.AccountId = accountId;
                }
                else
                {
                    result.Valid = false;
                }

                if (DateTime.TryParse(values[1], out DateTime date))
                {
                    result.MeterReadingDateTime = date;
                }
                else
                {
                    result.Valid = false;
                }

                if (int.TryParse(values[2], out int value))
                {
                    result.MeterReadValue = value;
                }
                else
                {
                    result.Valid = false;
                }
                data.Add(result);
            }
            return data;
        }
    }
}
