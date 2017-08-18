namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktMovieTranslationJsonReaderFactory : IJsonReaderFactory<ITraktMovieTranslation>
    {
        public ITraktObjectJsonReader<ITraktMovieTranslation> CreateObjectReader() => new TraktMovieTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktMovieTranslation> CreateArrayReader() => new TraktMovieTranslationArrayJsonReader();
    }
}
