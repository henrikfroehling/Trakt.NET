namespace TraktNet.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class MovieIdsJsonIOFactory : IJsonIOFactory<ITraktMovieIds>
    {
        public IObjectJsonReader<ITraktMovieIds> CreateObjectReader() => new MovieIdsObjectJsonReader();

        public IObjectJsonWriter<ITraktMovieIds> CreateObjectWriter() => new MovieIdsObjectJsonWriter();
    }
}
