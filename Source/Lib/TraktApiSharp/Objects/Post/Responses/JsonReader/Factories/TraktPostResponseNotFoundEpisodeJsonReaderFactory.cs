namespace TraktApiSharp.Objects.Post.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktPostResponseNotFoundEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundEpisode>
    {
        public ITraktObjectJsonReader<ITraktPostResponseNotFoundEpisode> CreateObjectReader() => new TraktPostResponseNotFoundEpisodeObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPostResponseNotFoundEpisode> CreateArrayReader() => new TraktPostResponseNotFoundEpisodeArrayJsonReader();
    }
}
