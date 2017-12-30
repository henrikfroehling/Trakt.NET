namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundSeasonJsonReaderFactory : IJsonIOFactory<ITraktPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundSeason> CreateObjectReader() => new PostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundSeason> CreateArrayReader() => new PostResponseNotFoundSeasonArrayJsonReader();

        public IObjectJsonReader<ITraktPostResponseNotFoundSeason> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktPostResponseNotFoundSeason> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
