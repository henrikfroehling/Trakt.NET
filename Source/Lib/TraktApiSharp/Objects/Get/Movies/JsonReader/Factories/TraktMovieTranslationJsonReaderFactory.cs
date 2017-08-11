namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktMovieTranslationJsonReaderFactory : ITraktJsonReaderFactory<ITraktMovieTranslation>
    {
        public ITraktObjectJsonReader<ITraktMovieTranslation> CreateObjectReader() => new TraktMovieTranslationObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMovieTranslation> CreateArrayReader() => new TraktMovieTranslationArrayJsonReader();
    }
}
