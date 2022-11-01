namespace TraktNet.Requests.Authentication
{
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Authentication;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class AuthorizationPollRequestBody : IRequestBody
    {
        internal ITraktDevice Device { get; set; }

        internal string ClientId { get; set; }

        internal string ClientSecret { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HttpContentAsString);
        }

        private string HttpContentAsString => $"{{ \"code\": \"{Device.DeviceCode}\", \"client_id\": \"{ClientId}\", \"client_secret\": \"{ClientSecret}\" }}";

        public void Validate()
        {
            if (Device == null)
                throw new TraktRequestValidationException(nameof(Device), "device must not be null");

            if (Device.IsExpiredUnused)
                throw new TraktRequestValidationException(nameof(Device), "device code expired unused");

            if (!Device.IsValid)
                throw new TraktRequestValidationException(nameof(Device), "device not valid");

            if (Device.DeviceCode.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Device.DeviceCode), "device code not valid");

            if (string.IsNullOrEmpty(ClientId) || ClientId.ContainsSpace())
                throw new TraktRequestValidationException(nameof(ClientId), "client id not valid");

            if (string.IsNullOrEmpty(ClientSecret) || ClientSecret.ContainsSpace())
                throw new TraktRequestValidationException(nameof(ClientSecret), "client secret not valid");
        }
    }
}
