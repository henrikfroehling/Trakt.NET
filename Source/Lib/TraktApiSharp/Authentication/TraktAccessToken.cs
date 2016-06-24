namespace TraktApiSharp.Authentication
{
    using Enums;
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public class TraktAccessToken
    {
        public TraktAccessToken()
        {
            Created = DateTime.UtcNow;
        }

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "scope")]
        [JsonConverter(typeof(TraktAccessScopeConverter))]
        public TraktAccessScope AccessScope { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresInSeconds { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        [JsonConverter(typeof(TraktAccessTokenTypeConverter))]
        public TraktAccessTokenType TokenType { get; set; }

        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(AccessToken) && !AccessToken.ContainsSpace()
                                    && (IgnoreExpiration || DateTime.UtcNow.AddSeconds(ExpiresInSeconds) > DateTime.UtcNow);

        [JsonIgnore]
        public DateTime Created { get; private set; }

        [JsonIgnore]
        internal bool IgnoreExpiration { get; set; }
    }
}
