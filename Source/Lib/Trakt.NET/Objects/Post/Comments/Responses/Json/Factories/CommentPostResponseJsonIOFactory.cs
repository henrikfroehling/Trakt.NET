namespace TraktNet.Objects.Post.Comments.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class CommentPostResponseJsonIOFactory : IJsonIOFactory<ITraktCommentPostResponse>
    {
        public IObjectJsonReader<ITraktCommentPostResponse> CreateObjectReader() => new CommentPostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktCommentPostResponse> CreateObjectWriter() => new CommentPostResponseObjectJsonWriter();
    }
}
