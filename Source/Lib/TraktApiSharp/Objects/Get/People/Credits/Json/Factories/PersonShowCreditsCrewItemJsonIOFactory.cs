namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;

    internal class PersonShowCreditsCrewItemJsonIOFactory : IJsonIOFactory<ITraktPersonShowCreditsCrewItem>
    {
        public IObjectJsonReader<ITraktPersonShowCreditsCrewItem> CreateObjectReader() => new PersonShowCreditsCrewItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCreditsCrewItem> CreateArrayReader() => new PersonShowCreditsCrewItemArrayJsonReader();

        public IObjectJsonWriter<ITraktPersonShowCreditsCrewItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktPersonShowCreditsCrewItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
