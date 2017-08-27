namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CrewMemberJsonReaderFactory : IJsonReaderFactory<ITraktCrewMember>
    {
        public IObjectJsonReader<ITraktCrewMember> CreateObjectReader() => new TraktCrewMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCrewMember> CreateArrayReader() => new TraktCrewMemberArrayJsonReader();
    }
}
