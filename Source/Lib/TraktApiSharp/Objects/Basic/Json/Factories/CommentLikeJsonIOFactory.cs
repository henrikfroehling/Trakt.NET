namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CommentLikeJsonIOFactory : IJsonIOFactory<ITraktCommentLike>
    {
        public IObjectJsonReader<ITraktCommentLike> CreateObjectReader() => new CommentLikeObjectJsonReader();

        public IArrayJsonReader<ITraktCommentLike> CreateArrayReader() => new CommentLikeArrayJsonReader();

        public IObjectJsonWriter<ITraktCommentLike> CreateObjectWriter() => new CommentLikeObjectJsonWriter();
    }
}
