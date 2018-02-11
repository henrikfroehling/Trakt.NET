namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Get.People.Credits.Json.Writer;
    using Objects.Json;

    internal class PersonMovieCreditsCrewItemJsonIOFactory : IJsonIOFactory<ITraktPersonMovieCreditsCrewItem>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCrewItem> CreateObjectReader() => new PersonMovieCreditsCrewItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCrewItem> CreateArrayReader() => new PersonMovieCreditsCrewItemArrayJsonReader();

        public IObjectJsonWriter<ITraktPersonMovieCreditsCrewItem> CreateObjectWriter() => new PersonMovieCreditsCrewItemObjectJsonWriter();

        public IArrayJsonWriter<ITraktPersonMovieCreditsCrewItem> CreateArrayWriter() => new PersonMovieCreditsCrewItemArrayJsonWriter();
    }
}
