namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class PostResponseNotFoundEpisodeJsonIOFactory : IJsonIOFactory<ITraktPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundEpisode> CreateObjectReader() => new PostResponseNotFoundEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundEpisode> CreateArrayReader() => new PostResponseNotFoundEpisodeArrayJsonReader();

        public IObjectJsonWriter<ITraktPostResponseNotFoundEpisode> CreateObjectWriter() => new PostResponseNotFoundEpisodeObjectJsonWriter();
    }
}
