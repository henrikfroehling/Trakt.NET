namespace TraktNet.Objects.Post.Scrobbles.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class EpisodeScrobblePostResponseJsonIOFactory : IJsonIOFactory<ITraktEpisodeScrobblePostResponse>
    {
        public IObjectJsonReader<ITraktEpisodeScrobblePostResponse> CreateObjectReader() => new EpisodeScrobblePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeScrobblePostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeScrobblePostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktEpisodeScrobblePostResponse> CreateObjectWriter() => new EpisodeScrobblePostResponseObjectJsonWriter();
    }
}
