namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;
    using System;

    internal class CrewJsonIOFactory : IJsonIOFactory<ITraktCrew>
    {
        public IObjectJsonReader<ITraktCrew> CreateObjectReader() => new CrewObjectJsonReader();

        public IArrayJsonReader<ITraktCrew> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktCrew)} is not supported.");

        public IObjectJsonWriter<ITraktCrew> CreateObjectWriter() => new CrewObjectJsonWriter();
    }
}
