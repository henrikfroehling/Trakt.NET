namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktPersonMovieCreditsCrewItemJsonReaderFactory : IJsonReaderFactory<ITraktPersonMovieCreditsCrewItem>
    {
        public ITraktObjectJsonReader<ITraktPersonMovieCreditsCrewItem> CreateObjectReader() => new TraktPersonMovieCreditsCrewItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPersonMovieCreditsCrewItem> CreateArrayReader() => new TraktPersonMovieCreditsCrewItemArrayJsonReader();
    }
}
