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
    internal sealed partial class TestPostRequest : HttpRequestMessage
    {
        internal string? Id { get; set; }

        private TestPostRequest() : base(HttpMethod.Post, (Uri?)null) { }

        internal void BuildUri()
        {
            string uriPath = $"notes/{Id}".Replace("//", "/");
            string? encodedUriPath = HttpUtility.UrlEncode(uriPath, Encoding.UTF8);
            RequestUri = new Uri(encodedUriPath);
        }
    }
}
