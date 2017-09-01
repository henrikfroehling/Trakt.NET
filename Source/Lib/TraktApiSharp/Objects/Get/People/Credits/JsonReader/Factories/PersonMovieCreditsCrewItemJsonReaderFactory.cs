namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class PersonMovieCreditsCrewItemJsonReaderFactory : IJsonReaderFactory<ITraktPersonMovieCreditsCrewItem>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCrewItem> CreateObjectReader() => new TraktPersonMovieCreditsCrewItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCrewItem> CreateArrayReader() => new TraktPersonMovieCreditsCrewItemArrayJsonReader();
    }
}
