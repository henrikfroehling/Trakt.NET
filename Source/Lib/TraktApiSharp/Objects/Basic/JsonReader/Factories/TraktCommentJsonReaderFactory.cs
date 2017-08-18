namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCommentJsonReaderFactory : IJsonReaderFactory<ITraktComment>
    {
        public IObjectJsonReader<ITraktComment> CreateObjectReader() => new TraktCommentObjectJsonReader();

        public IArrayJsonReader<ITraktComment> CreateArrayReader() => new TraktCommentArrayJsonReader();
    }
}
