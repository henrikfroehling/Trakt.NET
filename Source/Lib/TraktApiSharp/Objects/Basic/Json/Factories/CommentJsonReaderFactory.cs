namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Json;

    internal class CommentJsonReaderFactory : IJsonReaderFactory<ITraktComment>
    {
        public IObjectJsonReader<ITraktComment> CreateObjectReader() => new CommentObjectJsonReader();

        public IArrayJsonReader<ITraktComment> CreateArrayReader() => new CommentArrayJsonReader();
    }
}
