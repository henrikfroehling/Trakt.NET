namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktUserCommentJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserComment>
    {
        public ITraktObjectJsonReader<ITraktUserComment> CreateObjectReader() => new TraktUserCommentObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserComment> CreateArrayReader() => new TraktUserCommentArrayJsonReader();
    }
}
