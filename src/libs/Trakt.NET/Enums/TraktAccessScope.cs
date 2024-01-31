using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    [TraktEnum]
    [JsonConverter(typeof(TraktAccessScopeJsonConverter))]
    public enum TraktAccessScope
    {
        Unspecified,
        Private,
        Friends,
        Public
    }
}
