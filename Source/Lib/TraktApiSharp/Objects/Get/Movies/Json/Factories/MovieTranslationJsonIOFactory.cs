namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class MovieTranslationJsonIOFactory : IJsonIOFactory<ITraktMovieTranslation>
    {
        public IObjectJsonReader<ITraktMovieTranslation> CreateObjectReader() => new MovieTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktMovieTranslation> CreateArrayReader() => new MovieTranslationArrayJsonReader();

        public IObjectJsonWriter<ITraktMovieTranslation> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktMovieTranslation> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
