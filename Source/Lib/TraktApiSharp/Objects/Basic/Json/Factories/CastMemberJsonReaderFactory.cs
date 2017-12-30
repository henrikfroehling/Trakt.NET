namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class CastMemberJsonReaderFactory : IJsonIOFactory<ITraktCastMember>
    {
        public IObjectJsonReader<ITraktCastMember> CreateObjectReader() => new CastMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCastMember> CreateArrayReader() => new CastMemberArrayJsonReader();

        public IObjectJsonReader<ITraktCastMember> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktCastMember> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
