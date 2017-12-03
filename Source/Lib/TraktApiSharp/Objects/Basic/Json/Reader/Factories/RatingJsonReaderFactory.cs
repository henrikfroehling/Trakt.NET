namespace TraktApiSharp.Objects.Basic.Json.Factories.Reader
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class RatingJsonReaderFactory : IJsonReaderFactory<ITraktRating>
    {
        public IObjectJsonReader<ITraktRating> CreateObjectReader() => new RatingObjectJsonReader();

        public IArrayJsonReader<ITraktRating> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktRating)} is not supported.");
        }
    }
}
