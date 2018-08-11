namespace TraktNet.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Get.People.Credits.Json.Writer;
    using Objects.Json;

    internal class PersonMovieCreditsJsonIOFactory : IJsonIOFactory<ITraktPersonMovieCredits>
    {
        public IObjectJsonReader<ITraktPersonMovieCredits> CreateObjectReader() => new PersonMovieCreditsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCredits> CreateArrayReader() => new PersonMovieCreditsArrayJsonReader();

        public IObjectJsonWriter<ITraktPersonMovieCredits> CreateObjectWriter() => new PersonMovieCreditsObjectJsonWriter();
    }
}
