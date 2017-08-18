namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktPersonMovieCreditsCrewItemJsonReaderFactory : IJsonReaderFactory<ITraktPersonMovieCreditsCrewItem>
    {
        public ITraktObjectJsonReader<ITraktPersonMovieCreditsCrewItem> CreateObjectReader() => new TraktPersonMovieCreditsCrewItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCrewItem> CreateArrayReader() => new TraktPersonMovieCreditsCrewItemArrayJsonReader();
    }
}
