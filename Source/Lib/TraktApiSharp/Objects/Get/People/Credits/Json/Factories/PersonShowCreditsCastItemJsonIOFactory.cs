namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;

    internal class PersonShowCreditsCastItemJsonIOFactory : IJsonIOFactory<ITraktPersonShowCreditsCastItem>
    {
        public IObjectJsonReader<ITraktPersonShowCreditsCastItem> CreateObjectReader() => new PersonShowCreditsCastItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCreditsCastItem> CreateArrayReader() => new PersonShowCreditsCastItemArrayJsonReader();

        public IObjectJsonWriter<ITraktPersonShowCreditsCastItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktPersonShowCreditsCastItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
