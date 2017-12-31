namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class CastMemberJsonIOFactory : IJsonIOFactory<ITraktCastMember>
    {
        public IObjectJsonReader<ITraktCastMember> CreateObjectReader() => new CastMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCastMember> CreateArrayReader() => new CastMemberArrayJsonReader();

        public IObjectJsonWriter<ITraktCastMember> CreateObjectWriter() => throw new System.NotImplementedException();

        public IArrayJsonWriter<ITraktCastMember> CreateArrayWriter() => throw new System.NotImplementedException();
    }
}
