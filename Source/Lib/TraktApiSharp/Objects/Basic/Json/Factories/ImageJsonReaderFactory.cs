namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class ImageJsonReaderFactory : IJsonIOFactory<ITraktImage>
    {
        public IObjectJsonReader<ITraktImage> CreateObjectReader() => new ImageObjectJsonReader();

        public IArrayJsonReader<ITraktImage> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktImage)} is not supported.");
        }

        public IObjectJsonReader<ITraktImage> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktImage> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
