namespace TraktNet.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class ListCommentPostJsonIOFactory : IJsonIOFactory<ITraktListCommentPost>
    {
        public IObjectJsonReader<ITraktListCommentPost> CreateObjectReader() => new ListCommentPostObjectJsonReader();

        public IObjectJsonWriter<ITraktListCommentPost> CreateObjectWriter() => new ListCommentPostObjectJsonWriter();
    }
}
