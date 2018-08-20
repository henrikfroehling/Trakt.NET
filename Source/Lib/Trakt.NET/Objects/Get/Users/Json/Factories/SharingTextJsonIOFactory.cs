namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class SharingTextJsonIOFactory : IJsonIOFactory<ITraktSharingText>
    {
        public IObjectJsonReader<ITraktSharingText> CreateObjectReader() => new SharingTextObjectJsonReader();

        public IArrayJsonReader<ITraktSharingText> CreateArrayReader() => new SharingTextArrayJsonReader();

        public IObjectJsonWriter<ITraktSharingText> CreateObjectWriter() => new SharingTextObjectJsonWriter();
    }
}
