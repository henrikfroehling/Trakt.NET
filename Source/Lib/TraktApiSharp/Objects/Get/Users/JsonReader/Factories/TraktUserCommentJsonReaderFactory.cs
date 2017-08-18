namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktUserCommentJsonReaderFactory : IJsonReaderFactory<ITraktUserComment>
    {
        public ITraktObjectJsonReader<ITraktUserComment> CreateObjectReader() => new TraktUserCommentObjectJsonReader();

        public IArrayJsonReader<ITraktUserComment> CreateArrayReader() => new TraktUserCommentArrayJsonReader();
    }
}
