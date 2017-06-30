namespace TraktApiSharp.Objects.Get.Collections.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktCollectionMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktCollectionMovie>
    {
        public ITraktObjectJsonReader<ITraktCollectionMovie> CreateObjectReader() => new TraktCollectionMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCollectionMovie> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCollectionMovie)} is not supported.");
        }
    }
}
