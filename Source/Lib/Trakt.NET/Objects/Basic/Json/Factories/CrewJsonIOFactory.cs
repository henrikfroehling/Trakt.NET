namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CrewJsonIOFactory : IJsonIOFactory<ITraktCrew>
    {
        public IObjectJsonReader<ITraktCrew> CreateObjectReader() => new CrewObjectJsonReader();

        public IObjectJsonWriter<ITraktCrew> CreateObjectWriter() => new CrewObjectJsonWriter();
    }
}
