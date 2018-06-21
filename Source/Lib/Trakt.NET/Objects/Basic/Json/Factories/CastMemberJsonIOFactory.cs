namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CastMemberJsonIOFactory : IJsonIOFactory<ITraktCastMember>
    {
        public IObjectJsonReader<ITraktCastMember> CreateObjectReader() => new CastMemberObjectJsonReader();

        public IArrayJsonReader<ITraktCastMember> CreateArrayReader() => new CastMemberArrayJsonReader();

        public IObjectJsonWriter<ITraktCastMember> CreateObjectWriter() => new CastMemberObjectJsonWriter();
    }
}
