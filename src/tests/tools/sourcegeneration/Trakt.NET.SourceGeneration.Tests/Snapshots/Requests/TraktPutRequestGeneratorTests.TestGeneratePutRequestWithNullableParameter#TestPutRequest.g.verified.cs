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
        internal string? Id { get; set; }

        internal TestPutRequest() : base(HttpMethod.Put, (Uri?)null) { }

        internal override void BuildUri()
        {
            string uriPath = $"notes/{Id}".Replace("//", "/");
            string? encodedUriPath = HttpUtility.UrlEncode(uriPath, Encoding.UTF8);
            RequestUri = new Uri(encodedUriPath);
        }
    }
}
