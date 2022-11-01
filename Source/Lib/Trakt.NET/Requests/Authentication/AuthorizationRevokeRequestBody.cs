namespace TraktNet.Requests.Authentication
{
    using Exceptions;
    using Extensions;
    using Interfaces;
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
                throw new TraktRequestValidationException(nameof(AccessToken), "access token not valid");

            if (string.IsNullOrEmpty(ClientId) || ClientId.ContainsSpace())
                throw new TraktRequestValidationException(nameof(ClientId), "client id not valid");

            if (string.IsNullOrEmpty(ClientSecret) || ClientSecret.ContainsSpace())
                throw new TraktRequestValidationException(nameof(ClientSecret), "client secret not valid");
        }
    }
}
