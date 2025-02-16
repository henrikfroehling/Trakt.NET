#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TMDBConfiguration))]
    [JsonSerializable(typeof(IReadOnlyList<TMDBConfiguration>))]
    [JsonSerializable(typeof(TMDBConfigurationImages))]
    [JsonSerializable(typeof(IReadOnlyList<TMDBConfigurationImages>))]
    [JsonSerializable(typeof(TMDBEpisodeImages))]
    [JsonSerializable(typeof(IReadOnlyList<TMDBEpisodeImages>))]
    [JsonSerializable(typeof(TMDBErrorResponse))]
    [JsonSerializable(typeof(IReadOnlyList<TMDBErrorResponse>))]
    [JsonSerializable(typeof(TMDBImage))]
    [JsonSerializable(typeof(IReadOnlyList<TMDBImage>))]
    [JsonSerializable(typeof(TMDBMovieImages))]
    [JsonSerializable(typeof(IReadOnlyList<TMDBMovieImages>))]
    [JsonSerializable(typeof(TMDBPersonImages))]
    [JsonSerializable(typeof(IReadOnlyList<TMDBPersonImages>))]
    [JsonSerializable(typeof(TMDBSeasonImages))]
    [JsonSerializable(typeof(IReadOnlyList<TMDBSeasonImages>))]
    [JsonSerializable(typeof(TMDBShowImages))]
    [JsonSerializable(typeof(IReadOnlyList<TMDBShowImages>))]
    [JsonSerializable(typeof(TMDBVideo))]
    [JsonSerializable(typeof(IReadOnlyList<TMDBVideo>))]
    [JsonSerializable(typeof(TMDBVideos))]
    [JsonSerializable(typeof(IReadOnlyList<TMDBVideos>))]
    public sealed partial class TMDBJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
