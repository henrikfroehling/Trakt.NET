namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CastAndCrewJsonIOFactory : IJsonIOFactory<ITraktCastAndCrew>
    {
        public IObjectJsonReader<ITraktCastAndCrew> CreateObjectReader() => new CastAndCrewObjectJsonReader();

        public IObjectJsonWriter<ITraktCastAndCrew> CreateObjectWriter() => new CastAndCrewObjectJsonWriter();
    }
}
