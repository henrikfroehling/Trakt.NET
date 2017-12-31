namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class CommentJsonIOFactory : IJsonIOFactory<ITraktComment>
    {
        public IObjectJsonReader<ITraktComment> CreateObjectReader() => new CommentObjectJsonReader();

        public IArrayJsonReader<ITraktComment> CreateArrayReader() => new CommentArrayJsonReader();

        public IObjectJsonWriter<ITraktComment> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktComment> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
