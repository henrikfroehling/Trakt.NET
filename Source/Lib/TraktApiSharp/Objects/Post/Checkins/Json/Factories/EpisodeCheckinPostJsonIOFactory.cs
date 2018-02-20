namespace TraktApiSharp.Objects.Post.Checkins.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class EpisodeCheckinPostJsonIOFactory : IJsonIOFactory<ITraktEpisodeCheckinPost>
    {
        public IObjectJsonReader<ITraktEpisodeCheckinPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktEpisodeCheckinPost)} is not supported.");

        public IArrayJsonReader<ITraktEpisodeCheckinPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeCheckinPost)} is not supported.");

        public IObjectJsonWriter<ITraktEpisodeCheckinPost> CreateObjectWriter() => new EpisodeCheckinPostObjectJsonWriter();
    }
}
