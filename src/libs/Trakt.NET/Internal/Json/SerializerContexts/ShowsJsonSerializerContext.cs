#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShow>))]
    [JsonSerializable(typeof(TraktShowAirs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowAirs>))]
    [JsonSerializable(typeof(TraktShowIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowIDs>))]
    [JsonSerializable(typeof(TraktShowImages))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowImages>))]
    [JsonSerializable(typeof(TraktShowMinimal))]
    [JsonSerializable(typeof(IReadOnlyList<TraktShowMinimal>))]
    public sealed partial class ShowsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
