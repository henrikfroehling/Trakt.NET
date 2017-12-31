namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class RatingJsonIOFactory : IJsonIOFactory<ITraktRating>
    {
        public IObjectJsonReader<ITraktRating> CreateObjectReader() => new RatingObjectJsonReader();

        public IArrayJsonReader<ITraktRating> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktRating)} is not supported.");
        }

        public IObjectJsonWriter<ITraktRating> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktRating> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
