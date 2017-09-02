namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CastMemberJsonReaderFactory : IJsonReaderFactory<ITraktCastMember>
    {
        public IObjectJsonReader<ITraktCastMember> CreateObjectReader() => new CastMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCastMember> CreateArrayReader() => new CastMemberArrayJsonReader();
    }
}
