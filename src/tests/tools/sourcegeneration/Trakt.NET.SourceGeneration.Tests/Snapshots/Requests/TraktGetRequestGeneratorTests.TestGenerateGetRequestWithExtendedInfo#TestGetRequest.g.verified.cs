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
    internal sealed partial class TestGetRequest : HttpRequestMessage
    {
        internal TraktExtendedInfo? ExtendedInfo { get; set; }

        private TestGetRequest() : base(HttpMethod.Get, (Uri?)null) { }

        internal void BuildUri()
        {
            List<string> queries = [];
            string requestUri = $"notes";

            if (ExtendedInfo.HasValue && ExtendedInfo.Value != TraktExtendedInfo.None)
            {
                queries.Add(ExtendedInfo.Value.ToUriPath());
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
