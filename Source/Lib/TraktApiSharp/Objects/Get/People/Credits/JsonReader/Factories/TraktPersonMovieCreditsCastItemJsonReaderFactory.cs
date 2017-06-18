namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktPersonMovieCreditsCastItemJsonReaderFactory : ITraktJsonReaderFactory<ITraktPersonMovieCreditsCastItem>
    {
        public ITraktObjectJsonReader<ITraktPersonMovieCreditsCastItem> CreateObjectReader() => new TraktPersonMovieCreditsCastItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPersonMovieCreditsCastItem> CreateArrayReader() => new TraktPersonMovieCreditsCastItemArrayJsonReader();
    }
}
