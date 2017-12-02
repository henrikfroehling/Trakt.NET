namespace TraktApiSharp.Objects.Post.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundEpisode> CreateObjectReader() => new PostResponseNotFoundEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundEpisode> CreateArrayReader() => new PostResponseNotFoundEpisodeArrayJsonReader();
    }
}
