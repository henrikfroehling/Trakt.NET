namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCastMemberJsonReaderFactory : IJsonReaderFactory<ITraktCastMember>
    {
        public ITraktObjectJsonReader<ITraktCastMember> CreateObjectReader() => new TraktCastMemberObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCastMember> CreateArrayReader() => new TraktCastMemberArrayJsonReader();
    }
}
