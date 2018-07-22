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

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HttpContentAsString);
        }

        private string HttpContentAsString => $"token={AccessToken}";

        public void Validate()
        {
            if (string.IsNullOrEmpty(AccessToken) || AccessToken.ContainsSpace())
                throw new ArgumentException("access token not valid", nameof(AccessToken));
        }
    }
}
