namespace TraktNet.Requests.Authentication
{
    using Enums;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class AuthorizationRequestBody : IRequestBody
    {
        internal string Code { get; set; }

        internal string ClientId { get; set; }

        internal string ClientSecret { get; set; }

        internal string RedirectUri { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HttpContentAsString);
        }

        private string HttpContentAsString => $"{{ \"code\": \"{Code}\", \"client_id\": \"{ClientId}\", " +
                                              $"\"client_secret\": \"{ClientSecret}\", \"redirect_uri\": " +
                                              $"\"{RedirectUri}\", \"grant_type\": \"{TraktAccessTokenGrantType.AuthorizationCode.ObjectName}\" }}";

        public void Validate()
        {
            if (string.IsNullOrEmpty(Code) || Code.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Code), "code not valid");

            if (string.IsNullOrEmpty(ClientId) || ClientId.ContainsSpace())
                throw new TraktRequestValidationException(nameof(ClientId), "client id not valid");

            if (string.IsNullOrEmpty(ClientSecret) || ClientSecret.ContainsSpace())
                throw new TraktRequestValidationException(nameof(ClientSecret), "client secret not valid");

            if (string.IsNullOrEmpty(RedirectUri) || RedirectUri.ContainsSpace())
                throw new TraktRequestValidationException(nameof(RedirectUri), "redirect uri not valid");
        }
    }
}
