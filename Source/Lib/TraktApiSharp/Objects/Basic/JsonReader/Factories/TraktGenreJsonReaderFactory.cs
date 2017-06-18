namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktGenreJsonReaderFactory : ITraktJsonReaderFactory<ITraktGenre>
    {
        public ITraktObjectJsonReader<ITraktGenre> CreateObjectReader() => new TraktGenreObjectJsonReader();

        public ITraktArrayJsonReader<ITraktGenre> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktGenre)} is not supported.");
        }
    }
}
