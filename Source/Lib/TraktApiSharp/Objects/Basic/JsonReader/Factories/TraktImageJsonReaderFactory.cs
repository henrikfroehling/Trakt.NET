namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktImageJsonReaderFactory : ITraktJsonReaderFactory<ITraktImage>
    {
        public ITraktObjectJsonReader<ITraktImage> CreateObjectReader() => new TraktImageObjectJsonReader();

        public ITraktArrayJsonReader<ITraktImage> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktImage)} is not supported.");
        }
    }
}
