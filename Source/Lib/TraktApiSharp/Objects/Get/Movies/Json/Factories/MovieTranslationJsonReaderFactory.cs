namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Objects.Json;

    internal class MovieTranslationJsonReaderFactory : IJsonReaderFactory<ITraktMovieTranslation>
    {
        public IObjectJsonReader<ITraktMovieTranslation> CreateObjectReader() => new MovieTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktMovieTranslation> CreateArrayReader() => new MovieTranslationArrayJsonReader();
    }
}
