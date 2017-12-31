namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundSeasonJsonIOFactory : IJsonIOFactory<ITraktPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundSeason> CreateObjectReader() => new PostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundSeason> CreateArrayReader() => new PostResponseNotFoundSeasonArrayJsonReader();

        public IObjectJsonWriter<ITraktPostResponseNotFoundSeason> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktPostResponseNotFoundSeason> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
