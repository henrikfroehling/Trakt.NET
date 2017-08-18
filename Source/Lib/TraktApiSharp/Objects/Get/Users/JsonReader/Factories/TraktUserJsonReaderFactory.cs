namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktUserJsonReaderFactory : IJsonReaderFactory<ITraktUser>
    {
        public ITraktObjectJsonReader<ITraktUser> CreateObjectReader() => new TraktUserObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUser> CreateArrayReader() => new TraktUserArrayJsonReader();
    }
}
