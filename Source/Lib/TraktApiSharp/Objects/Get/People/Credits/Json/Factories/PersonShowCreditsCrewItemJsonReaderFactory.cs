namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Objects.Json;

    internal class PersonShowCreditsCrewItemJsonReaderFactory : IJsonReaderFactory<ITraktPersonShowCreditsCrewItem>
    {
        public IObjectJsonReader<ITraktPersonShowCreditsCrewItem> CreateObjectReader() => new PersonShowCreditsCrewItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCreditsCrewItem> CreateArrayReader() => new PersonShowCreditsCrewItemArrayJsonReader();
    }
}
