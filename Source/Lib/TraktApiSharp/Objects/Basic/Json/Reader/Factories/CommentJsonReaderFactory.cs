namespace TraktApiSharp.Objects.Basic.Json.Factories.Reader
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class CommentJsonReaderFactory : IJsonReaderFactory<ITraktComment>
    {
        public IObjectJsonReader<ITraktComment> CreateObjectReader() => new CommentObjectJsonReader();

        public IArrayJsonReader<ITraktComment> CreateArrayReader() => new CommentArrayJsonReader();
    }
}
