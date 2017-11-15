namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;

    internal class PostResponseNotFoundSeasonJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundSeason> CreateObjectReader() => new PostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundSeason> CreateArrayReader() => new PostResponseNotFoundSeasonArrayJsonReader();
    }
}
