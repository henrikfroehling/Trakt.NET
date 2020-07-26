namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CommentItemJsonIOFactory : IJsonIOFactory<ITraktCommentItem>
    {
        public IObjectJsonReader<ITraktCommentItem> CreateObjectReader() => new CommentItemObjectJsonReader();

        public IObjectJsonWriter<ITraktCommentItem> CreateObjectWriter() => new CommentItemObjectJsonWriter();
    }
}
