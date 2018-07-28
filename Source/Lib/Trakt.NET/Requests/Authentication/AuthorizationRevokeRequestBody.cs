namespace TraktNet.Requests.Authentication
{
    using Extensions;
    using Interfaces;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class AuthorizationRevokeRequestBody : IRequestBody
    {
        internal string AccessToken { get; set; }

        internal string ClientId { get; set; }

        internal string ClientSecret { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
            => Task.FromResult(HttpContentAsString);

        private string HttpContentAsString => $"{{ \"token\": \"{AccessToken}\", \"client_id\": \"{ClientId}\"," +
                                              $" \"client_secret\": \"{ClientSecret}\" }}";

        public void Validate()
        {
            if (string.IsNullOrEmpty(AccessToken) || AccessToken.ContainsSpace())
                throw new ArgumentException("access token not valid", nameof(AccessToken));

            if (string.IsNullOrEmpty(ClientId) || ClientId.ContainsSpace())
                throw new ArgumentException("client id not valid", nameof(ClientId));

            if (string.IsNullOrEmpty(ClientSecret) || ClientSecret.ContainsSpace())
                throw new ArgumentException("client secret not valid", nameof(ClientSecret));
        }
    }
}
