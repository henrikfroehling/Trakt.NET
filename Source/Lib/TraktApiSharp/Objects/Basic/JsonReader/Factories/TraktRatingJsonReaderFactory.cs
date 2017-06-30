namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktRatingJsonReaderFactory : ITraktJsonReaderFactory<ITraktRating>
    {
        public ITraktObjectJsonReader<ITraktRating> CreateObjectReader() => new TraktRatingObjectJsonReader();

        public ITraktArrayJsonReader<ITraktRating> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktRating)} is not supported.");
        }
    }
}
