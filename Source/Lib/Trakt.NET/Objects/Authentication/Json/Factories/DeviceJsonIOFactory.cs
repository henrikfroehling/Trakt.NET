namespace TraktNet.Objects.Authentication.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class DeviceJsonIOFactory : IJsonIOFactory<ITraktDevice>
    {
        public IObjectJsonReader<ITraktDevice> CreateObjectReader() => new DeviceObjectJsonReader();

        public IObjectJsonWriter<ITraktDevice> CreateObjectWriter() => new DeviceObjectJsonWriter();
    }
}
