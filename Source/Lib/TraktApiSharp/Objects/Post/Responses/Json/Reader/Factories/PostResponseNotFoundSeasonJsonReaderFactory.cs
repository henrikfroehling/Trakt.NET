namespace TraktApiSharp.Objects.Post.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundSeasonJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundSeason> CreateObjectReader() => new PostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundSeason> CreateArrayReader() => new PostResponseNotFoundSeasonArrayJsonReader();
    }
}
