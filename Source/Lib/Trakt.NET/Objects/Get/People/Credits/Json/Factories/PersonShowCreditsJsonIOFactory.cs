namespace TraktNet.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Get.People.Credits.Json.Writer;
    using Objects.Json;

    internal class PersonShowCreditsJsonIOFactory : IJsonIOFactory<ITraktPersonShowCredits>
    {
        public IObjectJsonReader<ITraktPersonShowCredits> CreateObjectReader() => new PersonShowCreditsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCredits> CreateArrayReader() => new PersonShowCreditsArrayJsonReader();

        public IObjectJsonWriter<ITraktPersonShowCredits> CreateObjectWriter() => new PersonShowCreditsObjectJsonWriter();
    }
}
