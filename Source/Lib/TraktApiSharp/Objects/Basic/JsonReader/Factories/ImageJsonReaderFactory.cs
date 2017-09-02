namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
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
