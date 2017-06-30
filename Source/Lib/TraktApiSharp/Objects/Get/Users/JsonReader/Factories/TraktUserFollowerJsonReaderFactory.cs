namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserFollowerJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserFollower>
    {
        public ITraktObjectJsonReader<ITraktUserFollower> CreateObjectReader() => new TraktUserFollowerObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserFollower> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserFollower)} is not supported.");
        }
    }
}
