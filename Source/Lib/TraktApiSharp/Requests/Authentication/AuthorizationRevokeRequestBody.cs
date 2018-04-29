namespace TraktApiSharp.Requests.Authentication
{
    using Core;
    using Extensions;
    using Interfaces;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class AuthorizationRevokeRequestBody : IRequestBody
    {
        internal string AccessToken { get; set; }

        public async Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private string HttpContentAsString => $"token={AccessToken}";

        public HttpContent ToHttpContent() => new StringContent(HttpContentAsString, Encoding.UTF8, Constants.MEDIA_TYPE_URL_ENCODED);

        public void Validate()
        {
            if (string.IsNullOrEmpty(AccessToken) || AccessToken.ContainsSpace())
                throw new ArgumentException("access token not valid", nameof(AccessToken));
        }
    }
}
