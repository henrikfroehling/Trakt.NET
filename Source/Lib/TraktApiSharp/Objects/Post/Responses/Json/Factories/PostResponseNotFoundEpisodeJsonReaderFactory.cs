namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundEpisodeJsonReaderFactory : IJsonIOFactory<ITraktPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundEpisode> CreateObjectReader() => new PostResponseNotFoundEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundEpisode> CreateArrayReader() => new PostResponseNotFoundEpisodeArrayJsonReader();

        public IObjectJsonReader<ITraktPostResponseNotFoundEpisode> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktPostResponseNotFoundEpisode> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
