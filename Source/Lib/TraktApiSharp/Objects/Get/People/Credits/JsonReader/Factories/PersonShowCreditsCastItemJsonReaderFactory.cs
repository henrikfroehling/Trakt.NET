namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class PersonShowCreditsCastItemJsonReaderFactory : IJsonReaderFactory<ITraktPersonShowCreditsCastItem>
    {
        public IObjectJsonReader<ITraktPersonShowCreditsCastItem> CreateObjectReader() => new PersonShowCreditsCastItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCreditsCastItem> CreateArrayReader() => new PersonShowCreditsCastItemArrayJsonReader();
    }
}
