using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VirusTotal
{
    public class VT
    {
        private readonly HttpClient httpClient;

        public string ApiKey { get; set; }

        public VT(string apiKey)
        {
            ApiKey = apiKey;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-apikey", ApiKey);
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
        }

        public async Task<string> ScanFileAsync(string filePath)
        {
            string apiUrl = "https://www.virustotal.com/api/v3/files";

            try
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StreamContent(fileStream), "file", Path.GetFileName(filePath));

                    var response = await httpClient.PostAsync(apiUrl, content);
                    string responseContent = await response.Content.ReadAsStringAsync();
#if DEBUG
                    Debug.WriteLine($"Response: {responseContent}");
#endif

                    if (response.IsSuccessStatusCode)
                    {
                        // Successfully submitted the file for scanning
                        return responseContent;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while scanning the file: {ex.Message}");
            }

            return null;
        }

        public async Task<ResponseParser.VTReport> GetReportAsync(string analysisId)
        {
            if (analysisId.Contains("http"))
            {
                int lastIndex = analysisId.LastIndexOf('/');
                if (lastIndex >= 0 && lastIndex < analysisId.Length - 1)
                {
                    analysisId = analysisId.Substring(lastIndex + 1);
                }
            }

            string apiUrl = $"https://www.virustotal.com/api/v3/analyses/{analysisId}";

            try
            {
                var response = await httpClient.GetAsync(apiUrl);
                string responseContent = await response.Content.ReadAsStringAsync();
#if DEBUG
                Debug.WriteLine($"Response: {responseContent}");
#endif

                if (response.IsSuccessStatusCode)
                {
                    // Successfully retrieved the report
                    ResponseParser vtResponse = new ResponseParser();
                    return vtResponse.ParseReport(responseContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the report: {ex.Message}");
            }

            return null;
        }
    }
}
