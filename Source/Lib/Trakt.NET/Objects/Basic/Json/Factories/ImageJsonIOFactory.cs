namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class ImageJsonIOFactory : IJsonIOFactory<ITraktImage>
    {
        public IObjectJsonReader<ITraktImage> CreateObjectReader() => new ImageObjectJsonReader();

        public IArrayJsonReader<ITraktImage> CreateArrayReader() => new ImageArrayJsonReader();

        public IObjectJsonWriter<ITraktImage> CreateObjectWriter() => new ImageObjectJsonWriter();
    }
}
