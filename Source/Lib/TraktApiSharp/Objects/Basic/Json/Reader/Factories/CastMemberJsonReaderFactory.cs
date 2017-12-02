namespace TraktApiSharp.Objects.Basic.Json.Factories.Reader
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class CastMemberJsonReaderFactory : IJsonReaderFactory<ITraktCastMember>
    {
        public IObjectJsonReader<ITraktCastMember> CreateObjectReader() => new CastMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCastMember> CreateArrayReader() => new CastMemberArrayJsonReader();
    }
}
