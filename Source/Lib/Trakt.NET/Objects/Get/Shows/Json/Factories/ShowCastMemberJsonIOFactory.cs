namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class ShowCastMemberJsonIOFactory : IJsonIOFactory<ITraktShowCastMember>
    {
        public IObjectJsonReader<ITraktShowCastMember> CreateObjectReader() => new ShowCastMemberObjectJsonReader();

        public IObjectJsonWriter<ITraktShowCastMember> CreateObjectWriter() => new ShowCastMemberObjectJsonWriter();
    }
}
