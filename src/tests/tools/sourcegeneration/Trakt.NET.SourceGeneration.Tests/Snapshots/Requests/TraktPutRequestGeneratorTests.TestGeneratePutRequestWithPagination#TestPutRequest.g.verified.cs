﻿//-----------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Trakt.NET source generator.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------------------------------

#nullable enable

using System.Text;
using System.Web;

namespace SourceGeneraterTestNamespace
{
    internal sealed partial class TestPutRequest : HttpRequestMessage
    {
        internal uint? Page { get; set; }

        internal uint? Limit { get; set; }

        private TestPutRequest() : base(HttpMethod.Put, (Uri?)null) { }

        internal void BuildUri()
        {
            List<string> queries = [];
            string requestUri = $"notes";

            if (Page.HasValue && Page.Value > 0)
            {
                queries.Add($"page={Page.Value}");
            }

            if (Limit.HasValue && Limit.Value > 0)
            {
                queries.Add($"limit={Limit.Value}");
            }

            if (queries.Count > 0)
            {
                requestUri = requestUri + "?" + string.Join("&", queries);
            }

            string? encodedUriPath = HttpUtility.UrlEncode(requestUri, Encoding.UTF8);
            RequestUri = new Uri(encodedUriPath);
        }
    }
}
