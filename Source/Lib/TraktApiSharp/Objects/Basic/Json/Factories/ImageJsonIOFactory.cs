namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;
    using System;

    internal class ImageJsonIOFactory : IJsonIOFactory<ITraktImage>
    {
        public IObjectJsonReader<ITraktImage> CreateObjectReader() => new ImageObjectJsonReader();

        public IArrayJsonReader<ITraktImage> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktImage)} is not supported.");

        public IObjectJsonWriter<ITraktImage> CreateObjectWriter() => new ImageObjectJsonWriter();
    }
}
