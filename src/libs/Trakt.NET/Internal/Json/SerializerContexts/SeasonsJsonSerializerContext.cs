#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktSeason))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSeason>))]
    [JsonSerializable(typeof(TraktSeasonIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSeasonIDs>))]
    [JsonSerializable(typeof(TraktSeasonImages))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSeasonImages>))]
    [JsonSerializable(typeof(TraktSeasonMinimal))]
    [JsonSerializable(typeof(IReadOnlyList<TraktSeasonMinimal>))]
    public sealed partial class SeasonsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
