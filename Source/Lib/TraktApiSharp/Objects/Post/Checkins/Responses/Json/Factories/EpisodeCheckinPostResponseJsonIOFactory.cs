namespace TraktNet.Objects.Post.Checkins.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class EpisodeCheckinPostResponseJsonIOFactory : IJsonIOFactory<ITraktEpisodeCheckinPostResponse>
    {
        public IObjectJsonReader<ITraktEpisodeCheckinPostResponse> CreateObjectReader() => new EpisodeCheckinPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeCheckinPostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeCheckinPostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktEpisodeCheckinPostResponse> CreateObjectWriter() => new EpisodeCheckinPostResponseObjectJsonWriter();
    }
}
