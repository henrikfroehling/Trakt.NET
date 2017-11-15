namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Json;
    using System;

    internal class ImageJsonReaderFactory : IJsonReaderFactory<ITraktImage>
    {
        public IObjectJsonReader<ITraktImage> CreateObjectReader() => new ImageObjectJsonReader();

        public IArrayJsonReader<ITraktImage> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktImage)} is not supported.");
        }
    }
}
