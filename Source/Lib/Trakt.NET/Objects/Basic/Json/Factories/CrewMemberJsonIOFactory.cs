namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CrewMemberJsonIOFactory : IJsonIOFactory<ITraktCrewMember>
    {
        public IObjectJsonReader<ITraktCrewMember> CreateObjectReader() => new CrewMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCrewMember> CreateArrayReader() => new CrewMemberArrayJsonReader();

        public IObjectJsonWriter<ITraktCrewMember> CreateObjectWriter() => new CrewMemberObjectJsonWriter();
    }
}
