namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class RatingJsonReaderFactory : IJsonReaderFactory<ITraktRating>
    {
        public IObjectJsonReader<ITraktRating> CreateObjectReader() => new TraktRatingObjectJsonReader();

        public IArrayJsonReader<ITraktRating> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktRating)} is not supported.");
        }
    }
}
