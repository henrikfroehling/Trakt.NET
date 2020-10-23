namespace TraktNet.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SeasonCommentPostJsonIOFactory : IJsonIOFactory<ITraktSeasonCommentPost>
    {
        public IObjectJsonReader<ITraktSeasonCommentPost> CreateObjectReader() => new SeasonCommentPostObjectJsonReader();

        public IObjectJsonWriter<ITraktSeasonCommentPost> CreateObjectWriter() => new SeasonCommentPostObjectJsonWriter();
    }
}
