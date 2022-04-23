namespace TraktNet.Objects.Get.People.Json.Factories
{
    using Get.People.Json.Reader;
    using Get.People.Json.Writer;
    using Objects.Json;

    internal class PersonSocialIdsJsonIOFactory : IJsonIOFactory<ITraktPersonSocialIds>
    {
        public IObjectJsonReader<ITraktPersonSocialIds> CreateObjectReader() => new PersonSocialIdsObjectJsonReader();

        public IObjectJsonWriter<ITraktPersonSocialIds> CreateObjectWriter() => new PersonSocialIdsObjectJsonWriter();
    }
}
