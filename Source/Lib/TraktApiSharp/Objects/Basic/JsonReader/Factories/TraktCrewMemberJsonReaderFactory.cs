namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCrewMemberJsonReaderFactory : IJsonReaderFactory<ITraktCrewMember>
    {
        public ITraktObjectJsonReader<ITraktCrewMember> CreateObjectReader() => new TraktCrewMemberObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCrewMember> CreateArrayReader() => new TraktCrewMemberArrayJsonReader();
    }
}
