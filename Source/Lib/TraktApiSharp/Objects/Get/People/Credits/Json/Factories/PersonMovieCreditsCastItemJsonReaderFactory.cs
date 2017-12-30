namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;

    internal class PersonMovieCreditsCastItemJsonReaderFactory : IJsonIOFactory<ITraktPersonMovieCreditsCastItem>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCastItem> CreateObjectReader() => new PersonMovieCreditsCastItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCastItem> CreateArrayReader() => new PersonMovieCreditsCastItemArrayJsonReader();

        public IObjectJsonReader<ITraktPersonMovieCreditsCastItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktPersonMovieCreditsCastItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
