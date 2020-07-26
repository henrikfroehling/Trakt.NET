namespace TraktNet.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class ShowCommentPostJsonIOFactory : IJsonIOFactory<ITraktShowCommentPost>
    {
        public IObjectJsonReader<ITraktShowCommentPost> CreateObjectReader() => new ShowCommentPostObjectJsonReader();

        public IObjectJsonWriter<ITraktShowCommentPost> CreateObjectWriter() => new ShowCommentPostObjectJsonWriter();
    }
}
