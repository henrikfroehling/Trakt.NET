namespace TraktNet.Objects.Post.Scrobbles.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class EpisodeScrobblePostJsonIOFactory : IJsonIOFactory<ITraktEpisodeScrobblePost>
    {
        public IObjectJsonReader<ITraktEpisodeScrobblePost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktEpisodeScrobblePost)} is not supported.");

        public IArrayJsonReader<ITraktEpisodeScrobblePost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeScrobblePost)} is not supported.");

        public IObjectJsonWriter<ITraktEpisodeScrobblePost> CreateObjectWriter() => new EpisodeScrobblePostObjectJsonWriter();
    }
}
