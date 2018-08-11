namespace TraktNet.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Get.People.Credits.Json.Writer;
    using Objects.Json;

    internal class PersonMovieCreditsCrewJsonIOFactory : IJsonIOFactory<ITraktPersonMovieCreditsCrew>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCrew> CreateObjectReader() => new PersonMovieCreditsCrewObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCrew> CreateArrayReader() => new PersonMovieCreditsCrewArrayJsonReader();

        public IObjectJsonWriter<ITraktPersonMovieCreditsCrew> CreateObjectWriter() => new PersonMovieCreditsCrewObjectJsonWriter();
    }
}
