namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktUserFollowerJsonReaderFactory : IJsonReaderFactory<ITraktUserFollower>
    {
        public ITraktObjectJsonReader<ITraktUserFollower> CreateObjectReader() => new TraktUserFollowerObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollower> CreateArrayReader() => new TraktUserFollowerArrayJsonReader();
    }
}
