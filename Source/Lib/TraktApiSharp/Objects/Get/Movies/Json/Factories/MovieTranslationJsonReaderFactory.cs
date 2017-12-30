namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class MovieTranslationJsonReaderFactory : IJsonIOFactory<ITraktMovieTranslation>
    {
        public IObjectJsonReader<ITraktMovieTranslation> CreateObjectReader() => new MovieTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktMovieTranslation> CreateArrayReader() => new MovieTranslationArrayJsonReader();

        public IObjectJsonReader<ITraktMovieTranslation> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktMovieTranslation> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
