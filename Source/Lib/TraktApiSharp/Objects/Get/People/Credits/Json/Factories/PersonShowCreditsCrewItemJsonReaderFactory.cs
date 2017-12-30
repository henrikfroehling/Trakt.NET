namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;

    internal class PersonShowCreditsCrewItemJsonReaderFactory : IJsonIOFactory<ITraktPersonShowCreditsCrewItem>
    {
        public IObjectJsonReader<ITraktPersonShowCreditsCrewItem> CreateObjectReader() => new PersonShowCreditsCrewItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCreditsCrewItem> CreateArrayReader() => new PersonShowCreditsCrewItemArrayJsonReader();

        public IObjectJsonReader<ITraktPersonShowCreditsCrewItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktPersonShowCreditsCrewItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
