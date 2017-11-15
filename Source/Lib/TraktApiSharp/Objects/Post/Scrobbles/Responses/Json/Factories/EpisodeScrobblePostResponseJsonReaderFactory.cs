namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.Json.Factories
{
    using Objects.Json;
    using System;

    internal class EpisodeScrobblePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktEpisodeScrobblePostResponse>
    {
        public IObjectJsonReader<ITraktEpisodeScrobblePostResponse> CreateObjectReader() => new EpisodeScrobblePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeScrobblePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeScrobblePostResponse)} is not supported.");
        }
    }
}
