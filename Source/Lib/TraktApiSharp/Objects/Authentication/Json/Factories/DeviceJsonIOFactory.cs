namespace TraktApiSharp.Objects.Authentication.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class DeviceJsonIOFactory : IJsonIOFactory<ITraktDevice>
    {
        public IObjectJsonReader<ITraktDevice> CreateObjectReader() => new DeviceObjectJsonReader();

        public IArrayJsonReader<ITraktDevice> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktDevice)} is not supported.");

        public IObjectJsonWriter<ITraktDevice> CreateObjectWriter() => new DeviceObjectJsonWriter();
    }
}
