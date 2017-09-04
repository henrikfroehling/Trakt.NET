namespace TraktApiSharp.Objects.Post.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class PostResponseNotFoundSeasonJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundSeason> CreateObjectReader() => new PostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundSeason> CreateArrayReader() => new PostResponseNotFoundSeasonArrayJsonReader();
    }
}
