using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApplication4.Web.Infrastructure
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public Guid ScanId { get; set; }

        public CustomMultipartFormDataStreamProvider(string path)
            : base(path)
        {
            ScanId = Guid.NewGuid();
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var originalName = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
            originalName = originalName.Replace("\"", string.Empty);
            var name = originalName.Replace(originalName.Substring(0, originalName.IndexOf('.')), ScanId.ToString());
            return name;
        }
    }
}