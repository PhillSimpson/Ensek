using Microsoft.AspNetCore.Http;

namespace Ensek.Domain.FileReader
{
    public static class TextFileReader
    {
        public static async Task<List<string>> ConvertFileToStringList(IFormFile file)
        {
            var result = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    var line = await reader.ReadLineAsync();
                    if (line != null)
                    {
                        result.Add(line);
                    }
                }
            }
            return result;
        }
    }
}
