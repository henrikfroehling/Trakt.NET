namespace TraktApiSharp.Objects.Get.Users.Lists.Json.Factories
{
    using Get.Users.Lists.Json.Reader;
    using Get.Users.Lists.Json.Writer;
    using Objects.Json;
    using System;

    internal class ListIdsJsonIOFactory : IJsonIOFactory<ITraktListIds>
    {
        public IObjectJsonReader<ITraktListIds> CreateObjectReader() => new ListIdsObjectJsonReader();

        public IArrayJsonReader<ITraktListIds> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktListIds)} is not supported.");

        public IObjectJsonWriter<ITraktListIds> CreateObjectWriter() => new ListIdsObjectJsonWriter();
    }
}
