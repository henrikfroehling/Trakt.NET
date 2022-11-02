namespace TraktNet.Requests.Authentication
{
    using Exceptions;
    using Extensions;
    using Interfaces;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class DeviceRequestBody : IRequestBody
    {
        internal string ClientId { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HttpContentAsString);
        }

        private string HttpContentAsString => $"{{ \"client_id\": \"{ClientId}\" }}";

        public void Validate()
        {
            if (string.IsNullOrEmpty(ClientId) || ClientId.ContainsSpace())
                throw new TraktRequestValidationException(nameof(ClientId), "client id not valid");
        }
    }
}
