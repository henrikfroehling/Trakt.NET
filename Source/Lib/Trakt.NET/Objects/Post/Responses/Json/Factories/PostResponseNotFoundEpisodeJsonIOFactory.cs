namespace TraktNet.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class PostResponseNotFoundEpisodeJsonIOFactory : IJsonIOFactory<ITraktPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundEpisode> CreateObjectReader() => new PostResponseNotFoundEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktPostResponseNotFoundEpisode> CreateObjectWriter() => new PostResponseNotFoundEpisodeObjectJsonWriter();
    }
}
