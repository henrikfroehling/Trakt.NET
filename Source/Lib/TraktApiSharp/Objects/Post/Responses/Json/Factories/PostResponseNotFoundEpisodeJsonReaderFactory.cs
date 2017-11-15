namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;

    internal class PostResponseNotFoundEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundEpisode> CreateObjectReader() => new PostResponseNotFoundEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundEpisode> CreateArrayReader() => new PostResponseNotFoundEpisodeArrayJsonReader();
    }
}
