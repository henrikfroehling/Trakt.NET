namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktPersonMovieCreditsCastItemJsonReaderFactory : IJsonReaderFactory<ITraktPersonMovieCreditsCastItem>
    {
        public ITraktObjectJsonReader<ITraktPersonMovieCreditsCastItem> CreateObjectReader() => new TraktPersonMovieCreditsCastItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCastItem> CreateArrayReader() => new TraktPersonMovieCreditsCastItemArrayJsonReader();
    }
}
