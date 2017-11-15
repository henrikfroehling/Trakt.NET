namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Objects.Json;

    internal class PersonMovieCreditsCastItemJsonReaderFactory : IJsonReaderFactory<ITraktPersonMovieCreditsCastItem>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCastItem> CreateObjectReader() => new PersonMovieCreditsCastItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCastItem> CreateArrayReader() => new PersonMovieCreditsCastItemArrayJsonReader();
    }
}
