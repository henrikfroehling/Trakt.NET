namespace TraktApiSharp.Objects.Post.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktPostResponseNotFoundSeasonJsonReaderFactory : ITraktJsonReaderFactory<ITraktPostResponseNotFoundSeason>
    {
        public ITraktObjectJsonReader<ITraktPostResponseNotFoundSeason> CreateObjectReader() => new TraktPostResponseNotFoundSeasonObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPostResponseNotFoundSeason> CreateArrayReader() => new TraktPostResponseNotFoundSeasonArrayJsonReader();
    }
}
