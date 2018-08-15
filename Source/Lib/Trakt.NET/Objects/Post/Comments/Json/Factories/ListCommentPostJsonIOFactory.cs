namespace TraktNet.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class ListCommentPostJsonIOFactory : IJsonIOFactory<ITraktListCommentPost>
    {
        public IObjectJsonReader<ITraktListCommentPost> CreateObjectReader() => new ListCommentPostObjectJsonReader();

        public IArrayJsonReader<ITraktListCommentPost> CreateArrayReader() => new ListCommentPostArrayJsonReader();

        public IObjectJsonWriter<ITraktListCommentPost> CreateObjectWriter() => new ListCommentPostObjectJsonWriter();
    }
}
