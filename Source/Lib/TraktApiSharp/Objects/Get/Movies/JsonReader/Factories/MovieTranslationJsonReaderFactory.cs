namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class MovieTranslationJsonReaderFactory : IJsonReaderFactory<ITraktMovieTranslation>
    {
        public IObjectJsonReader<ITraktMovieTranslation> CreateObjectReader() => new MovieTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktMovieTranslation> CreateArrayReader() => new MovieTranslationArrayJsonReader();
    }
}
