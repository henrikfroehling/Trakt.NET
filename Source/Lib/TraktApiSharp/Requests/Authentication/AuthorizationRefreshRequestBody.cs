namespace TraktApiSharp.Requests.Authentication
{
    using Core;
    using Enums;
    using Extensions;
    using Interfaces;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class AuthorizationRefreshRequestBody : IRequestBody
    {
        internal string RefreshToken { get; set; }

        internal string ClientId { get; set; }

        internal string ClientSecret { get; set; }

        internal string RedirectUri { get; set; }

        public async Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private string HttpContentAsString => $"{{ \"refresh_token\": \"{RefreshToken}\", \"client_id\": \"{ClientId}\"," +
                                              $" \"client_secret\": \"{ClientSecret}\", \"redirect_uri\": \"{RedirectUri}\"," +
                                              $" \"grant_type\": \"{TraktAccessTokenGrantType.RefreshToken.ObjectName}\" }}";

        public HttpContent ToHttpContent() => new StringContent(HttpContentAsString, Encoding.UTF8, Constants.MEDIA_TYPE);

        public void Validate()
        {
            if (string.IsNullOrEmpty(RefreshToken) || RefreshToken.ContainsSpace())
                throw new ArgumentException("refresh token not valid", nameof(RefreshToken));

            if (string.IsNullOrEmpty(ClientId) || ClientId.ContainsSpace())
                throw new ArgumentException("client id not valid", nameof(ClientId));

            if (string.IsNullOrEmpty(ClientSecret) || ClientSecret.ContainsSpace())
                throw new ArgumentException("client secret not valid", nameof(ClientSecret));

            if (string.IsNullOrEmpty(RedirectUri) || RedirectUri.ContainsSpace())
                throw new ArgumentException("redirect uri not valid", nameof(RedirectUri));
        }
    }
}
