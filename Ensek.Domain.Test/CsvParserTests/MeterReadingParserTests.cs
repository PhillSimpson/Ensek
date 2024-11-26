using Ensek.Domain.CsvParser;

namespace Ensek.Domain.Test.CsvParserTests
{
    public class MeterReadingParserTests
    {
        [TestCase("2344,22/04/2019 09:24,1002,", true, 2344, "2019-04-22 09:24:00.000", 1002)]
        [TestCase("1241,11/04/2019 09:24,436,X", true, 1241, "2019-04-11 09:24:00.000", 436)]
        public void ParseMeterReadings(string data, bool shouldBeValid, int accountId, string date, int value)
        {
            var readings = MeterReadingParser.ParseMeterReadings(new List<string>() { "AccountId,MeterReadingDateTime,MeterReadValue,", data });
            Assert.That(readings[0].Valid == shouldBeValid);
            Assert.That(readings[0].AccountId == accountId);
            Assert.That(readings[0].MeterReadingDateTime == Convert.ToDateTime(date));
            Assert.That(readings[0].MeterReadValue == value);
        }

        [Test]
        public void IgnoreEmplyLines()
        {
            var readings = MeterReadingParser.ParseMeterReadings(new List<string>() { "AccountId,MeterReadingDateTime,MeterReadValue,","","",""});
            Assert.That(readings.Count == 0);
        }
    }
}
