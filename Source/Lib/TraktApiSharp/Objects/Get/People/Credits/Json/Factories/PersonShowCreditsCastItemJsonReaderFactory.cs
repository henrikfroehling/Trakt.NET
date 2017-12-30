namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;

    internal class PersonShowCreditsCastItemJsonReaderFactory : IJsonIOFactory<ITraktPersonShowCreditsCastItem>
    {
        public IObjectJsonReader<ITraktPersonShowCreditsCastItem> CreateObjectReader() => new PersonShowCreditsCastItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCreditsCastItem> CreateArrayReader() => new PersonShowCreditsCastItemArrayJsonReader();

        public IObjectJsonReader<ITraktPersonShowCreditsCastItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktPersonShowCreditsCastItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
