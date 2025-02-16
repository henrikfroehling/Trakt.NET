namespace TraktNET
{
    public sealed class TMDBContext : ITraktContext
    {
        private string _readAccessToken = string.Empty;

        public string ID { get; } = Guid.NewGuid().ToString();

        public Uri BaseUri { get; internal set; }

        internal TMDBContext(string readAccessToken)
        {
            ReadAccessToken = readAccessToken;
            BaseUri = new Uri($"{TMDBConstants.API.BaseURL}{TMDBConstants.API.Version}/");
            HttpClientProvider = new TMDBHttpClientProvider();
        }

        internal string ReadAccessToken
        {
            get => _readAccessToken;

            set
            {
                ArgumentValidator.ThrowIfNullOrWhiteSpace(value, "read access token must not be null or empty or only whitespace", checkSpaces: true);
                _readAccessToken = value;
            }
        }

        internal HttpClientProvider<TMDBContext> HttpClientProvider { get; set; }

        internal HttpClient GetHttpClient() => HttpClientProvider.GetHttpClient(this);
    }
}
