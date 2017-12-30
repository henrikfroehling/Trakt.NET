namespace TraktApiSharp.Objects.Get.Users.Lists.Json.Factories
{
    using Get.Users.Lists.Json.Reader;
    using Objects.Json;
    using System;

    internal class ListIdsJsonReaderFactory : IJsonIOFactory<ITraktListIds>
    {
        public IObjectJsonReader<ITraktListIds> CreateObjectReader() => new ListIdsObjectJsonReader();

        public IArrayJsonReader<ITraktListIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktListIds)} is not supported.");
        }

        public IObjectJsonReader<ITraktListIds> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktListIds> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
