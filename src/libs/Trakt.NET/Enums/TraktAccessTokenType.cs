using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Determines the type of an access token.</summary>
    [TraktEnum]
    [JsonConverter(typeof(TraktAccessTokenTypeJsonConverter))]
    public enum TraktAccessTokenType
    {
        /// <summary>An invalid access token type.</summary>
        Unspecified,

        /// <summary>The access token type for Bearer tokens.</summary>
        Bearer
    }
}
