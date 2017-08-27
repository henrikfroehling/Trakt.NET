namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CommentJsonReaderFactory : IJsonReaderFactory<ITraktComment>
    {
        public IObjectJsonReader<ITraktComment> CreateObjectReader() => new CommentObjectJsonReader();

        public IArrayJsonReader<ITraktComment> CreateArrayReader() => new CommentArrayJsonReader();
    }
}
