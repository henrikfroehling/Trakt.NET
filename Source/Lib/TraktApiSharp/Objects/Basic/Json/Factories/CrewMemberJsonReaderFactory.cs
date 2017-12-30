namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class CrewMemberJsonReaderFactory : IJsonIOFactory<ITraktCrewMember>
    {
        public IObjectJsonReader<ITraktCrewMember> CreateObjectReader() => new CrewMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCrewMember> CreateArrayReader() => new CrewMemberArrayJsonReader();

        public IObjectJsonReader<ITraktCrewMember> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktCrewMember> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
