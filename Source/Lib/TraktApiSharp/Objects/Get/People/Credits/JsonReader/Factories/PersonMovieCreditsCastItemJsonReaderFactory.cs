namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class PersonMovieCreditsCastItemJsonReaderFactory : IJsonReaderFactory<ITraktPersonMovieCreditsCastItem>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCastItem> CreateObjectReader() => new PersonMovieCreditsCastItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCastItem> CreateArrayReader() => new PersonMovieCreditsCastItemArrayJsonReader();
    }
}
