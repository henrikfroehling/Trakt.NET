namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Objects.Json;

    internal class PersonMovieCreditsCrewItemJsonReaderFactory : IJsonReaderFactory<ITraktPersonMovieCreditsCrewItem>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCrewItem> CreateObjectReader() => new PersonMovieCreditsCrewItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCrewItem> CreateArrayReader() => new PersonMovieCreditsCrewItemArrayJsonReader();
    }
}
