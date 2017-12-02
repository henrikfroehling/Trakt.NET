namespace TraktApiSharp.Objects.Basic.Json.Factories.Reader
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class CrewMemberJsonReaderFactory : IJsonReaderFactory<ITraktCrewMember>
    {
        public IObjectJsonReader<ITraktCrewMember> CreateObjectReader() => new CrewMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCrewMember> CreateArrayReader() => new CrewMemberArrayJsonReader();
    }
}
