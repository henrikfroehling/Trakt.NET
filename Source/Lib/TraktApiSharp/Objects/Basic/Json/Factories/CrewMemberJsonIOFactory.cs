namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class CrewMemberJsonIOFactory : IJsonIOFactory<ITraktCrewMember>
    {
        public IObjectJsonReader<ITraktCrewMember> CreateObjectReader() => new CrewMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCrewMember> CreateArrayReader() => new CrewMemberArrayJsonReader();

        public IObjectJsonWriter<ITraktCrewMember> CreateObjectWriter() => throw new System.NotImplementedException();

        public IArrayJsonWriter<ITraktCrewMember> CreateArrayWriter() => throw new System.NotImplementedException();
    }
}
