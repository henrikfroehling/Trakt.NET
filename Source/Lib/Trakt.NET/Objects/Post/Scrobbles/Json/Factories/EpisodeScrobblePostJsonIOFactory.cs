namespace TraktNet.Objects.Post.Scrobbles.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class EpisodeScrobblePostJsonIOFactory : IJsonIOFactory<ITraktEpisodeScrobblePost>
    {
        public IObjectJsonReader<ITraktEpisodeScrobblePost> CreateObjectReader() => new EpisodeScrobblePostObjectJsonReader();

        public IObjectJsonWriter<ITraktEpisodeScrobblePost> CreateObjectWriter() => new EpisodeScrobblePostObjectJsonWriter();
    }
}
