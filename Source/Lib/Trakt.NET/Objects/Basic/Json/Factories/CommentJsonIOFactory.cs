namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CommentJsonIOFactory : IJsonIOFactory<ITraktComment>
    {
        public IObjectJsonReader<ITraktComment> CreateObjectReader() => new CommentObjectJsonReader();

        public IObjectJsonWriter<ITraktComment> CreateObjectWriter() => new CommentObjectJsonWriter();
    }
}
