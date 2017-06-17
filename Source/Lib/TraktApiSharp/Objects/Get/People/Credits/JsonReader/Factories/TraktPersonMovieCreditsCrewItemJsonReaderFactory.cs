namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktPersonMovieCreditsCrewItemJsonReaderFactory : ITraktJsonReaderFactory<ITraktPersonMovieCreditsCrewItem>
    {
        public ITraktObjectJsonReader<ITraktPersonMovieCreditsCrewItem> CreateObjectReader() => new TraktPersonMovieCreditsCrewItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPersonMovieCreditsCrewItem> CreateArrayReader() => new TraktPersonMovieCreditsCrewItemArrayJsonReader();
    }
}
