namespace TraktNet.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Get.People.Credits.Json.Writer;
    using Objects.Json;

    internal class PersonMovieCreditsCrewItemJsonIOFactory : IJsonIOFactory<ITraktPersonMovieCreditsCrewItem>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCrewItem> CreateObjectReader() => new PersonMovieCreditsCrewItemObjectJsonReader();

        public IObjectJsonWriter<ITraktPersonMovieCreditsCrewItem> CreateObjectWriter() => new PersonMovieCreditsCrewItemObjectJsonWriter();
    }
}
