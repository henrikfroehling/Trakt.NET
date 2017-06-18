namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktListJsonReaderFactory : ITraktJsonReaderFactory<ITraktList>
    {
        public ITraktObjectJsonReader<ITraktList> CreateObjectReader() => new TraktListObjectJsonReader();

        public ITraktArrayJsonReader<ITraktList> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktList)} is not supported.");
        }
    }
}
