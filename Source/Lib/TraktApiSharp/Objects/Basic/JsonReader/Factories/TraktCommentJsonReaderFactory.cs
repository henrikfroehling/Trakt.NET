namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCommentJsonReaderFactory : ITraktJsonReaderFactory<ITraktComment>
    {
        public ITraktObjectJsonReader<ITraktComment> CreateObjectReader() => new TraktCommentObjectJsonReader();

        public ITraktArrayJsonReader<ITraktComment> CreateArrayReader() => new TraktCommentArrayJsonReader();
    }
}
