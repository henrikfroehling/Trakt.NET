namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories.Reader
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;

    internal class PersonShowCreditsCastItemJsonReaderFactory : IJsonReaderFactory<ITraktPersonShowCreditsCastItem>
    {
        public IObjectJsonReader<ITraktPersonShowCreditsCastItem> CreateObjectReader() => new PersonShowCreditsCastItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCreditsCastItem> CreateArrayReader() => new PersonShowCreditsCastItemArrayJsonReader();
    }
}
