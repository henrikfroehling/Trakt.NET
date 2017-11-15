namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Json;
    using System;

    internal class CastAndCrewJsonReaderFactory : IJsonReaderFactory<ITraktCastAndCrew>
    {
        public IObjectJsonReader<ITraktCastAndCrew> CreateObjectReader() => new CastAndCrewObjectJsonReader();

        public IArrayJsonReader<ITraktCastAndCrew> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCastAndCrew)} is not supported.");
        }
    }
}
