using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    [TraktEnum]
    [JsonConverter(typeof(TraktAccessScopeJsonConverter))]
    public enum TraktAccessTokenType
    {
        Unspecified,
        Bearer
    }
}
