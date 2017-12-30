namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;
    using System;

    internal class ShowIdsJsonReaderFactory : IJsonIOFactory<ITraktShowIds>
    {
        public IObjectJsonReader<ITraktShowIds> CreateObjectReader() => new ShowIdsObjectJsonReader();

        public IArrayJsonReader<ITraktShowIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowIds)} is not supported.");
        }

        public IObjectJsonReader<ITraktShowIds> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktShowIds> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
