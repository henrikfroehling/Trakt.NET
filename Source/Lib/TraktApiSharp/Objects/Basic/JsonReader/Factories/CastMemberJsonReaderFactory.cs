namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CastMemberJsonReaderFactory : IJsonReaderFactory<ITraktCastMember>
    {
        public IObjectJsonReader<ITraktCastMember> CreateObjectReader() => new TraktCastMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCastMember> CreateArrayReader() => new CastMemberArrayJsonReader();
    }
}
