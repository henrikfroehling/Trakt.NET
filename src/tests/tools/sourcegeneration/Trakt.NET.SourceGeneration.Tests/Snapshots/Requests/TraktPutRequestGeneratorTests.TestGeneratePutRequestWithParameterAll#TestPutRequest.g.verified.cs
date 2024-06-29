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
    internal sealed partial class TestPutRequest : RequestBase
    {
        internal required string Id { get; init; }

        internal TraktExtendedInfo? ExtendedInfo { get; set; }

        internal uint? Page { get; set; }

        internal uint? Limit { get; set; }

        internal TraktOAuthRequirement OAuthRequirement { get; } = TraktOAuthRequirement.Required;

        internal TestPutRequest() : base(HttpMethod.Put, (Uri?)null) { }

        internal override void BuildUri()
        {
            List<string> queries = [];
            string requestUri = $"notes/{Id}";

            if (ExtendedInfo.HasValue && ExtendedInfo.Value != TraktExtendedInfo.None)
            {
                queries.Add(ExtendedInfo.Value.ToUriPath());
            }

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
