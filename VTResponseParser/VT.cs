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
            httpClient.DefaultRequestHeaders.Add("User-Agent", "VirusTotal Desktop Widget (github.com/AlexRasch/VirusTotal-Desktop-Widget)");
            httpClient.DefaultRequestHeaders.Add("x-apikey", ApiKey);
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
        }

        private static async Task<ResponseParser> GetNonQueuedReportAsync(VT vt, string reportId, int delay = 10)
        {
            ResponseParser vtReport = await vt.GetReportAsync(reportId);
            while (vtReport.Status == "queued")
            {
#if DEBUG
                Debug.WriteLine($"Report status:queued ");
#endif
                await Task.Delay(TimeSpan.FromSeconds(delay));
                vtReport = await vt.GetReportAsync(reportId);
            }

            return vtReport;
        }

        public async Task<ResponseParser> ScanFileAsync(VT vt, string filePath)
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
                    // Parse initial response
                    ResponseParser vtResponse = new();
                    vtResponse.ParseReport(responseContent);

                    return await GetNonQueuedReportAsync(vt, vtResponse.Id);

                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"An error occurred while scanning the file: {ex.Message}");
#endif
            }

            return null;
        }

        public async Task<ResponseParser> GetReportAsync(string analysisId)
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

                ResponseParser vtResponse = new();

                if (response.IsSuccessStatusCode)
                {
                    // Successfully retrieved the report
                    return vtResponse.ParseReport(responseContent);
                }
                // Error while  retrieved the report
                return vtResponse.ParseReport(responseContent);

            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"VT error while retrieving the report: {ex.Message}");
#endif
            }

            return null;
        }
    }
}
