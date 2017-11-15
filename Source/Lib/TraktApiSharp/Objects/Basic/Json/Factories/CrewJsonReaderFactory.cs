namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Json;
    using System;

    internal class CrewJsonReaderFactory : IJsonReaderFactory<ITraktCrew>
    {
        public IObjectJsonReader<ITraktCrew> CreateObjectReader() => new CrewObjectJsonReader();

        public IArrayJsonReader<ITraktCrew> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCrew)} is not supported.");
        }
    }
}
