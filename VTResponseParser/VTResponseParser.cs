using System.Diagnostics;
using System.Text.Json;

namespace VirusTotal
{
    // VTResponseParser: Parses JSON data from VirusTotal API.
    // Note: This implementation is not a complete match for the VirusTotal API, so it may behave unexpectedly.
    // It is recommended to refer to the official VirusTotal API documentation for a comprehensive implementation.
    // Instead of using tools like json2csharp.com, I manually created the classes.

    public class ResponseParser
    {
        public ResponseParser.Error? ErrorCode { get; set; }
        public Meta.FileInfo FileInfo { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string SelfLink { get; set; }
        public Dictionary<string, EngineResult> Results { get; set; } // New property for results
        public class Error
        {
            public string? Message { get; set; }
            public string? Code { get; set; }
        }
        public struct Meta
        {
            public struct FileInfo
            {
                public string SHA256 { get; set; }
                public string SHA1 { get; set; }
                public string MD5 { get; set; }
                public int Size { get; set; }
            }
        }
        public class EngineResult
        {
            public string? Category { get; set; }
            public string? EngineName { get; set; }
            public string? EngineVersion { get; set; }
            public string? Result { get; set; }
            public string? Method { get; set; }
            public string? EngineUpdate { get; set; }
        }

        /// <summary>
        /// Indicates whether the response parsing is complete.
        /// Note: This property is not part of the VirusTotal API.
        /// </summary>
        public bool IsComplete { get; set; }


        public ResponseParser ParseReport(string? responseContent)
        {
            var report = new ResponseParser();

            try
            {
                using (JsonDocument document = JsonDocument.Parse(responseContent))
                {
                    // Check for errors
                    if (document.RootElement.TryGetProperty("error", out JsonElement errorElement))
                    {
#if DEBUG
                        Debug.WriteLine("VTResponseParser: Possible error in response");
#endif
                        report.ErrorCode = ParseErrorMessage(errorElement);
                    }

                    if (document.RootElement.TryGetProperty("data", out JsonElement dataElement))
                    {

                        // Attributes
                        if (dataElement.TryGetProperty("attributes", out JsonElement attributesElement))
                        {
                            // Status
                            if (attributesElement.TryGetProperty("status", out JsonElement statusElement) && statusElement.ValueKind == JsonValueKind.String)
                            {
                                report.Status = statusElement.GetString();
                            }

                            // Results
                            if (attributesElement.TryGetProperty("results", out JsonElement resultsElement))
                                report.Results = ParseResults(resultsElement);
                        }
                        if (dataElement.TryGetProperty("type", out JsonElement typeElement) && typeElement.ValueKind == JsonValueKind.String)
                        {
                            report.Type = typeElement.GetString();
                        }

                        if (dataElement.TryGetProperty("id", out JsonElement idElement) && idElement.ValueKind == JsonValueKind.String)
                        {
                            report.Id = idElement.GetString();
                        }

                        if (dataElement.TryGetProperty("links", out JsonElement linksElement))
                        {
                            if (linksElement.TryGetProperty("self", out JsonElement selfLinkElement) && selfLinkElement.ValueKind == JsonValueKind.String)
                            {
                                report.SelfLink = selfLinkElement.GetString();
                            }
                        }

                    }
                    // File info
                    if (document.RootElement.TryGetProperty("meta", out JsonElement metaElement))
                    {
                        if (metaElement.TryGetProperty("file_info", out JsonElement fileInfoElement))
                        {
                            report.FileInfo = ParseFileInfo(fileInfoElement);
                        }
                    }
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing VirusTotal response: {ex.Message}");
            }
            // Mark it as complete
            report.IsComplete = true;

            return report;
        }

        private Dictionary<string, EngineResult> ParseResults(JsonElement resultsElement)
        {
            var results = new Dictionary<string, EngineResult>();

            foreach (JsonProperty property in resultsElement.EnumerateObject())
            {
                string engineName = property.Name;
                JsonElement engineElement = property.Value;

                var engineResult = new EngineResult();
                engineResult.EngineName = engineName;

                if (engineElement.TryGetProperty("category", out JsonElement categoryElement))
                {
                    engineResult.Category = categoryElement.GetString();
                }

                if (engineElement.TryGetProperty("engine_version", out JsonElement engineVersionElement))
                {
                    engineResult.EngineVersion = engineVersionElement.GetString();
                }

                if (engineElement.TryGetProperty("result", out JsonElement resultElement))
                {
                    engineResult.Result = resultElement.GetString();
                }

                if (engineElement.TryGetProperty("method", out JsonElement methodElement))
                {
                    engineResult.Method = methodElement.GetString();
                }

                if (engineElement.TryGetProperty("engine_update", out JsonElement engineUpdateElement))
                {
                    engineResult.EngineUpdate = engineUpdateElement.GetString();
                }
                results.Add(engineName, engineResult);
            }
            return results;
        }

        private Error ParseErrorMessage(JsonElement errorMessage)
        {
            Error error = new Error();
            // Message
            if (errorMessage.TryGetProperty("message", out JsonElement messageElement))
            {
                error.Message = messageElement.GetString();
            }
            // Code
            if (errorMessage.TryGetProperty("code", out JsonElement codeElement))
            {
                error.Code = codeElement.GetString();
            }
            return error;
        }

        private Meta.FileInfo ParseFileInfo(JsonElement fileInfoElement)
        {
            var fileInfo = new Meta.FileInfo();

            if (fileInfoElement.TryGetProperty("sha256", out JsonElement sha256Element) && sha256Element.ValueKind == JsonValueKind.String)
            {
                fileInfo.SHA256 = sha256Element.GetString();
            }

            if (fileInfoElement.TryGetProperty("sha1", out JsonElement sha1Element) && sha1Element.ValueKind == JsonValueKind.String)
            {
                fileInfo.SHA1 = sha1Element.GetString();
            }

            if (fileInfoElement.TryGetProperty("md5", out JsonElement md5Element) && md5Element.ValueKind == JsonValueKind.String)
            {
                fileInfo.MD5 = md5Element.GetString();
            }

            if (fileInfoElement.TryGetProperty("size", out JsonElement sizeElement) && sizeElement.ValueKind == JsonValueKind.Number)
            {
                fileInfo.Size = sizeElement.GetInt32();
            }

            return fileInfo;
        }
    }
}
