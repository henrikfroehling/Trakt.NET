namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class CrewJsonReaderFactory : IJsonIOFactory<ITraktCrew>
    {
        public IObjectJsonReader<ITraktCrew> CreateObjectReader() => new CrewObjectJsonReader();

        public IArrayJsonReader<ITraktCrew> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCrew)} is not supported.");
        }

        public IObjectJsonReader<ITraktCrew> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktCrew> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
