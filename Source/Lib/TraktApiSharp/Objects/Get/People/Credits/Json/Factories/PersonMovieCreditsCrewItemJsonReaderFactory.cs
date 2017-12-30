namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;

    internal class PersonMovieCreditsCrewItemJsonReaderFactory : IJsonIOFactory<ITraktPersonMovieCreditsCrewItem>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCrewItem> CreateObjectReader() => new PersonMovieCreditsCrewItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCrewItem> CreateArrayReader() => new PersonMovieCreditsCrewItemArrayJsonReader();

        public IObjectJsonReader<ITraktPersonMovieCreditsCrewItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktPersonMovieCreditsCrewItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
