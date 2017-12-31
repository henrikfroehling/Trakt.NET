namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class CastAndCrewJsonIOFactory : IJsonIOFactory<ITraktCastAndCrew>
    {
        public IObjectJsonReader<ITraktCastAndCrew> CreateObjectReader() => new CastAndCrewObjectJsonReader();

        public IArrayJsonReader<ITraktCastAndCrew> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktCastAndCrew)} is not supported.");

        public IObjectJsonWriter<ITraktCastAndCrew> CreateObjectWriter() => throw new NotImplementedException();

        public IArrayJsonWriter<ITraktCastAndCrew> CreateArrayWriter() => throw new NotImplementedException();
    }
}
