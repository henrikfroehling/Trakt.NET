namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Json;

    internal class CrewMemberJsonReaderFactory : IJsonReaderFactory<ITraktCrewMember>
    {
        public IObjectJsonReader<ITraktCrewMember> CreateObjectReader() => new CrewMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCrewMember> CreateArrayReader() => new CrewMemberArrayJsonReader();
    }
}
