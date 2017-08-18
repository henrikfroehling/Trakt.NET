namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCrewMemberJsonReaderFactory : IJsonReaderFactory<ITraktCrewMember>
    {
        public ITraktObjectJsonReader<ITraktCrewMember> CreateObjectReader() => new TraktCrewMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCrewMember> CreateArrayReader() => new TraktCrewMemberArrayJsonReader();
    }
}
