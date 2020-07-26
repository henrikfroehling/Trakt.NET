namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CommentLikeJsonIOFactory : IJsonIOFactory<ITraktCommentLike>
    {
        public IObjectJsonReader<ITraktCommentLike> CreateObjectReader() => new CommentLikeObjectJsonReader();

        public IObjectJsonWriter<ITraktCommentLike> CreateObjectWriter() => new CommentLikeObjectJsonWriter();
    }
}
