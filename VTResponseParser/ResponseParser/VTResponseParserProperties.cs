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
        /// <summary>
        /// Represents the links associated with the VirusTotal API response.
        /// </summary>
        public LinksResponse Links { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public Dictionary<string, EngineResult> Results { get; set; }
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
        /// <summary>
        /// Indicates whether the response parsing is complete.
        /// Note: This property is not part of the VirusTotal API.
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
