namespace TraktNet.Objects.Get.People.Json.Factories
{
    using Get.People.Json.Reader;
    using Get.People.Json.Writer;
    using Objects.Json;

    internal class PersonIdsJsonIOFactory : IJsonIOFactory<ITraktPersonIds>
    {
        public IObjectJsonReader<ITraktPersonIds> CreateObjectReader() => new PersonIdsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonIds> CreateArrayReader() => new PersonIdsArrayJsonReader();

        public IObjectJsonWriter<ITraktPersonIds> CreateObjectWriter() => new PersonIdsObjectJsonWriter();
    }
}
