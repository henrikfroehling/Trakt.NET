namespace TraktNet.Objects.Get.People.Json.Factories
{
    using Get.People.Json.Reader;
    using Get.People.Json.Writer;
    using Objects.Json;

    internal class RecentlyUpdatedPersonJsonIOFactory : IJsonIOFactory<ITraktRecentlyUpdatedPerson>
    {
        public IObjectJsonReader<ITraktRecentlyUpdatedPerson> CreateObjectReader() => new RecentlyUpdatedPersonObjectJsonReader();

        public IObjectJsonWriter<ITraktRecentlyUpdatedPerson> CreateObjectWriter() => new RecentlyUpdatedPersonObjectJsonWriter();
    }
}
