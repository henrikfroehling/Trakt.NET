namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class CommentJsonReaderFactory : IJsonIOFactory<ITraktComment>
    {
        public IObjectJsonReader<ITraktComment> CreateObjectReader() => new CommentObjectJsonReader();

        public IArrayJsonReader<ITraktComment> CreateArrayReader() => new CommentArrayJsonReader();

        public IObjectJsonReader<ITraktComment> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktComment> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
