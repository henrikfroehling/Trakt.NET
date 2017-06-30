namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktCastAndCrewJsonReaderFactory : ITraktJsonReaderFactory<ITraktCastAndCrew>
    {
        public ITraktObjectJsonReader<ITraktCastAndCrew> CreateObjectReader() => new TraktCastAndCrewObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCastAndCrew> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCastAndCrew)} is not supported.");
        }
    }
}
