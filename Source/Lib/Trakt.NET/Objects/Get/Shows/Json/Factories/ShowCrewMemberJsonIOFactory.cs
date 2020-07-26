namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class ShowCrewMemberJsonIOFactory : IJsonIOFactory<ITraktShowCrewMember>
    {
        public IObjectJsonReader<ITraktShowCrewMember> CreateObjectReader() => new ShowCrewMemberObjectJsonReader();

        public IObjectJsonWriter<ITraktShowCrewMember> CreateObjectWriter() => new ShowCrewMemberObjectJsonWriter();
    }
}
