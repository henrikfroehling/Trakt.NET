namespace TraktApiSharp.Objects.Post.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class PostResponseNotFoundEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundEpisode> CreateObjectReader() => new PostResponseNotFoundEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundEpisode> CreateArrayReader() => new PostResponseNotFoundEpisodeArrayJsonReader();
    }
}
