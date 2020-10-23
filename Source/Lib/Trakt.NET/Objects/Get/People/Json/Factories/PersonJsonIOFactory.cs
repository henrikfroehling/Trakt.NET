namespace TraktNet.Objects.Get.People.Json.Factories
{
    using Get.People.Json.Reader;
    using Get.People.Json.Writer;
    using Objects.Json;

    internal class PersonJsonIOFactory : IJsonIOFactory<ITraktPerson>
    {
        public IObjectJsonReader<ITraktPerson> CreateObjectReader() => new PersonObjectJsonReader();

        public IObjectJsonWriter<ITraktPerson> CreateObjectWriter() => new PersonObjectJsonWriter();
    }
}
