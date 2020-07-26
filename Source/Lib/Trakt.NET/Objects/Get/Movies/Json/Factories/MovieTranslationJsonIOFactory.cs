namespace TraktNet.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class MovieTranslationJsonIOFactory : IJsonIOFactory<ITraktMovieTranslation>
    {
        public IObjectJsonReader<ITraktMovieTranslation> CreateObjectReader() => new MovieTranslationObjectJsonReader();

        public IObjectJsonWriter<ITraktMovieTranslation> CreateObjectWriter() => new MovieTranslationObjectJsonWriter();
    }
}
