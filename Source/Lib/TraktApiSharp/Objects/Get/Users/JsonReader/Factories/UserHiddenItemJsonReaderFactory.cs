namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class UserHiddenItemJsonReaderFactory : IJsonReaderFactory<ITraktUserHiddenItem>
    {
        public IObjectJsonReader<ITraktUserHiddenItem> CreateObjectReader() => new UserHiddenItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItem> CreateArrayReader() => new UserHiddenItemArrayJsonReader();
    }
}
