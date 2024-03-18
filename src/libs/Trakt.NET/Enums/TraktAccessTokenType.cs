using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    [TraktEnum]
    [JsonConverter(typeof(TraktAccessTokenTypeJsonConverter))]
    public enum TraktAccessTokenType
    {
        Unspecified,
        Bearer
    }
}
