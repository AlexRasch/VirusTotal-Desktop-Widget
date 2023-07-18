using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusTotal
{
    // This file contains the properties for the VTResponseParser class that represent the response data from the VirusTotal API.
    public partial class ResponseParser
    {
        public ResponseParser.Error? ErrorCode { get; set; }
        public Meta.FileInfo FileInfo { get; set; }
        #region Data
        #region Attributes
        /// <summary>
        /// Get or set Unix epoch UTC time (seconds).
        /// </summary>
        public int Date { get; set; }
        public string Status { get; set; }
        /// <summary>
        /// Summary of the results field.
        /// </summary>
        public DataStats Stats { get; set; }
        /// <summary>
        /// Represents the result of an antivirus engine in the VirusTotal API response.
        /// </summary>
        public Dictionary<string, EngineResult> Results { get; set; }
        #endregion

        /// <summary>
        /// Represents the links associated with the VirusTotal API response.
        /// </summary>

        public string Type { get; set; }
        public string Id { get; set; }
        public LinksResponse Links { get; set; }
        #endregion

        #region Extra (not part of the VirusTotal API)
        /// <summary>
        /// Indicates whether the response parsing is complete.
        /// Note: This property is not part of the VirusTotal API.
        /// </summary>
        public bool IsComplete { get; set; }
        #endregion

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

        /// <summary>
        /// Represents the summary of the results field.
        /// </summary>
        public struct DataStats
        {
            /// <summary>
            /// Gets or sets the number of AV engines that reach a timeout when analyzing the file.
            /// </summary>
            public int ConfirmedTimeout { get; set; }
            /// <summary>
            /// Gets or sets the number of AV engines that fail when analysing that file.
            /// </summary>
            public int Failure { get; set; }
            /// <summary>
            /// Gets or sets the number of reports saying that is harmless.
            /// </summary>
            public int Harmless { get; set; }
            /// <summary>
            ///  Gets or sets the number of reports saying that is malicious.
            /// </summary>
            public int Malicious { get; set; }
            /// <summary>
            /// Gets or sets the number of reports saying that is suspicious.
            /// </summary>
            public int Suspicious { get; set; }
            /// <summary>
            /// Gets or sets the number of timeouts when analysing this URL/file.
            /// </summary>
            public int Timeout { get; set; }
            /// <summary>
            ///  Gets or sets the number of AV engines that don't support that type of file.
            /// </summary>
            public int TypeUnsupported { get; set; }
            /// <summary>
            /// Gets or sets the number of reports saying that is undetected.
            /// </summary>
            public int Undetected { get; set; }
        }

        /// <summary>
        /// Represents the result of an antivirus engine in the VirusTotal API response.
        /// </summary>
        public class EngineResult
        {
            /// <summary>
            /// Gets or sets the category of the engine result.
            /// </summary>
            public string? Category { get; set; }

            /// <summary>
            /// Gets or sets the name of the antivirus engine.
            /// </summary>
            public string? EngineName { get; set; }

            /// <summary>
            /// Gets or sets the version of the antivirus engine.
            /// </summary>
            public string? EngineVersion { get; set; }

            /// <summary>
            /// Gets or sets the result of the antivirus scan.
            /// </summary>
            public string? Result { get; set; }

            /// <summary>
            /// Gets or sets the method used for the scan.
            /// </summary>
            public string? Method { get; set; }

            /// <summary>
            /// Gets or sets the last update date of the antivirus engine.
            /// </summary>
            public string? EngineUpdate { get; set; }
        }

        /// <summary>
        /// Represents the links associated with the VirusTotal API response.
        /// </summary>
        public struct LinksResponse
        {
            /// <summary>
            /// Gets or sets the link to the item related to the analysis.
            /// </summary>
            public string Item { get; set; }
            /// <summary>
            /// Gets or sets the link to the self-analysis result.
            /// </summary>
            public string Self { get; set; }
        }


    }
}
