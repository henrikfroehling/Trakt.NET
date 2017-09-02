namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
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
