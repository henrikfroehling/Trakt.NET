namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktPersonShowCreditsCastItemJsonReaderFactory : IJsonReaderFactory<ITraktPersonShowCreditsCastItem>
    {
        public ITraktObjectJsonReader<ITraktPersonShowCreditsCastItem> CreateObjectReader() => new TraktPersonShowCreditsCastItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCreditsCastItem> CreateArrayReader() => new TraktPersonShowCreditsCastItemArrayJsonReader();
    }
}
