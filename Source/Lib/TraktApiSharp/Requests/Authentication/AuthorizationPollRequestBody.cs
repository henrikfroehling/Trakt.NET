namespace TraktApiSharp.Requests.Authentication
{
    using Core;
    using Extensions;
    using Interfaces;
    using Objects.Authentication;
    using System;
    using System.Net.Http;
    using System.Text;
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

        public HttpContent ToHttpContent() => new StringContent(HttpContentAsString, Encoding.UTF8, Constants.MEDIA_TYPE);

        public void Validate()
        {
            if (Device == null)
                throw new ArgumentNullException(nameof(Device));

            if (Device.IsExpiredUnused)
                throw new ArgumentException("device code expired unused", nameof(Device));

            if (!Device.IsValid)
                throw new ArgumentException("device not valid", nameof(Device));

            if (Device.DeviceCode.ContainsSpace())
                throw new ArgumentException("device code not valid", nameof(Device.DeviceCode));

            if (string.IsNullOrEmpty(ClientId) || ClientId.ContainsSpace())
                throw new ArgumentException("client id not valid", nameof(ClientId));

            if (string.IsNullOrEmpty(ClientSecret) || ClientSecret.ContainsSpace())
                throw new ArgumentException("client secret not valid", nameof(ClientSecret));
        }
    }
}
